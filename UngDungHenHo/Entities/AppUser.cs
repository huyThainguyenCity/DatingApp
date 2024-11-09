namespace UngDungHenHo.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required byte[] PasswordHard { get; set; }
        public required byte[] PasswordSalt { get; set; }
    }
}
