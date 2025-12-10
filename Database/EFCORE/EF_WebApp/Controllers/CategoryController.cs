using Microsoft.AspNetCore.Mvc;
using EF_DataAccess;
using EF_DataModel;
using EF_DataModel.Models;
namespace EF_WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public CategoryController(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllEmployees()
        {
            List<Book> categories = _context.Books.ToList();
            return Ok(categories);
        }

    }
}
