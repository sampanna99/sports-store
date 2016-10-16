using SportsStore.Domain.Entities;

namespace WebApplication1.Models
{
    public class CartIndexViewModel
    {
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}