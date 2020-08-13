using CutList.DataAccess.Data.Repository.IRepository;
using CutList.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutList.DataAccess.Data.Repository
{
    public class DeliveryRepository : Repository<DeliveryDetail>, IDeliveryRepository        //MAKE NOTES ON THIS
    {
        //need database object
        private readonly ApplicationDbContext _db;

        //constructor to retrieve the database object
        public DeliveryRepository(ApplicationDbContext db) : base(db)        //exspecting parameter in constructor can now retrieve from implementing base(db)
        {
            _db = db;
        }

        //to populate my dropdown
        public IEnumerable<SelectListItem> GetDeliveryDetailListForDropDown()
        {
            return _db.DeliveryDetails.Select(d => new SelectListItem()
            {
                Text = d.DeliveryId.ToString(),
                Value = d.DeliveryId.ToString()
            });
        }

        public void Update(DeliveryDetail deliveryDetail)
        {
            var objectFromDb = _db.DeliveryDetails.FirstOrDefault(d => d.DeliveryId == deliveryDetail.DeliveryId);

            objectFromDb.HeatTreatedPallet = deliveryDetail.HeatTreatedPallet;
            objectFromDb.FoilWrapped = deliveryDetail.FoilWrapped;
            objectFromDb.Crated = deliveryDetail.Crated;
            objectFromDb.SeaFreight = deliveryDetail.SeaFreight;
            objectFromDb.AirFreight = deliveryDetail.AirFreight;

            _db.SaveChanges();

        }
    }
}
