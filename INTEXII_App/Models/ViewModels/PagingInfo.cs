using System;
namespace INTEXII_App.Models.ViewModels
{
    public class PagingInfo
    {
        public PagingInfo()
        {
        }

        public int TotalNumItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)(Math.Ceiling((decimal)TotalNumItems / ItemsPerPage));
    }
}
