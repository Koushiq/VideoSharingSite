namespace VideoSharingSite.Models
{
    public class UserViewModel : BaseModel
    {
        public UserViewModel()
        {
            
        }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
    }
}