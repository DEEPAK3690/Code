using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DataModel.FluentModels
{
    public class F_Publisher
    {
        public int Publisher_Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<F_Book> Books { get; set; }
    }
}
