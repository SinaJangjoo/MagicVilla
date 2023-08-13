using AutoMapper;
using MagicVilla_Utilities;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Models.VM;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MagicVilla_Web.Controllers
{
        [BindProperties]
    public class HomeController : Controller
    {
        private readonly IVillaService villaService;
        private readonly IMapper mapper;
        private PaginationDTO paginationDTO;
        public HomeController(IVillaService _villaService, IMapper _mapper)
        {
            villaService = _villaService;
            mapper = _mapper;
            this.paginationDTO = new PaginationDTO();
        }
        public async Task<IActionResult> Index(int pageNumber)
        {
            VillaIndexVM vM = new();
            var resp = await villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.sessionToken));
            if (resp != null)
            {
                var count = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(resp.Result)).Count;
                ViewData["count"] = count;
            }
            if (pageNumber >1)
            {
                paginationDTO.pageNumber = pageNumber;
            }
			var response = await villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.sessionToken),paginationDTO);
            if (response != null && response.IsSuccess)
            {
                vM.pagination= paginationDTO;
                vM.Villas = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(vM);
        }
    }
}