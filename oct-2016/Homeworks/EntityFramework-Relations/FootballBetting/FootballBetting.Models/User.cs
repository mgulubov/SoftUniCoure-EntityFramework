namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Services.Interfaces;

    [Table("Users")]
    public class User : IUser
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Username")]
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Username { get; set; }

        [Column("Password")]
        [Required]
        [MaxLength(500, ErrorMessage = "Password cannot be longer than 500 characters.")]
        public string Password { get; set; }

        [Column("Email")]
        [Required]
        [MaxLength(200, ErrorMessage = "Email cannot be longer than 200 characters.")]
        public string Email { get; set; }
        
        [Column("FullName")]
        [MaxLength(500, ErrorMessage = "FullName cannot be longer than 500 characters.")]
        public string FullName { get; set; }

        [Column("Balance")]
        [Required]
        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();
    }
}
