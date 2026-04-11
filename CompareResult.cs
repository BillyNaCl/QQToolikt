using BillyNaCl.QQGroupToolkit.Interfaces;

namespace BillyNaCl.QQGroupToolkit
{
    internal sealed record CompareResult : ICompareResult
    {
        List<(IGroupMember inGroup1, IGroupMember inGroup2)> CommonMembers { get; init; }
        int CommonMembersCount { get; init; }
        string Group1Name { get; init; }
        string Group2Name { get; init; }
        float Similarity { get; init; }

        public CompareResult(List<(IGroupMember inGroup1, IGroupMember inGroup2)> commonMembers, int commonMembersCount, string group1Name, string group2Name, float similarity)
        {
            CommonMembers = commonMembers;
            CommonMembersCount = commonMembersCount;
            Group1Name = group1Name;
            Group2Name = group2Name;
            Similarity = similarity;
        }

        public List<(IGroupMember inGroup1, IGroupMember inGroup2)> GetCommonMembers() => CommonMembers;

        public int GetCommonMembersCount() => CommonMembersCount;

        public string GetGroup1Name() => Group1Name;

        public string GetGroup2Name() => Group2Name;

        public float GetSimilarity() => Similarity;
    }
}
