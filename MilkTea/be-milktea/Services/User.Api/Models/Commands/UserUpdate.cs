namespace User.Api.Models.Commands
{
    public class UserUpdate
    {
        public string LoginName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool UserStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserGroupCode { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
