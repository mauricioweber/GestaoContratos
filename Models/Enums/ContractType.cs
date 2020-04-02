using System.ComponentModel.DataAnnotations;

namespace GestaoContratos.Models.Enums
{
    public enum ContractType
    {
        [Display(Name = "Venda")]
        Sell,
        [Display(Name = "Compra")]
        Buy

    }
}
