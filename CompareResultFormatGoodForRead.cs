using BillyNaCl.QQGroupToolkit.Interfaces;
using BillyNaCl.QQGroupToolkit.Interfaces.CompareResultFormatInterfaces;
using BillyNaCl.StaticUtils.Long2Date;
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
                sb.Append($"\n\n两个群聊的相似度(根据jaccard相似系数计算)为：{result.GetSimilarity():P2}");
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
            var g1 = Group1Name;
            var g2 = Group2Name;
            var (m1, m2) = member;
            StringBuilder sb = new();
            sb.Append($"QQ号：{m1.GetUserId()}\n");
            sb.Append($"昵称：{m1.GetNickname()}\n");
            sb.Append($"在群聊{g1}中的昵称：{m1.GetNameInGroup()}\n");
            sb.Append($"在群聊{g2}中的昵称：{m2.GetNameInGroup()}\n");
            if (details)
            {
                sb.Append($"性别：{m1.GetGender()}\n");
                sb.Append($"加入群聊{g1}的时间：{m1.GetJoinTime().Long2Date_cn()}\n");
                sb.Append($"加入群聊{g2}的时间：{m2.GetJoinTime().Long2Date_cn()}\n");
                sb.Append($"群聊{g1}中的等级：{m1.GetLevelInGroup()}\n");
                sb.Append($"群聊{g2}中的等级：{m2.GetLevelInGroup()}\n");
                sb.Append($"群聊{g1}中的专属头衔：{m1.GetTitle()}\n");
                sb.Append($"群聊{g2}中的专属头衔：{m2.GetTitle()}\n");
                sb.Append($"群聊{g1}中的权限等级：{m1.GetRole()}\n");
                sb.Append($"群聊{g2}中的权限等级：{m2.GetRole()}\n");
                sb.Append($"群聊{g1}中的最后一次发言时间：{m1.GetLastSpeakTime().Long2Date_cn()}\n");
                sb.Append($"群聊{g2}中的最后一次发言时间：{m2.GetLastSpeakTime().Long2Date_cn()}\n");
                if (member.inGroup1.GetShutUpEndTime() != null)
                    sb.Append($"该用户已被群聊{g1}禁言直到{m1.GetShutUpEndTime().GetValueOrDefault().Long2Date_cn()}\n");
                if (member.inGroup2.GetShutUpEndTime() != null)
                    sb.Append($"该用户已被群聊{g2}禁言直到{m2.GetShutUpEndTime().GetValueOrDefault().Long2Date_cn()}\n");
            }
            return sb.ToString();
        }
    }
}
