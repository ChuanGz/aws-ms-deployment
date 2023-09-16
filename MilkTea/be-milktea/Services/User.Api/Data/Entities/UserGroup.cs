namespace User.Api.Data.Entities
{
    public class UserGroup
    {
        public int UserGroupId { get; set; }
        public string UserGroupCode { get; set; }
        public string UserGroupName { get; set; }
        public bool UserGroupStatus { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
