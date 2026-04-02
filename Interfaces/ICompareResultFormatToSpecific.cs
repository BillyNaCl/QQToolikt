namespace BillyNaCl.QQGroupToolkit.Interfaces
{
    internal interface ICompareResultFormatToSpecific
    {
        /// <summary>
        /// 将群聊比较结果格式化成字符串，并且已经明确目标格式
        /// </summary>
        /// <param name="result">群聊比较结果</param>
        /// <param name="jaccard">jaccard相似系数</param>
        /// <param name="members">是否展示所有群成员的QQ号</param>
        /// <param name="members_details">
        /// 是否展示所有群成员的详细信息（如果为true，会覆盖member）
        /// </param>
        string Foramt(ICompareResult result, bool jaccard, bool members, bool members_details);
    }
}
