using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MyFarm.Web.Models;
using Microsoft.AspNetCore.Authorization;
using MyFarm.Core.Interfaces;
using MyFarm.Core.Entities;
using MyFarm.Core.Specifications;
using MyFarm.Web.ViewModels;
using MyFarm.Web.ViewModels.Farm;

namespace MyFarm.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class FarmController : Controller
    {
        private readonly IAsyncRepository<Farm> _farmRepository;

        public FarmController(IAsyncRepository<Farm> farmRepository)
        {
            _farmRepository = farmRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<FarmViewModel> viewModel = await GetFarms();
            return View(viewModel);
        }

        private async Task<IEnumerable<FarmViewModel>> GetFarms()
        {
            var farms = await _farmRepository.ListAsync(new UsersFarmSpecification(User.Identity.Name));

            var viewModel = farms
                .Select(f => new FarmViewModel
                {
                    Name = f.Name,
                    Id = f.Id
                });
            return viewModel;
        }

        [HttpGet("{farmId}")]
        public async Task<IActionResult> Edit(int farmId)
        {
            var farm = await _farmRepository.GetByIdAsync(farmId);
            var viewModel = new FarmViewModel()
            {
                Name = farm.Name,
                Id = farm.Id
            };
            return View(viewModel);
        }

        [HttpGet("{farmId}")]
        public async Task<IActionResult> Select(int farmId)
        {
            IEnumerable<FarmViewModel> viewModel = await GetFarms();
            return View(nameof(Index), viewModel);
        }

        private FarmViewModel GetOrder()
        {
            var farm = new FarmViewModel()
            {
                Name = "" 
            };

            return farm;
        }
    }
}
