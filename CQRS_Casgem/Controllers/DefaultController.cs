using CQRS_Casgem.CQRSPattern.Comments;
using CQRS_Casgem.CQRSPattern.Handlers;
using CQRS_Casgem.CQRSPattern.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Casgem.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _handler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly GetProductByIDQueryHandler _getProductByIDQueryHandler;
        private readonly GetProductUpdateByIDQueryHandler _getProductUpdateByIDQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        public DefaultController(GetProductQueryHandler handler, CreateProductCommandHandler createProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductByIDQueryHandler getProductByIDQueryHandler, GetProductUpdateByIDQueryHandler getProductUpdateByIDQueryHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _handler = handler;
            _createProductCommandHandler = createProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductByIDQueryHandler = getProductByIDQueryHandler;
            _getProductUpdateByIDQueryHandler = getProductUpdateByIDQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _handler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command)
        {
            _createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(RemoveProductCommand command)
        {
            _removeProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        public IActionResult GetProductByID(GetProductByIDQuery query)
        {
            var values = _getProductByIDQueryHandler.Handle(query);
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = _getProductUpdateByIDQueryHandler.Handle(new GetProductUpdateByIDQuery(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand command)
        {
            _updateProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
