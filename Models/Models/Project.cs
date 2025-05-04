using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models
{
    public enum ProjectStatus { Startad, Slutförd }

    public class Project
    {
        public int Id { get; set; }

        [Required]
       public string Titel { get; set; } = string.Empty;
public string Beskrivning { get; set; } = string.Empty;


        public DateTime SkapadDatum { get; set; } = DateTime.Now;

        public ProjectStatus Status { get; set; } = ProjectStatus.Startad;
    }
    
}
