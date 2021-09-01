using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Auth
{
    public class AdminInfoModel
    {
        public Guid AdminID { get; set; }
        public string AdminAccount { get; set; }
        public string AdminName { get; set; }
    }
}
