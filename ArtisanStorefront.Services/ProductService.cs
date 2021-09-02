using ArtisanStorefront.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtisanStorefront.Services
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }






        // GET -- READ
        public IEnumerable<ProductListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .Products
                .Where(e => e.OwnerId == _userId)
                .Select(
                e =>
                new ProductListItem
                {
                    NoteId = e.NoteId,
                    Title = e.Title,
                    CreatedUtc = e.CreatedUtc
                }
                );
                return query.ToArray();
            }
        }

        //GET BY ID ---  READ BY ID
        public NoteDetail GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .Notes
                .Single(e => e.NoteId == id && e.OwnerId == _userId);
                return
                new NoteDetail
                {
                    NoteId = entity.NoteId,
                    Title = entity.Title,
                    Content = entity.Content,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }


    }
}
