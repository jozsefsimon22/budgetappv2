using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shared.Enums
{
    public enum TransactionFrequency
    {
        [Description("Yearly")]
        Yearly,
        
        // [Display(Name = "Monthly")]
        Monthly,
        
        // [Display(Name = "Weekly")]
        Weekly,

        // [Display(Name = "One Time")]
        OneTime
    }
}