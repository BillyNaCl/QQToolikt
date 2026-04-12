namespace BillyNaCl.QQGroupToolkit
{
    internal record struct GroupInfo(
        int ID,
        string Name,
        int MembersCount,
        int MaxMembersCount,
        string ReMarkrem,
        long CreatedTime,
        string Description,
        string Question,
        string Announcement
    );
}
