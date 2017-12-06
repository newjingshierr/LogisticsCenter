using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
    public class UserRegisterRequest
    {
        public string email { get; set; } = "";
        public string tel { get; set; } = "";

        public string pass { get; set; } = "";
    }
}
