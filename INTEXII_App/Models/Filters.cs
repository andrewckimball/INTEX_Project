using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEXII_App.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all-all-all-all-all-all-all-all-all";
            string[] filters = FilterString.Split('-');
            Square = filters[0];
            Area = filters[1];
            Length = filters[2];
            Depth = filters[3];
            PhotoTaken = filters[4];
            BurialGoods = filters[5];
            Sex = filters[6];
            HairColor = filters[7];
            FaceBundle = filters[8];
            HeadDirection = filters[9];
            EstimatedAge = filters[10];
        }

        public string FilterString { get; }

        // Filter columns
        public string Square { get; }
        public string Area { get; }
        public string Length { get; }
        public string Depth { get; }
        public string PhotoTaken { get; }
        public string BurialGoods { get; }
        public string Sex { get; }
        public string HairColor { get; }
        public string FaceBundle { get; }
        public string HeadDirection { get; }
        public string EstimatedAge { get; }


        public bool HasSquare => Square.ToLower() != "all";
        public bool HasArea => Area.ToLower() != "all";
        public bool HasLength => Depth.ToLower() != "all";
        public bool HasPhotoTaken => PhotoTaken.ToLower() != "all";
        public bool HasBurialGoods => BurialGoods.ToLower() != "all";
        public bool HasSex => Sex.ToLower() != "all";
        public bool HasHairColor => HairColor.ToLower() != "all";
        public bool HasFaceBundle => FaceBundle.ToLower() != "all";
        public bool HasHeadDirection => HeadDirection.ToLower() != "all";
        public bool HasEstimatedAge => EstimatedAge.ToLower() != "all";

        public static Dictionary<string, string> DueFilterValues =>
            new Dictionary<string, string>
            {
                {"future", "Future" },
                {"past", "Past" },
                {"today", "Today" }
            };

        //public bool IsPast => Due.ToLower() == "past";
        //public bool IsFuture => Due.ToLower() == "future";
        //public bool IsToday => Due.ToLower() == "today";
    }
}
