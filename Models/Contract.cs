using GestaoContratos.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GestaoContratos.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        public string ClientName { get; set; }
        public ContractType Type { get; set; }

        public int NegotiatedQuantity { get; set; }

        public decimal NegotiatedValue { get; set; }

        public DateTime StartDate { get; set; }

        public int Duration { get; set; }
        public string FileName { get; set; }

        public byte[] File { get; set; }
    }
}
