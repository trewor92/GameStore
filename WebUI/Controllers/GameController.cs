using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Abstract;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        private IGameRepository _repository;
        public int pageSize = 4;
        public GameController(IGameRepository repository)
        {

            _repository = repository;
        }
        public ViewResult List(string category, int page=1)
        {
            GamesListViewModel model = new GamesListViewModel
            {
                Games = _repository.Games.
                Where(game=>category==null || game.Category==category).
                OrderBy(game => game.GameId).
                Skip((page - 1) * pageSize).
                Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _repository.Games.Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int gameId)
        {
            Game game = _repository.Games
                .FirstOrDefault(g => g.GameId == gameId);

            if (game != null)
            {
                return File(game.ImageData, game.ImageMimeType);
            }
            else
            {
                return null;
            }
        }


    }
}