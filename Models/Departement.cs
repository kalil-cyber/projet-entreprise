using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mac.Models
{
    public class Departement
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Salarie> Salaries { get; set; } = new List<Salarie>();
    }
}

