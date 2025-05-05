using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public string Titel { get; set; } = string.Empty;

        [Display(Name = "Client")]
        public string Client { get; set; } = string.Empty;

        [Display(Name = "Beskrivning")]
        public string Beskrivning { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public ProjectStatus Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Budget")]
        public decimal Budget { get; set; }
    }

    public enum ProjectStatus
    {
        NotStarted,
        InProgress,
        Completed,
        OnHold,
        Cancelled
    }
}
