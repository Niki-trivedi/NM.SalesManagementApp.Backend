using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NM.SalesManagementApp.Backend.Models
{
    public class SalesRepresentative
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Product { get; set; }
        public decimal SalesAmount { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
