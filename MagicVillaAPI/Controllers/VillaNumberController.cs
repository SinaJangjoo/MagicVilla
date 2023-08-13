using AutoMapper;
using MagicVillaAPI.Models;
using MagicVillaAPI.Models.Dto;
using MagicVillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace MagicVillaAPI.Controllers
{
    [Route("api/VillaNumber")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        protected APIResponse response;
        private readonly IVillaNumberRepository dbVillaNumber;
        private readonly IMapper mapper;

        public IVillaRepository DbVilla { get; }

        public VillaNumberController(IMapper _mapper, IVillaNumberRepository _dbVillaNumber, IVillaRepository _dbVilla)
        {
            mapper = _mapper;
            dbVillaNumber = _dbVillaNumber;
            DbVilla = _dbVilla;
            response = new APIResponse();
        }
        [HttpGet]
        [ResponseCache(CacheProfileName = "default30")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetAllVillaNumbers()
        {
            try
            {
                var villaNumberList = await dbVillaNumber.GetAllAsync(IncludeProperties: "Villa");
                if (villaNumberList == null)
                {
                    return BadRequest();
                }
                response.statusCode = HttpStatusCode.OK;
                response.IsSuccess = true;
                response.Result = villaNumberList;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMasseges = new List<string>() { ex.Message };
                return response;
            }
        }
        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        [ResponseCache(CacheProfileName = "default30")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villa = await dbVillaNumber.GetAsync(x => x.VillaNo == id, IncludeProperties: "Villa");
                if (villa == null)
                {
                    return NotFound();
                }
                response.statusCode = HttpStatusCode.OK;
                response.Result = villa;
                response.IsSuccess = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMasseges = new List<string>() { ex.Message };
                return response;
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> CreateAsync([FromBody] VillaNumberCreateDTO createDTO)
        {
            try
            {
                if (createDTO.VillaNo <= 0)
                {
                    return BadRequest();
                }
                if (await dbVillaNumber.AnyAsync(x => x.VillaNo == createDTO.VillaNo) ||
                    !await DbVilla.AnyAsync(x => x.id == createDTO.VillaId))
                {
                    response.IsSuccess = false;
                    response.ErrorMasseges = new List<string> { "Room already exists." };
                    return response;
                }
                VillaNumber villa = mapper.Map<VillaNumber>(createDTO);
                await dbVillaNumber.CreateAsync(villa);
                response.IsSuccess = true;
                response.statusCode = HttpStatusCode.Created;
                response.Result = villa;
                return CreatedAtRoute("GetVillaNumber", new { id = villa.VillaNo }, response);
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMasseges = new List<string>() { ex.Message };
                return response;
            }
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}", Name = "RemoveVillaNumber")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> RemoveVillaNumber(int id)
        {
            try
            {
                if (id > 0)
                {
                    var villa = await dbVillaNumber.GetAsync(x => x.VillaNo == id);
                    if (villa != null)
                    {
                        await dbVillaNumber.RemoveAsync(villa);
                        response.IsSuccess = true;
                        response.statusCode = HttpStatusCode.NoContent;
                        return response;
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMasseges = new List<string>() { ex.Message };
                return response;
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO updateDTO)
        {
            try
            {

                if (id <= 0 || updateDTO.VillaNo != id)
                {
                    response.IsSuccess = false;
                    response.statusCode = HttpStatusCode.BadRequest;
                    response.ErrorMasseges = new List<string> { "This room number is invalid" };
                    return response;
                }
                if (!await DbVilla.AnyAsync(x => x.id == updateDTO.VillaId))
                {
                    response.IsSuccess = false;
                    response.statusCode = HttpStatusCode.BadRequest;
                    response.ErrorMasseges = new List<string> { "This Villa ID is invalid" };
                    return response;
                }
                var villa = await dbVillaNumber.GetAsync(x => x.VillaNo == id, false);
                if (villa == null)
                {
                    response.IsSuccess = false;
                    response.statusCode = HttpStatusCode.NotFound;
                    response.ErrorMasseges = new List<string> { "This room number does not exist" };
                    return response;
                }
                var model = mapper.Map<VillaNumber>(updateDTO);
                await dbVillaNumber.UpdateAsync(model);
                response.IsSuccess = true;
                response.statusCode = HttpStatusCode.NoContent;
                return Ok(response);


            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMasseges = new List<string>() { ex.Message };
                return response;
            }
        }
    }
}
