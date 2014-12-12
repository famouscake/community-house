using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace community_house.Models
{
    public class Picture
    {
        public int PictureID { get; set; }

        public string FileName { get; set; }

        public int HouseID { get; set; }

        public House House { get; set; }

    }
}