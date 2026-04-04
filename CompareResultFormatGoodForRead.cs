using BillyNaCl.QQGroupToolkit.Interfaces;
using BillyNaCl.QQGroupToolkit.Interfaces.CompareResultFormatInterfaces;
using System.Text;

namespace BillyNaCl.QQGroupToolkit
{
    internal class CompareResultFormatGoodForRead : ICompareResultFormatGoodForRead
    {
        public string Foramt(
            ICompareResult result,
            bool jaccard,
            bool members,
            bool members_details)
        {
            string formatedResult = "";

            formatedResult += $"两个群聊共同成员的数量为：";
            formatedResult += result.GetCommonMembersCount();

            if (jaccard)
            {
                formatedResult += "\n\n";
                formatedResult += $"两个群聊的相似度(根据jaccard相似系数计算)为：";
                formatedResult += result.GetSimilarity();
            }

            if (members_details)
            {
                formatedResult += FormatMembers(result, true);
            }
            else if (members)
            {
                formatedResult += FormatMembers(result, false);
            }
            return formatedResult;
        }

        private string FormatMembers(ICompareResult result, bool details)
        {
            var sb = new StringBuilder();
            string Group1Name = result.GetGroup1Name();
            string Group2Name = result.GetGroup2Name();
            foreach (var member in result.GetCommonMembers())
            {
                sb.Append("\n\n");
                sb.Append(FormatMember(Group1Name, Group2Name, member, details));
            }
            return sb.ToString();
        }

        private string FormatMember(
            string Group1Name,
            string Group2Name,
            (IGroupMember inGroup1, IGroupMember inGroup2) member,
            bool details)
        {
            string formatedResult = "";
            formatedResult += "QQ号：";
            formatedResult += member.inGroup1.GetUserId() + '\n';
            formatedResult += "昵称：";
            formatedResult += member.inGroup1.GetNickname() + '\n';
            formatedResult += $"在群聊{Group1Name}中的昵称：";
            formatedResult += member.inGroup1.GetNameInGroup() + '\n';
            formatedResult += $"在群聊{Group2Name}中的昵称：";
            formatedResult += member.inGroup2.GetNameInGroup() + '\n';
            if (details)
            {
                formatedResult += $"性别：";
                formatedResult += member.inGroup1.GetGender() + '\n';
                formatedResult += $"加入群聊{Group1Name}的时间：";
                formatedResult += member.inGroup1.GetJoinTime()
                    .ToString("yyyy年MM月dd日HH:mm:ss") + '\n';
                formatedResult += $"加入群聊{Group2Name}的时间：";
                formatedResult += member.inGroup2.GetJoinTime()
                    .ToString("yyyy年MM月dd日HH:mm:ss") + '\n';
                formatedResult += $"群聊{Group1Name}中的等级：";
                formatedResult += member.inGroup1.GetLevelInGroup() + '\n';
                formatedResult += $"群聊{Group2Name}中的等级：";
                formatedResult += member.inGroup2.GetLevelInGroup() + '\n';
                formatedResult += $"群聊{Group1Name}中的专属头衔：";
                formatedResult += member.inGroup1.GetTitle() + '\n';
                formatedResult += $"群聊{Group2Name}中的专属头衔：";
                formatedResult += member.inGroup2.GetTitle() + '\n';
                formatedResult += $"群聊{Group1Name}中的权限等级：";
                formatedResult += member.inGroup1.GetRole() + '\n';
                formatedResult += $"群聊{Group2Name}中的权限等级：";
                formatedResult += member.inGroup2.GetRole() + '\n';
                formatedResult += $"群聊{Group1Name}中的最后一次发言时间：";
                formatedResult += member.inGroup1.GetLastSpeakTime()
                    .ToString("yyyy年MM月dd日HH:mm:ss") + '\n';
                formatedResult += $"群聊{Group2Name}中的最后一次发言时间：";
                formatedResult += member.inGroup2.GetLastSpeakTime()
                    .ToString("yyyy年MM月dd日HH:mm:ss") + '\n';
                if (member.inGroup1.GetShutUpEndTime() != null)
                {
                    formatedResult += $"该用户已被群聊{Group1Name}禁言直到";
                    formatedResult += member.inGroup1.GetShutUpEndTime().GetValueOrDefault()
                        .ToString("yyyy年MM月dd日HH:mm:ss") + '\n';
                }
                if (member.inGroup2.GetShutUpEndTime() != null)
                {
                    formatedResult += $"该用户已被群聊{Group2Name}禁言直到";
                    formatedResult += member.inGroup2.GetShutUpEndTime().GetValueOrDefault()
                        .ToString("yyyy年MM月dd日HH:mm:ss") + '\n';
                }
            }
            return formatedResult;
        }
    }
}
