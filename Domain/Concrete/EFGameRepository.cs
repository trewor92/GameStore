using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFGameRepository:IGameRepository
    {
        EFDBContext _context = new EFDBContext();

        public IEnumerable<Game> Games
        {
            get { return _context.Games; }
        }

        public void SaveGame(Game game)
        {
            if (game.GameId == 0)
                _context.Games.Add(game);
            else
            {
                Game dbEntry = _context.Games.Find(game.GameId);
                if (dbEntry != null)
                {
                    dbEntry.Name = game.Name;
                    dbEntry.Description = game.Description;
                    dbEntry.Price = game.Price;
                    dbEntry.Category = game.Category;
                    dbEntry.ImageData = game.ImageData;
                    dbEntry.ImageMimeType = game.ImageMimeType;
                }
            }
            _context.SaveChanges();
        }

        public Game DeleteGame(int gameId)
        {
            Game dbEntry = _context.Games.Find(gameId);
            if (dbEntry != null)
            {
                _context.Games.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
