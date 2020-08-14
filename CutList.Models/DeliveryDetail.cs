using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CutList.Models
{
    public class DeliveryDetail
    {
        [Key]
        public int DeliveryId { get; set; }

        [Display(Name = "Heat Pallet")]
        public bool HeatTreatedPallet { get; set; }

        [Display(Name = "Foil Wraped")]
        public bool FoilWrapped { get; set; }
        public bool Crated { get; set; }

        [Display(Name = "Sea Freight")]
        public bool SeaFreight { get; set; }
        [Display(Name = "Air Freight")]
        public bool AirFreight { get; set; }

    }
}
