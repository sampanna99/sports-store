using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        public CartController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel { cart = cart, ReturnUrl = returnUrl });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                // GetCart().AddItem(product, 1);
                cart.AddItem(product, 1);

            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                // GetCart().RemoveItem(product);
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //private Cart GetCart()  I COMMENTED THIS AFTER I DID MY CARTINDEXVIEWMODEL AND POSTED IT IN GLOBAL.ASAX.CS
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)d
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

    }
}