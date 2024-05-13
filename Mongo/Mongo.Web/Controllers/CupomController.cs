using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mongo.Web.Messages;
using Mongo.Web.Models;
using Mongo.Web.Services.IService;
using Newtonsoft.Json;

namespace Mongo.Web.Controllers
{
    public class CupomController : Controller
    {
        private readonly ICupomService _cupomService;

        public CupomController(ICupomService cupomService)
        {
            _cupomService = cupomService;
        }

        public async Task<IActionResult> CupomIndex()
        {
            var response = await _cupomService.GetAllCupomAsync();
            List<CupomDto>? list = [];

            if (response != null && !response.HasError)
            {
                list = JsonConvert.DeserializeObject<List<CupomDto>>(Convert.ToString(response.Result));
                return View(list);
            }

            return View(list);
        }

        public async Task<IActionResult> CupomCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CupomCreate(CupomDto cupomDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _cupomService.InsertCupomAsync(cupomDto);

                if (response != null && !response.HasError)
                {
                    return RedirectToAction(nameof(CupomIndex));
                }

            }
            
            return View(cupomDto);
        }

        [HttpDelete]
        public async Task<IActionResult> CupomDelete(int id)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _cupomService.GetCupomByIdAsync(id);

                if (response != null && !response.HasError)
                {
                    return RedirectToAction(nameof(CupomIndex));
                }
                


            }

            return View();
        }
    }
}