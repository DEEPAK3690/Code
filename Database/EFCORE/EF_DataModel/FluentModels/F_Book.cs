using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_DataModel.FluentModels
{

    public class F_Book
    {
        // [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string PriceRange { get; set; }

        public F_BookDetail BookDetail { get; set; }

        //[ForeignKey("Publisher")]
        //public int Publisher_Id { get; set; }

        //public F_Publisher Publisher { get; set; }

        //public List<F_Author> Authors { get; set; } 

    }
}
