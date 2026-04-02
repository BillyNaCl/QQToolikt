namespace BillyNaCl.QQGroupToolkit.Interfaces
{
    internal interface IQQUser
    {
        /// <summary>
        /// 昵称
        /// </summary>
        string GetNickname();

        /// <summary>
        /// QID
        /// </summary>
        string GetQID();

        /// <summary>
        /// 年龄
        /// </summary>
        int GetAge();

        /// <summary>
        /// 性别
        /// </summary>
        string GetGender();

        /// <summary>
        /// 备注
        /// </summary>
        string GetRemark();

        /// <summary>
        /// 个性签名
        /// </summary>
        string GetBio();

        /// <summary>
        /// 等级
        /// </summary>
        string GetLevel();

        /// <summary>
        /// 城市
        /// </summary>
        string GetCountry();

        /// <summary>
        /// 城市
        /// </summary>
        string GetCity();

        /// <summary>
        /// 学校
        /// </summary>
        string GetSchool();
    }
}
