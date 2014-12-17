using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace community_house.Models
{
    public class Favourite
    {
        public int FavouriteID { get; set; }

        public int HouseID { get; set; }
        public virtual House House { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}