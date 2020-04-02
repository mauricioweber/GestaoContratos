using GestaoContratos.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoContratos.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Cliente")]
        public string ClientName { get; set; }

        [Required]
        [DisplayName("Tipo do Contrato")]
        public ContractType Type { get; set; }

        [Required]
        [DisplayName("Quantidade negociada")]
        [Range(1, int.MaxValue)]
        public int NegotiatedQuantity { get; set; }

        [Required]
        [DisplayName("Valor negociado")]
        [Range(0.0, double.MaxValue)]
        public decimal NegotiatedValue { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/yyyy}")]
        [DisplayName("Início do contrato")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("Duração em meses")]
        [Range(0, int.MaxValue)]
        public int Duration { get; set; }

        [DisplayName("Arquivo contrato")]
        public string File { get; set; }

    }
}
