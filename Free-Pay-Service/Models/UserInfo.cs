namespace FreePayService.Models
{
    public class UserInfo
    {
        public UserInfo() { }
        public UserInfo(string name)
        {
            Name = name;
        }
        public int UserInfoId { get; set; }
        public string Name { get; set; }
    }
}
