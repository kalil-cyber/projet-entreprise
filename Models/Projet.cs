using System;
using System.ComponentModel.DataAnnotations;

namespace mac.Models
{
    public class Projet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nom { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

