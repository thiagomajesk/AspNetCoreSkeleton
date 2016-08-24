namespace BootstrapProject.Web.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}