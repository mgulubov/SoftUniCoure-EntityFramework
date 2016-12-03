namespace StudentSystemApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Services.Enums;

    [Table("Resources")]
    public class Resource
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("CourseId")]
        public int? CourseId { get; set; }

        [Column("Name")]
        [Required]
        [MaxLength(150, ErrorMessage = "Name cannot be longer than 150 characters.")]
        public string Name { get; set; }

        [Column("Url")]
        [Required]
        public string Url { get; set; }

        [Column("ResourceType")]
        [Required]
        public ResourceType ResourceType { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses { get; set; } = new HashSet<License>();
    }
}
