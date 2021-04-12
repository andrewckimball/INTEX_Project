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
            FilterString = filterstring ?? "------------";
            string[] filters = FilterString.Split('-');
            Square = filters[0];
            Area = filters[1];
            PhotoTaken = filters[2];
            BurialGoods = filters[3];
            Sex = filters[4];
            HairColor = filters[5];
            FaceBundle = filters[6];
            HeadDirection = filters[7];
            EstimatedAge = filters[8];
            MinLength = filters[9];
            MaxLength = filters[10];
            MinDepth = filters[11];
            MaxDepth = filters[12];
        }

        public string FilterString { get; }

        // Filter columns
        public string Square { get; }
        public string Area { get; }
        public string MinLength { get; }
        public string MaxLength { get; }
        public string MinDepth { get; }
        public string MaxDepth { get; }
        public string PhotoTaken { get; }
        public string BurialGoods { get; }
        public string Sex { get; }
        public string HairColor { get; }
        public string FaceBundle { get; }
        public string HeadDirection { get; }
        public string EstimatedAge { get; }


        public bool HasSquare => Square.ToLower() != "";
        public bool HasArea => Area.ToLower() != "";
        public bool HasMinLength => MinLength.ToLower() != "";
        public bool HasMaxLength => MaxLength.ToLower() != "";
        public bool HasMinDepth => MinDepth.ToLower() != "";
        public bool HasMaxDepth => MaxDepth.ToLower() != "";
        public bool HasPhotoTaken => PhotoTaken.ToLower() != "";
        public bool HasBurialGoods => BurialGoods.ToLower() != "";
        public bool HasSex => Sex.ToLower() != "";
        public bool HasHairColor => HairColor.ToLower() != "";
        public bool HasFaceBundle => FaceBundle.ToLower() != "";
        public bool HasHeadDirection => HeadDirection.ToLower() != "";
        public bool HasEstimatedAge => EstimatedAge.ToLower() != "";

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
