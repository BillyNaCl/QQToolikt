using BillyNaCl.QQGroupToolkit.Interfaces;
using BillyNaCl.DIContainer.Core.StaticGlobalDIContainerGateway;

namespace BillyNaCl.QQGroupToolkit
{
    internal class QQGroupComparator : ICompare
    {
        readonly IGetGroupMembers getGroupMembers = DI.GetService<IGetGroupMembers>();

        public ICompareResult Compare(int GroupID1, int GroupID2)
        {
            var groupMembers1 = getGroupMembers.GetGroupMembers(GroupID1, out string group1Name);
            var groupMembers2 = getGroupMembers.GetGroupMembers(GroupID2, out string group2Name);
            List<(IGroupMember, IGroupMember)> commonMembers = groupMembers1
                .Join(
                    groupMembers2, 
                    gm1 => gm1.GetUserId(), 
                    gm2 => gm2.GetUserId(), 
                    (gm1, gm2) => (gm1, gm2))
                .ToList();
            int commonMembersCount = commonMembers.Count;
            int allMemberCount = groupMembers1.Count + groupMembers2.Count - commonMembersCount;
            float jaccardSimilarity = commonMembersCount / (float)allMemberCount;
            ICompareResult result = new CompareResult(commonMembers, commonMembersCount, group1Name, group2Name, jaccardSimilarity);
            return result;
        }
    }
}
