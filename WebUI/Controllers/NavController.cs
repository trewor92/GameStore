using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        IGameRepository _repository;
        public NavController(IGameRepository repository)
        {
            _repository = repository;
        }
        public PartialViewResult Menu(string category = null, bool horizontalNav = false)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = _repository.Games
                .Select(game => game.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}
