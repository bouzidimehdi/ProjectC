namespace WebApplication1.Data
{
    public class Role
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string User_role { get; set; }
    }
}