using AutoMapper;
using MagicVillaAPI.Data;
using MagicVillaAPI.Migrations;
using MagicVillaAPI.Models;
using MagicVillaAPI.Models.Dto;
using MagicVillaAPI.Repository;
using MagicVillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;

namespace MagicVillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        protected APIResponse response;
        private readonly IVillaRepository dBVilla;
        private readonly IMapper mapper;

        public VillaAPIController(IVillaRepository _dBVilla, IMapper _mapper)
        {
            dBVilla = _dBVilla;
            mapper = _mapper;
            this.response = new APIResponse();
        }
        [HttpGet]
        [ResponseCache(CacheProfileName = "default30")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillas([FromQuery(Name ="filterOcuppancy")] int? Ocuppancy ,[FromQuery]string? Search, [FromBody]Pagination? pagination=null)
        {
            try
            {
                IEnumerable<Villa> villaList;
                if (Ocuppancy > 0)
                {
                    villaList= await dBVilla.GetAllAsync(x=>x.Occupancy==Ocuppancy,pagination:pagination);
                }
                else
                {
                    villaList = await dBVilla.GetAllAsync(pagination: pagination);
                }
                if(!string.IsNullOrEmpty(Search))
                {
                    villaList = villaList.Where(x=>x.name.ToLower().Contains(Search));

                }
                //Pagination pagination = new Pagination() { pageSize=pageSize,pageNumber=pageNumber};
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
                response.statusCode = HttpStatusCode.OK;
                response.IsSuccess = true;
                response.Result = mapper.Map<List<VillaDTO>>(villaList);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                List<string> errorMasseges = new List<string>() { ex.ToString() };
                return response;
            }
        }
        [HttpGet("{id:int}", Name = "GetVilla")]
        [ResponseCache(CacheProfileName = "default30")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villa = await dBVilla.GetAsync(x => x.id == id);
                if (villa == null)
                {
                    return NotFound();
                }
                response.statusCode = HttpStatusCode.OK;
                response.IsSuccess = true;
                response.Result = villa;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                List<string> errorMasseges = new List<string>() { ex.ToString() };
                return response;
            }
        }
        [Authorize(Roles ="admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDTO villa)
        {
            try
            {

                if (await dBVilla.AnyAsync(x => x.name.ToLower() == villa.Name.ToLower()))
                {
                    ModelState.AddModelError("customError", "Name already exists.");
                    return BadRequest(ModelState);
                }
                if (villa == null)
                {
                    return BadRequest();
                }


                Villa model = mapper.Map<Villa>(villa);


                await dBVilla.CreateAsync(model);
                response.statusCode = HttpStatusCode.Created;
                response.IsSuccess = true;
                response.Result = model;
                return CreatedAtRoute("GetVilla", new { id = model.id }, response);


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                List<string> errorMasseges = new List<string>() { ex.ToString() };
                return response;
            }
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villa = await dBVilla.GetAsync(x => x.id == id);
                if (villa == null)
                {
                    return NotFound();
                }
                await dBVilla.RemoveAsync(villa);
                response.statusCode = HttpStatusCode.NoContent;
                response.IsSuccess = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                List<string> errorMasseges = new List<string>() { ex.ToString() };
                return response;
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDTO villaDTO)
        {
            try
            {
                if (id == 0 || villaDTO == null || id != villaDTO.Id)
                {
                    return BadRequest();
                }


                Villa model = mapper.Map<Villa>(villaDTO);


                await dBVilla.UpdateAsync(model);
                response.statusCode = HttpStatusCode.NoContent;
                response.IsSuccess = true;
                response.Result = model;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                List<string> errorMasseges = new List<string>() { ex.ToString() };
                return response;
            }
        }
        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> PatchDTO)
        {
            if (PatchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await dBVilla.GetAsync(x => x.id == id, false);
            if (villa == null)
            {
                return BadRequest();
            }
            VillaUpdateDTO villaDTO = mapper.Map<VillaUpdateDTO>(villa);
            //VillaUpdateDTO villaDTO = new VillaUpdateDTO()
            //{
            //    Id = villa.id,
            //    Name = villa.name,
            //    Amenity = villa.Amenity,
            //    details = villa.details,
            //    ImageUrl = villa.ImageUrl,
            //    Occupancy = villa.Occupancy,
            //    rate = villa.rate,
            //    SqFt = villa.Sqft
            //};
            PatchDTO.ApplyTo(villaDTO, ModelState);
            Villa model = mapper.Map<Villa>(villaDTO);
            //Villa model = new Villa()
            //{
            //    id=villaDTO.Id,
            //    name = villaDTO.Name,
            //    details = villaDTO.details,
            //    ImageUrl = villaDTO.ImageUrl,
            //    rate = villaDTO.rate,
            //    Occupancy= villaDTO.Occupancy,
            //    Amenity= villaDTO.Amenity,
            //    Sqft=villaDTO.SqFt,
            //    updateDate = DateTime.Now,
            //};
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dBVilla.UpdateAsync(model);
            return NoContent();
        }
    }
}
