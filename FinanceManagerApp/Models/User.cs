using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagerApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; }

        public override string ToString() => FullName; // для ComboBox
    }
}
