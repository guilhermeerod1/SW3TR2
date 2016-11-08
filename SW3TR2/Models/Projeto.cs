using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SW3TR2.Models
{
    [Table("Projetos")]
    public class Projeto
    {
        [Key]
        public long Id { get; set; }

        [Required][MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }

        [Required]
        public DateTime Emissao { get; set; }

        public virtual ICollection<Plano> Planos { get; set; }
    }
}