using PowerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerShop.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private MyPowershopContext _context;

        public GroupRepository(MyPowershopContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> getAllCategories()
        {
            return _context.Categories;

        }

        public IEnumerable<ShowGroupViewModel> GetGroupForShow()
        {
            return  _context.Categories
                .Select(c => new ShowGroupViewModel()
                {
                    GroupId = c.CategoryId,
                    Name = c.CategoryName,
                    productCount = _context
                        .CategoryrelProducts
                        .Count(g => g.CategoryId == c.CategoryId)
                }).ToList();
        }
    }
}
