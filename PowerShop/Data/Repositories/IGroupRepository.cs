using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerShop.Models;

namespace PowerShop.Data.Repositories
{
    public interface IGroupRepository
    {
        IEnumerable<Category> getAllCategories();
        IEnumerable<ShowGroupViewModel> GetGroupForShow();
    }


}
