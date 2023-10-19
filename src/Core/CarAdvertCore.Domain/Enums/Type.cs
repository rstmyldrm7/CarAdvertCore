using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertCore.Domain.Enums
{
    public enum GearType
    {

        [Display(Name = "Yarı Otomatik")]
        Semiautomatic = 0,

        [Display(Name = "Düz")]
        Manuel = 1,

        [Display(Name = "Otomatik")]
        Automatic = 2
    }

    public enum FuelType
    {
        [Display(Name = "LPG & Benzin")]
        GasolineAndLPG = 0,

        [Display(Name = "Dizel")]
        Diesel = 1,

        [Display(Name = "Benzin")]
        Gasoline = 2
    }
    public enum SortField
    {
        Price,
        Year,
        Km
    }

    public enum SortDirection
    {
        HighToLow,
        LowToHigh
    }

}
