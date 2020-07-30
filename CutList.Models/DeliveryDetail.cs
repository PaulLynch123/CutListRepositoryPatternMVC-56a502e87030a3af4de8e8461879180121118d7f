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

        public bool HeatTreatedPallet { get; set; }

        public bool FoilWrapped { get; set; }
        public bool Crated { get; set; }

        public bool SeaFreight { get; set; }
        public bool AirFreight { get; set; }

    }
}
