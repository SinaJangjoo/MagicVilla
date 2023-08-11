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
    public class HomeController : Controller
    {
        private readonly IVillaService villaService;
        private readonly IMapper mapper;

        public HomeController(IVillaService _villaService, IMapper _mapper)
        {
            villaService = _villaService;
            mapper = _mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<VillaDTO> dto = new List<VillaDTO>();
            var response = await villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.sessionToken));
            if (response != null && response.IsSuccess)
            {
                dto = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(dto);
        }
    }
}