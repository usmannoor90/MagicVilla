using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_API.Controllers;

[Route("api/v{version:apiVersion}/villaAPI")]
[ApiController]
[ApiVersion("1.0", Deprecated = true)]
[ApiVersion("2.0")]
// these both versions will show all of the endpoints. if we specify with maptoapiversion then that endpoint will be shown based on version. and if we do not specify the maptoapiversoin on any endpoint than it will be show on ApiVersion 1 and ApiVersion 2 regardless. for other controllers if you do not mentioned ApiVersion there then default version will be considered. 
public class VillaAPIController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    private readonly ILogger<VillaAPIController> _logger;
    public VillaAPIController(ILogger<VillaAPIController> logger, ApplicationDbContext _context)
    {
        _logger = logger;
        _dbContext = _context;
    }
    //[Route("getvilla/")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [MapToApiVersion("1.0")]
    // this is basically cashing it is be cashed for 10 s and location can be any either on client or server and then no store is property in the headers that is false means we do need to store the data. and after 10s data will be changed if in client it will validate the new data.
    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false, CacheProfileName = "getVillas")]
    public ActionResult<IEnumerable<VillaDTO>> GetVillas()
    {
        return Ok(_dbContext.Villas.ToList());
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [MapToApiVersion("2.0")]
    public ActionResult<IEnumerable<VillaDTO>> GetVillas2()
    {
        return Ok(_dbContext.Villas.ToList());
    }

    [HttpGet("{id:int}", Name = "GetVilla")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ResponseCache()]

    public ActionResult<VillaDTO> GetVilla(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var villa = _dbContext.Villas.FirstOrDefault(u => u.Id == id);

        if (villa == null)
        {
            return NotFound();
        }
        return Ok(villa);
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villa)
    {
        if (villa == null)
        {
            return BadRequest();
        }

        Villa model = new Villa()
        {
            Amenity = villa.Amenity,
            Details = villa.Details,
            Id = villa.Id,
            ImageUrl = villa.ImageUrl,
            Name = villa.Name,
            Occupancy = villa.Occupancy,
            Rate = villa.Rate,
            Sqft = villa.Sqft,
        };

        _dbContext.Villas.Add(model);

        _dbContext.SaveChanges();


        return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
    }

    [HttpDelete("{id:int}", Name = "DeleteVilla")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteVilla(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }
        var villa = _dbContext.Villas.FirstOrDefault(u => u.Id == id);

        if (villa == null)
        {
            return NotFound();
        }

        _dbContext.Villas.Remove(villa);
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPut("{id:int}", Name = "UpdateVilla")]
    public ActionResult UpdateVilla(int id, [FromBody] VillaDTO villadto)
    {
        if (id != villadto.Id || villadto == null)
        {
            return BadRequest();
        }

        var villa = _dbContext.Villas.FirstOrDefault(u => u.Id == id);

        if (villa == null)
        {
            return NotFound();
        }

        Villa modal = new Villa()
        {
            Amenity = villa.Amenity,
            Details = villa.Details,
            Id = villa.Id,
            ImageUrl = villa.ImageUrl,
            Name = villa.Name,
            Occupancy = villa.Occupancy,
            Rate = villa.Rate,
            Sqft = villa.Sqft,
        };

        _dbContext.Villas.Update(modal);

        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
    [MapToApiVersion("2.0")]

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchdto)
    {
        if (patchdto == null || id == 0)
        {
            return BadRequest();
        }

        var villa = _dbContext.Villas.FirstOrDefault(u => u.Id == id);

        VillaDTO villaDto = new VillaDTO()
        {
            Amenity = villa.Amenity,
            Details = villa.Details,
            Id = villa.Id,
            ImageUrl = villa.ImageUrl,
            Name = villa.Name,
            Occupancy = villa.Occupancy,
            Rate = villa.Rate,
            Sqft = villa.Sqft,
        };

        if (villa == null)
        {
            return NotFound();
        }

        patchdto.ApplyTo(villaDto, ModelState);

        Villa model = new Villa()
        {
            Amenity = villaDto.Amenity,
            Details = villaDto.Details,
            Id = villaDto.Id,
            ImageUrl = villaDto.ImageUrl,
            Name = villaDto.Name,
            Occupancy = villaDto.Occupancy,
            Rate = villaDto.Rate,
            Sqft = villaDto.Sqft,
        };

        _dbContext.Villas.Update(model);

        _dbContext.SaveChanges();

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return NoContent();
    }
}
