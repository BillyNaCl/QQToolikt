namespace BillyNaCl.QQGroupToolkit.Interfaces
{
    internal interface IGroupMember
    {
        /// <summary>
        /// 群号
        /// </summary>
        long GrtGroupId();

        /// <summary>
        /// QQ号
        /// </summary>
        long GetUserId();

        /// <summary>
        /// 用户昵称
        /// </summary>
        string GetNickname();

        /// <summary>
        /// 性别
        /// </summary>
        string GetGender();

        /// <summary>
        /// 用户在群内的昵称
        /// </summary>
        string GetNameInGroup();

        /// <summary>
        /// 专属头衔
        /// </summary>
        string GetTitle();

        /// <summary>
        /// 用户权限等级
        /// </summary>
        string GetRole();

        /// <summary>
        /// 用户在群内的等级
        /// </summary>
        /// <returns></returns>
        int GetLevelInGroup();

        /// <summary>
        /// 用户加入时间（Unix时间戳）（单位：秒）
        /// </summary>
        long GetJoinTime();

        /// <summary>
        /// 最后发言时间（Unix时间戳）（单位：秒）
        /// </summary>
        long GetLastSpeakTime();

        /// <summary>
        /// 禁言结束时间（Unix时间戳）（单位：秒）（如果没有禁言，则返回null）
        /// </summary>
        long? GetShutUpEndTime();
    }
}
