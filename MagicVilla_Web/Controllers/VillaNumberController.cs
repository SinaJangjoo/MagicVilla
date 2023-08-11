using AutoMapper;
using MagicVilla_Utilities;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Models.VM;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Data;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService villaNumberService;
        private readonly IMapper mapper;
        private readonly IVillaService villaService;

        public VillaNumberController(IVillaNumberService _villaNumberService, IMapper _mapper, IVillaService _villaService)
        {
            villaNumberService = _villaNumberService;
            mapper = _mapper;
            villaService = _villaService;
        }
        public async Task<IActionResult> IndexVillaNumber()
        {
            List<VillaNumberDTO> villas = new List<VillaNumberDTO>();
            var response = await villaNumberService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.sessionToken));
            if (response != null && response.IsSuccess)
            {
                villas = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
			}
            return View(villas);
        }
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> CreateVillaNumber()
        {
            VillaNumberCreateVM villaNumberCreateVM = new VillaNumberCreateVM();
            var response = await villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.sessionToken));
            if (response != null && response.IsSuccess)
            {
                villaNumberCreateVM.villaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result)).Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                });
            }

            return View(villaNumberCreateVM);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateVM createVM)
        {

            if (ModelState.IsValid)
            {
                var response = await villaNumberService.CreateAsync<APIResponse>(createVM.villaNumber, HttpContext.Session.GetString(SD.sessionToken));
                if (response != null && response.IsSuccess)
                {
					TempData["Success"] = "Villa Number Created Successfully";
					return RedirectToAction("IndexVillaNumber");
                }
                else
                {
                    ModelState.AddModelError("", response.ErrorMasseges.FirstOrDefault());
                    var resp = await villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.sessionToken));
                    if (resp != null && resp.IsSuccess)
                    {
                        createVM.villaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(resp.Result)).Select(x => new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.Id.ToString(),
                        });
                    }
					TempData["error"] = "Error encountered.";
					return View(createVM);
                }

            }
            return View(createVM);
        }
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateVillaNumber(int villaNo)
        {
            VillaNumberUpdateVM villaNumberUpdateVM = new VillaNumberUpdateVM();
            var resp = await villaNumberService.GetAsync<APIResponse>(villaNo, HttpContext.Session.GetString(SD.sessionToken));
            
            if (resp != null && resp.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(resp.Result));
                villaNumberUpdateVM.villaNumber = mapper.Map<VillaNumberUpdateDTO>(model);
            }
            var response = await villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.sessionToken));
            if (response != null && response.IsSuccess)
            {
                villaNumberUpdateVM.villaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result)).Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                });
            }

            return View(villaNumberUpdateVM);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateVM updateVM)
        {

            if (ModelState.IsValid)
            {
                var response = await villaNumberService.UpdateAsync<APIResponse>(updateVM.villaNumber, HttpContext.Session.GetString(SD.sessionToken));
                
                if (response != null && response.IsSuccess) 
                {
					TempData["Success"] = "Villa Number Updated Successfully";
					return RedirectToAction("IndexVillaNumber");
                }
                else
                {
                    //ModelState.AddModelError("", response.ErrorMasseges.FirstOrDefault());
                    var resp = await villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.sessionToken));
                    if (resp != null && resp.IsSuccess)
                    {
                        updateVM.villaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(resp.Result)).Select(x => new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.Id.ToString(),
                        });
                    }

					TempData["error"] = HttpContext.Session.GetString(SD.sessionToken);
					return View(updateVM);
                }

            }
            return View(updateVM);
        }
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteVillaNumber(int villaNo)
        {
            VillaNumberDeleteVM villaNumberDeleteVM = new VillaNumberDeleteVM();
            var resp = await villaNumberService.GetAsync<APIResponse>(villaNo, HttpContext.Session.GetString(SD.sessionToken));
            if (resp != null && resp.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(resp.Result));
                villaNumberDeleteVM.villaNumber = model;
            }
            var response = await villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.sessionToken));
            if (response != null && response.IsSuccess)
            {
                villaNumberDeleteVM.villaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result)).Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                });
            }

            return View(villaNumberDeleteVM);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDeleteVM deleteVM)
        {


            var response = await villaNumberService.RemoveAsync<APIResponse>(deleteVM.villaNumber.VillaNo, HttpContext.Session.GetString(SD.sessionToken));
            if (response != null && response.IsSuccess)
            {
				TempData["Success"] = "Villa Number Deleted Successfully";
				return RedirectToAction("IndexVillaNumber");
            }

			TempData["error"] = "Error encountered.";
			return View(deleteVM);
        }
    }
}
