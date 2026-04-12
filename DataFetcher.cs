using BillyNaCl.DIContainer.Core.StaticGlobalDIContainerGateway;
using BillyNaCl.QQGroupToolkit.Interfaces;
using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BillyNaCl.QQGroupToolkit
{
    internal class DataFetcher : IGetGroupMembers
    {
        IHTTPClientService httpClientService = DI.GetService<IHTTPClientService>();
        IURLBuilder urlBuilder = DI.GetService<IURLBuilder>();
        IConfigProvider configProvider = DI.GetService<IConfigProvider>();
        IGetGroupInfo groupInfoProvider = DI.GetService<IGetGroupInfo>();
        const string ProtocolIsNotSupported = "Protocol is not supported. Only \"One Bot 11\", \"Satori\", and \"Milky\" are supported.";

        public List<IGroupMember> GetGroupMembers(int groupId)
            => GetGroupMembers(groupId, out _);

        public List<IGroupMember> GetGroupMembers(int groupId, out string groupName)
        {
            string protocol = configProvider.GetProtocol();
            // TODO: 把Satori支持了
            if (protocol == "Satori")
                throw new NotImplementedException("Satori is not supported yet.");
            string basePath = protocol switch
            {
                "One Bot 11" => "",
                "Satori" => "v1",
                "Milky" => "api",
                _ => throw new ProtocolViolationException(ProtocolIsNotSupported)
            };
            string endPoint = protocol switch
            {
                "One Bot 11" => "get_group_member_list",
                "Satori" => "guild.member.list",
                "Milky" => "get_group_member_list",
                _ => throw new ProtocolViolationException(ProtocolIsNotSupported)
            };
            string url = urlBuilder.BuildLocalHostURL(protocol, basePath, endPoint);
            string body = BuildRequestBody(protocol, groupId, null);
            var response = httpClientService.POST(url, body).GetAwaiter().GetResult();
            // TODO: 这里需要检查错误
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jsonNodeRoot = JsonNode.Parse(responseBody);
            // TODO: 把One Bot 11支持了
            if (protocol == "One Bot 11")
                throw new NotImplementedException("One Bot 11 is not supported yet.");
            var midArray = jsonNodeRoot?["data"]?["members"]?.AsArray();
            List<IGroupMember> result = [];
            // TODO: 非空断言没有做错误处理
            foreach (var memberJsonNode in midArray ?? [])
            {
                string Gender = memberJsonNode?["sex"]?.ToString()!;
                long JoinTime = (long)(memberJsonNode?["join_time"]?.GetValue<long>())!;
                long LastSpeakTime = (long)(memberJsonNode?["last_sent_time"]?.GetValue<long>())!;
                int LevelInGroup = (int)(memberJsonNode?["level"]?.GetValue<int>())!;
                string NameInGroup = memberJsonNode?["card"]?.ToString()!;
                string NickName = memberJsonNode?["nickname"]?.ToString()!;
                string role = memberJsonNode?["role"]?.ToString()!;
                long? ShutUpEndTime = memberJsonNode?["shut_up_end_time"]?.GetValue<long>();
                string title = memberJsonNode?["title"]?.ToString()!;
                int UserId = (int)(memberJsonNode?["user_id"]?.GetValue<int>())!;
                int GroupId = (int)(memberJsonNode?["group_id"]?.GetValue<int>())!;
                GroupMember m = new(Gender, JoinTime, LastSpeakTime, LevelInGroup, NameInGroup, NickName, role, ShutUpEndTime, title, UserId, GroupId);
                result.Add(m);
            }
            groupName = groupInfoProvider.GetGroupInfo(groupId).Name;
            return result;
        }

        string BuildRequestBody(string protocol, int groupId, string? next)
        {
            if (protocol is "One Bot 11" or "Milky")
                return $"{{\"group_id\":{groupId}}}";
            else if (protocol is "Satori")
            {
                if (next is null)
                    return $"{{\"guild_id\":{groupId}}}";
                else
                    return $"{{\"guild_id\":\"{groupId}\",\"next\":\"{next}\"}}";
            }
            else throw new ProtocolViolationException(ProtocolIsNotSupported);
        }
    }
}
