using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mac.Models
{
    public class Salarie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Nom { get; set; } = string.Empty;

        [Required]
        [StringLength(120)]
        public string Prenom { get; set; } = string.Empty;

        [Range(18, 100)]
        public int Age { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Salaire { get; set; }

        public int DepartementId { get; set; }
        public Departement? Departement { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

