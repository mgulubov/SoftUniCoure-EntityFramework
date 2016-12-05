namespace FootballBetting.Services.Interfaces
{
    public interface IUser : IIdentifiable<int>
    {
        decimal Balance { get; }

        string Username { get; }

        string Password { get; }

        string Email { get; }

        string FullName { get; }
    }
}
