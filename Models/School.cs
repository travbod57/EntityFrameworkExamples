using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ConcurrencyCheck]
        [Column(TypeName = "datetime2")]
        public DateTime TimeStamp { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
