namespace StudentSystemApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Services.Enums;

    [Table("Homeworks")]
    public class Homework
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("CourseId")]
        public int CourseId { get; set; }

        [Column("StudentId")]
        public int StudentId { get; set; }

        [Column("Content")]
        [Required]
        public string Content { get; set; }

        [Column("ContentType")]
        [Required]
        public HomeworkContentType ContentType { get; set; }

        [Column("SubmissionDate")]
        public DateTime SubmissionDate { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
