using System;

namespace FootballBetting.Services.Interfaces
{
    public interface IBet : IIdentifiable<int>
    {
        int UserId { get; }

        decimal BetMoney { get; }

        DateTime BetDateTime { get; }
    }
}
