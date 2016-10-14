using SportsStore.Domain.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List(int page = 1)
        {
            return View(repository.products.OrderBy(p => p.ProductId).Skip((page - 1) * PageSize).Take(PageSize));
        }

    }
}