namespace WebApplication1
{
    public class Login
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
