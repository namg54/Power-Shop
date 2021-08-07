using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerShop.Data;
using PowerShop.Data.Repositories;
using PowerShop.Models;

namespace PowerShop.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private IGroupRepository _groupRepository;

        public ProductGroupsComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            return View("/Views/Components/ProductGroupsComponent.cshtml",_groupRepository.GetGroupForShow());
        }
    }
}
