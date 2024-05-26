using CourseWorkWeb.Core.CQRS.Medicines.Queries;
using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseWorkWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ISender _sender;

        public ShoppingCartController(ISender sender)
        {
            _sender = sender;
        }

        // Список товаров в корзине
        public static List<Medicine> Cart { get; } = new List<Medicine>();

        // Добавление товара в корзину
        public async Task<ActionResult> AddToCart(long Id)
        {
            var product = await _sender.Send(new GetMedicineByIdQuery(Id));
            if (product != null)
            {
                Cart.Add(product);
            }

            return RedirectToAction("Index", "Catalog");
        }

        // Просмотр содержимого корзины
        public ActionResult ViewCart()
        {
            return View(Cart);
        }
    }
}
