using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Auth
{
    public class MemberInfoModel
    {
        public Guid MemberID { get; set; }
        public string MemberName { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Adress { get; set; }

    }
}
