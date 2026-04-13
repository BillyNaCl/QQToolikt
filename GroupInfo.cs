namespace BillyNaCl.QQGroupToolkit
{
    internal record struct GroupInfo(
        int ID,
        string Name,
        int MemberCount,
        int MaxMemberCount,
        string Remark,
        long CreatedTime,
        string Description,
        string Question,
        string Announcement
    );
}
