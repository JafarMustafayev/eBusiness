using eBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace eBusiness.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionController : Controller
    {
        private readonly DataContext _dataContext;

        public PositionController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public IActionResult Index()
        {

            return View(_dataContext.Positions.ToList());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Position position) 
        {
            if(position == null) { return View("Error"); }
            if(!ModelState.IsValid) { return View(); }

            _dataContext.Positions.Add(position);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
