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
            StringBuilder sb = new();
            sb.Append($"两个群聊共同成员的数量为：{result.GetCommonMembersCount()}");
            if (jaccard)
                sb.Append($"\n\n两个群聊的相似度(根据jaccard相似系数计算)为：{result.GetSimilarity()}");
            if (members_details || members)
                sb.Append(FormatMembers(result, members_details));
            return sb.ToString();
        }

        private static string FormatMembers(ICompareResult result, bool details)
        {
            StringBuilder sb = new();
            string Group1Name = result.GetGroup1Name();
            string Group2Name = result.GetGroup2Name();
            foreach (var member in result.GetCommonMembers())
            {
                sb.Append("\n\n");
                sb.Append(FormatMember(Group1Name, Group2Name, member, details));
            }
            return sb.ToString();
        }

        private static string FormatMember(
            string Group1Name,
            string Group2Name,
            (IGroupMember inGroup1, IGroupMember inGroup2) member,
            bool details)
        {
            StringBuilder sb = new();
            sb.Append($"QQ号：{member.inGroup1.GetUserId()}\n");
            sb.Append($"昵称：{member.inGroup1.GetNickname}\n");
            sb.Append($"在群聊{Group1Name}中的昵称：{member.inGroup1.GetNameInGroup()}\n");
            sb.Append($"在群聊{Group2Name}中的昵称：{member.inGroup2.GetNameInGroup()}\n");
            if (details)
            {
                sb.Append($"性别：{member.inGroup1.GetGender()}\n");
                sb.Append($"加入群聊{Group1Name}的时间：{member.inGroup1.GetJoinTime():yyyy年MM月dd日HH:mm:ss}\n");
                sb.Append($"加入群聊{Group2Name}的时间：{member.inGroup2.GetJoinTime():yyyy年MM月dd日HH:mm:ss}\n");
                sb.Append($"群聊{Group1Name}中的等级：{member.inGroup1.GetLevelInGroup()}\n");
                sb.Append($"群聊{Group2Name}中的等级：{member.inGroup2.GetLevelInGroup()}\n");
                sb.Append($"群聊{Group1Name}中的专属头衔：{member.inGroup1.GetTitle()}\n");
                sb.Append($"群聊{Group2Name}中的专属头衔：{member.inGroup2.GetTitle()}\n");
                sb.Append($"群聊{Group1Name}中的权限等级：{member.inGroup1.GetRole()}\n");
                sb.Append($"群聊{Group2Name}中的权限等级：{member.inGroup2.GetRole()}\n");
                sb.Append($"群聊{Group1Name}中的最后一次发言时间：{member.inGroup1.GetLastSpeakTime():yyyy年MM月dd日HH:mm:ss}\n");
                sb.Append($"群聊{Group2Name}中的最后一次发言时间：{member.inGroup2.GetLastSpeakTime():yyyy年MM月dd日HH:mm:ss}\n");
                if (member.inGroup1.GetShutUpEndTime() != null)
                    sb.Append($"该用户已被群聊{Group1Name}禁言直到{member.inGroup1.GetShutUpEndTime().GetValueOrDefault():yyyy年MM月dd日HH:mm:ss}\n");
                if (member.inGroup2.GetShutUpEndTime() != null)
                    sb.Append($"该用户已被群聊{Group2Name}禁言直到{member.inGroup2.GetShutUpEndTime().GetValueOrDefault():yyyy年MM月dd日HH:mm:ss}\n");
            }
            return sb.ToString();
        }
    }
}
