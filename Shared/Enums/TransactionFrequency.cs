using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shared.Enums
{
    public enum TransactionFrequency
    {
        [Description("Yearly")]
        Yearly,
        Monthly,
        Weekly,
        [Display(Name = "One Time")]
        OneTime
    }
}