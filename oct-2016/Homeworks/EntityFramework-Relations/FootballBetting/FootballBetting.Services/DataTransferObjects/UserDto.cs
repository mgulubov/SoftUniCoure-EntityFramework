namespace FootballBetting.Services.DataTransferObjects
{
    using Interfaces;

    public class UserDto : IUser
    {
        public UserDto(
            int id,
            decimal balance,
            string username,
            string password,
            string email,
            string fullName)
        {
            this.Id = id;
            this.Balance = balance;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.FullName = fullName;
        }

        public int Id { get; }

        public decimal Balance { get; }

        public string Username { get; }

        public string Password { get; }

        public string Email { get; }

        public string FullName { get; }
    }
}
