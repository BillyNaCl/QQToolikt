using BillyNaCl.DIContainer.Core.StaticGlobalDIContainerGateway;
using BillyNaCl.QQGroupToolkit.Interfaces;
using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BillyNaCl.QQGroupToolkit
{
    internal class DataFetcher : IGetGroupMembers, IGetGroupInfo
    {
        IHTTPClientService httpClientService = DI.GetService<IHTTPClientService>();
        IURLBuilder urlBuilder = DI.GetService<IURLBuilder>();
        IConfigProvider configProvider = DI.GetService<IConfigProvider>();
        // TODO: 此处是自身的方法，应该改为直接调用以避免额外创建一个对象
        // BLOCKER: 恶性bug，依赖自身会导致DI容器循环依赖导致无限递归引发栈溢出！
        IGetGroupInfo groupInfoProvider = DI.GetService<IGetGroupInfo>();
        const string ProtocolIsNotSupported = "Protocol is not supported. Only \"One Bot 11\", \"Satori\", and \"Milky\" are supported.";

        // TODO: 这个才应该是基础方法，现在的调用方式会导致额外发送一次HTTP请求去获取群信息，即使没有使用
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
            string url = urlBuilder.BuildLocalHostURL(protocol, 3000, basePath, endPoint);
            string body = BuildRequestBody(protocol, groupId, null);
            //TODO: 从这里开始到解析JSON的部分应该抽象出来，以便于其他地方复用
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

        static string BuildRequestBody(string protocol, int groupId, string? next)
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

        public GroupInfo GetGroupInfo(int groupId)
        {
            var protocol = configProvider.GetProtocol();
            var port = configProvider.GetPort();
            //TODO: 这里记得适配其它协议
            var basePath = "api";
            var endpoint = "get_group_info";
            var url = urlBuilder.BuildLocalHostURL(protocol, port, basePath, endpoint);
            var body = BuildRequestBody(protocol, groupId, null);
            var response = httpClientService.POST(url, body).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jsonNodeRoot = JsonNode.Parse(responseBody);
            var groupInfoJsonNode = jsonNodeRoot?["data"]?["group"]!;
            int groupID = (int)(groupInfoJsonNode["group_id"]?.GetValue<int>())!;
            string groupName = groupInfoJsonNode["group_name"]?.ToString()!;
            int memberCount = (int)(groupInfoJsonNode["member_count"]?.GetValue<int>())!;
            int maxMemberCount = (int)(groupInfoJsonNode["max_member_count"]?.GetValue<int>())!;
            string remark = groupInfoJsonNode["remark"]?.ToString()!;
            long createdTime = (long)(groupInfoJsonNode["created_time"]?.GetValue<long>())!;
            string description = groupInfoJsonNode["description"]?.ToString()!;
            string question = groupInfoJsonNode["question"]?.ToString()!;
            string announcement = groupInfoJsonNode["announcement"]?.ToString()!;
            GroupInfo groupInfo = new()
            {
                ID = groupID,
                Name = groupName,
                MemberCount = memberCount,
                MaxMemberCount = maxMemberCount,
                Remark = remark,
                CreatedTime = createdTime,
                Description = description,
                Question = question,
                Announcement = announcement
            };
            return groupInfo;
        }
    }
}
