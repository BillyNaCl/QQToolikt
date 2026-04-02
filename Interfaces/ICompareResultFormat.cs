namespace BillyNaCl.QQGroupToolkit.Interfaces
{
    internal interface ICompareResultFormat
    {
        /// <summary>
        /// 将群聊比较结果格式化成字符串
        /// </summary>
        /// <param name="result">群聊比较结果</param>
        /// <param name="jaccard">jaccard相似系数</param>
        /// <param name="members">是否展示所有群成员的QQ号</param>
        /// <param name="members_details">
        /// 是否展示所有群成员的详细信息（如果为true，会覆盖member）
        /// </param>
        /// <param name="format">
        /// 格式化的方式<br/>
        /// json, xml, yml, gfr (默认: gfr)<br/>
        /// gfr 表示 "Good for read"（适合人类阅读的格式）
        /// </param>
        string Format(
            ICompareResult result,
            bool jaccard,
            bool members,
            bool members_details,
            string format);
    }
}
