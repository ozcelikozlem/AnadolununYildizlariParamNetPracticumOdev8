using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model {get; set;}
        private readonly IMovieStoreDbContext _context;
        public UpdateGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=> x.Id == GenreId);
            if(genre is null)
            {
                throw new InvalidOperationException("Kitap Türü Mevcut Değil");
            }
            if(_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
            {
                throw new InvalidOperationException("Aynı Isimli Kitap Türü Zaten Mevcut");
            }
            genre.Name=string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
            genre.IActive =Model.IsActive;
            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }

}