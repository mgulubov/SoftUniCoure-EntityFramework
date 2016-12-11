namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Products")]
    public class Product
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        [MinLength(3, ErrorMessage = "Name cannot be less than 3 characters.")]
        [MaxLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
        public string Name { get; set; }

        [Column("Price")]
        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "Price cannot be negative")]
        public decimal Price { get; set; }

        [Column("SellerId")]
        public int SellerId { get; set; }

        [Column("BuyerId")]
        public int? BuyerId { get; set; }

        [ForeignKey("SellerId")]
        [InverseProperty("SoldProducts")]
        public virtual User Seller { get; set; }

        [ForeignKey("BuyerId")]
        [InverseProperty("BoughtProducts")]
        public virtual User Buyer { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}
