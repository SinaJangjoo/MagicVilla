using AutoMapper;
using MagicVilla_Utilities;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService villaService;
        private readonly IMapper mapper;

        public VillaController(IVillaService _villaService, IMapper _mapper)
        {
            villaService = _villaService;
            mapper = _mapper;
        }
        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> dto = new List<VillaDTO>();
            var response = await villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.sessionToken));
            if (response != null && response.IsSuccess)
            {
                dto = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(dto);
        }
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> CreateVilla()
        {

            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDTO createDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await villaService.CreateAsync<APIResponse>(createDTO, HttpContext.Session.GetString(SD.sessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["Success"] = "Villa Created Successfully";
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
			TempData["error"] = "Error encountered.";

			return View(createDTO);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateVilla(int villaId)
        {
            var response = await villaService.GetAsync<APIResponse>(villaId, HttpContext.Session.GetString(SD.sessionToken));
            if (response != null && response.IsSuccess)
            {
                VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(mapper.Map<VillaUpdateDTO>(model));
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDTO updateDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await villaService.UpdateAsync<APIResponse>(updateDTO, HttpContext.Session.GetString(SD.sessionToken));
                if (response != null && response.IsSuccess)
                {
					TempData["Success"] = "Villa Updated Successfully";

					return RedirectToAction(nameof(IndexVilla));
                }
            }
			TempData["error"] = "Error encountered.";

			return View(updateDTO);
        }
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteVilla(int villaId)
        {
            var response = await villaService.GetAsync<APIResponse>(villaId, HttpContext.Session.GetString(SD.sessionToken));
            if (response != null && response.IsSuccess)
            {
                VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaDTO villa)
        {

            var response = await villaService.RemoveAsync<APIResponse>(villa.Id, HttpContext.Session.GetString(SD.sessionToken));
            if (response != null && response.IsSuccess)
            {
				TempData["Success"] = "Villa Deleted Successfully";

				return RedirectToAction(nameof(IndexVilla));
            }
			TempData["error"] = "Error encountered.";
			return View(villa);
        }
    }
}
