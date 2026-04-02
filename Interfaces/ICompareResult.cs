namespace BillyNaCl.QQGroupToolkit.Interfaces
{
    internal interface ICompareResult
    {
        /// <summary>
        /// 计算两个群聊成员组成的相似度
        /// </summary>
        /// <remarks>
        /// 通过Jaccard相似系数计算
        /// </remarks>
        /// <returns>Jaccard相似系数</returns>
        float GetSimilarity();

        /// <summary>
        /// 共同成员的数量
        /// </summary>
        int GetCommonMembersCount();

        /// <summary>
        /// 共同成员的列表
        /// </summary>
        List<IGroupMember> GetCommonMembers();
    }
}
