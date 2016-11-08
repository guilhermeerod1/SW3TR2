using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SW3TR2.Models
{
    [Table("Planos")]
    public class Plano
    {
        [Key]
        public long Id { get; set; }

        [Required][MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public Prioridade Prioridade { get; set; }

        [Required]
        public DateTime Emissao { get; set; }

        public DateTime Prazo { get; set; }

        public DateTime Fechamento { get; set; }
        
        public Projeto Projeto { get; set; }

        public long? ProjetoId { get; set; }

        public virtual ICollection<Caso> Casos { get; set; }
    }
}