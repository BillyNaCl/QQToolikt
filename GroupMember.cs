using BillyNaCl.QQGroupToolkit.Interfaces;

namespace BillyNaCl.QQGroupToolkit
{
    internal sealed record GroupMember : IGroupMember
    {
        string Gender { get; init; }
        long JoinTime { get; init; }
        long LastSpeakTime { get; init; }
        int LevelInGroup { get; init; }
        string NameInGroup { get; init; }
        string Nickname { get; init; }
        string Role { get; init; }
        long? ShutUpEndTime { get; init; }
        string Title { get; init; }
        int UserId { get; init; }
        int GroupId { get; init; }

        public GroupMember(string gender, long joinTime, long lastSpeakTime, int levelInGroup, string nameInGroup, string nickname, string role, long? shutUpEndTime, string title, int userId, int groupId)
        {
            Gender = gender;
            JoinTime = joinTime;
            LastSpeakTime = lastSpeakTime;
            LevelInGroup = levelInGroup;
            NameInGroup = nameInGroup;
            Nickname = nickname;
            Role = role;
            ShutUpEndTime = shutUpEndTime;
            Title = title;
            UserId = userId;
            GroupId = groupId;
        }

        public string GetGender() => Gender;

        public long GetJoinTime() => JoinTime;

        public long GetLastSpeakTime() => LastSpeakTime;

        public int GetLevelInGroup() => LevelInGroup;

        public string GetNameInGroup() => NameInGroup;

        public string GetNickname() => Nickname;

        public string GetRole() => Role;

        public long? GetShutUpEndTime() => ShutUpEndTime;

        public string GetTitle() => Title;

        public int GetUserId() => UserId;

        public int GrtGroupId() => GroupId;
    }
}
