namespace User.Api.Models.Commands
{
    public class GroupUpdate
	{
        public string UserGroupCode { get; set; }
        public string UserGroupName { get; set; }
        public bool UserGroupStatus { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}

