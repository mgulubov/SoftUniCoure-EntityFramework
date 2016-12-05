namespace FootballBetting.Services.DataTransferObjects
{
    using System;

    using Interfaces;

    public class BetDto : IBet
    {
        public BetDto(int id, int userId, decimal betMoney, DateTime betDateTime)
        {
            this.Id = id;
            this.UserId = userId;
            this.BetMoney = betMoney;
            this.BetDateTime = betDateTime;
        }

        public int Id { get; }

        public int UserId { get; }

        public decimal BetMoney { get; }

        public DateTime BetDateTime { get; }
    }
}
