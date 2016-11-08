using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SW3TR2.Models
{
    [Table("Casos")]
    public class Caso
    {
        [Key]
        public long Id { get; set; }

        [Required][MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }

        [Required][MaxLength(100)]
        public string PreCondicoes { get; set; }

        [Required][MaxLength(1024)]
        public string Passos { get; set; }

        [Required][MaxLength(100)]
        public string PosCondicoes { get; set; }

        [Required]
        public Prioridade Prioridade { get; set; }

        [Required]
        public Status Status { get; set; }

        public long Execucao { get; set; }

        [Required]
        public int Versao { get; set; }

        [Required]
        public DateTime Emissao { get; set; }
        
        public DateTime Prazo { get; set; }

        public DateTime Fechamento { get; set; }

        [Required]
        public bool Automatizado { get; set; }

        [MaxLength(1024)]
        public string Observacoes { get; set; }
        
        public Plano Plano { get; set; }

        public long? PlanoId { get; set; }
    }
}