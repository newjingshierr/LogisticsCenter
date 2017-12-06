using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
    public class UserRegisterRequest
    {
        public string Email { get; set; } = "";
        public string Tel { get; set; } = "";

        public string Pwd { get; set; } = "";
    }
}
