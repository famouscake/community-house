using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace community_house.Models
{
    public class House
    {
        public int HouseID { get; set; }
        
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public List<Picture> Pictures { get; set; }

        public double Price { get; set; }
        public double Area { get; set; }
        public string City { get; set; }

        public string Address { get; set; }
    }
}