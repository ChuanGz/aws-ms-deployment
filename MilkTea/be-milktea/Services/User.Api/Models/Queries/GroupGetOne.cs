using System;
namespace User.Api.Models.Queries
{
	public class GroupGetOne
	{
        public int UserGroupId { get; set; }
        public string UserGroupCode { get; set; }
        public string UserGroupName { get; set; }
        public bool UserGroupStatus { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}

