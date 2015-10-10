using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class School : DbEntity
    {
        public School()
        {
            Students = new List<Student>();
        }

        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
