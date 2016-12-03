namespace StudentSystemApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Courses")]
    public class Course
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Price")]
        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public decimal Price { get; set; }

        [Column("Description")]
        [Required]
        [MaxLength(150, ErrorMessage = "Name cannot be longer than 150 characters.")]
        public string Name { get; set; }

        [Column("CoursesDescription")]
        [MaxLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
        public string CoursesDescription { get; set; }

        [Column("StartDate")]
        public DateTime StartDate { get; set; }

        [Column("EndDate")]
        public DateTime EndDate { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public virtual ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();

        public virtual ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();
    }
}
