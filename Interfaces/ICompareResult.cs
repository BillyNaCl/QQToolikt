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
        List<(IGroupMember inGroup1, IGroupMember inGroup2)> GetCommonMembers();

        /// <summary>
        /// 获取群聊1的名称
        /// </summary>
        /// <returns>群聊1的名称</returns>
        string GetGroup1Name();

        /// <summary>
        /// 获取群聊2的名称
        /// </summary>
        /// <returns>群聊2的名称</returns>
        string GetGroup2Name();
    }
}
