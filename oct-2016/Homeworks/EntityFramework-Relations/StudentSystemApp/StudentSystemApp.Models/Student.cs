namespace StudentSystemApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Students")]
    public class Student
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        [MaxLength(150, ErrorMessage = "Name cannot be longer than 150 characters.")]
        public string Name { get; set; }

        [Column("PhoneNumber")]
        [MaxLength(100, ErrorMessage = "Phone number cannot be longer than 150 characters.")]
        public string PhoneNumber { get; set; }

        [Column("RegistrationDate")]
        public DateTime RegistrationDate { get; set; }

        [Column("Birthday")]
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
