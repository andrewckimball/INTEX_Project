using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEXII_App.Models.AdminModel
{
    //UserRole model to connect all the users in each role
    public class UserRole
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }

    }
}
