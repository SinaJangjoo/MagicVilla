using AutoMapper;
using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using MagicVilla_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;

namespace MagicVilla_API.Controllers.v2
{
    [Route("api/v{version:apiVersion}/VillaNumberAPI")]
    [ApiController]
    [ApiVersion("2.0")]
    public class VillaNumberAPIController : ControllerBase
    {
        protected APIResponse _response;                             // APIResponse (Model) Dependency Injection
        private readonly IVillaNumberRepository _dbVillaNumber;      // Database in Repository Dependency Injection
        private readonly IVillaRepository _dbVilla;                  // Villa Repository Dependency Injection
        private readonly IMapper _mapper;                            // AutoMapper Dependency Injection
        public VillaNumberAPIController(ILogger<VillaNumberAPIController> logger,
            IVillaNumberRepository dbVillaNumber, IMapper mapper, IVillaRepository dbVilla)  // Dependency Injection
        {
            _dbVillaNumber = dbVillaNumber;
            _mapper = mapper;
            _response = new();
            _dbVilla = dbVilla;
        }


        //[MapToApiVersion("2.0")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


    }
}
