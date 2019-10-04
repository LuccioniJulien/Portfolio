using System.Collections.Generic;
using System.Linq;
using Portfolio.Models;

namespace Portfolio.Dao
{
    public class TagRepo : RepositoryBase<Tag>
    {
        public TagRepo(PortfolioEntities context) : base(context)
        {

        }
        public List<Tag> GetAllTagAttributed() => _context.Prj_has_Tags.Select(pht => pht.Tag)
                                                                       .Distinct()
                                                                       .ToList();
    }
}