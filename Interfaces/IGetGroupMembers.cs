namespace BillyNaCl.QQGroupToolkit.Interfaces
{
    /// <summary>
    /// 获取群成员列表的接口
    /// </summary>
    internal interface IGetGroupMembers
    {
        /// <summary>
        /// 获取成员列表
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <returns>成员列表</returns>
        List<IGroupMember> GetGroupMembers(int groupId);

        /// <summary>
        /// 获取成员列表，同时获取群名
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <param name="groupName">群名</param>
        /// <returns>成员列表</returns>
        List<IGroupMember> GetGroupMembers(int groupId, out string groupName);
    }
}
