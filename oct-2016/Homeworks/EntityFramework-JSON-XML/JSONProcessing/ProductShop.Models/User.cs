namespace ProductShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public class User
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Age")]
        [Range(minimum: 0, maximum: Int32.MinValue, ErrorMessage = "Age cannot be negative.")]
        public int? Age { get; set; }

        [Column("FirstName")]
        [MaxLength(100, ErrorMessage = "FirstName cannot be longer than 100 characters.")]
        public string FirstName { get; set; }

        [Column("LastName")]
        [Required]
        [MinLength(3, ErrorMessage = "LastName cannnot be < 3 characters.")]
        [MaxLength(100, ErrorMessage = "LastName cannot be longer than 100 characters.")]
        public string LastName { get; set; }

        public virtual ICollection<Product> SoldProducts { get; set; } = new HashSet<Product>();

        public virtual ICollection<Product> BoughtProducts { get; set; } = new HashSet<Product>();

        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();

        public virtual ICollection<User> Friends { get; set; } = new HashSet<User>();
    }
}
