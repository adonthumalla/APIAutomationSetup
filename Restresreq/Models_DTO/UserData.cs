using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restresreq.Models
{
    // Create a request to get data from the API
    public class UserData
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserData data &&
                   id == data.id;
        }

        public override int GetHashCode()
        {
            return 1877310944 + id.GetHashCode();
        }
    }
}
