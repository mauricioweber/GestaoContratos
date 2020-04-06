using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GestaoContratos.Models.Enums;
using Microsoft.AspNetCore.Http;

namespace GestaoContratos.Models
{
    public class ContractViewModel
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
        [DataType(DataType.Currency)]
        [DisplayName("Valor negociado")]
        [Range(0.0, double.MaxValue)]
        public decimal NegotiatedValue { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Início do contrato")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Duration)]
        [DisplayName("Duração em meses")]
        [Range(0, int.MaxValue)]
        public int Duration { get; set; }

        public string FileName { get; set; }
        //[Display(Name = "Add a picture")]
        //[DataType(DataType.Upload)]
        //[FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp,svg")]
        //[DataType(DataType.Upload)]
        //[FileExtensions(Extensions = ".pdf", ErrorMessage = "Incorrect file format")]
        [DisplayName("Arquivo contrato")]
        public IFormFile File { get; set; }
    }
}
