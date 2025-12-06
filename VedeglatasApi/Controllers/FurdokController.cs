using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VedeglatasApi.Models;
using VedeglatasApi.Models.Dtos;

namespace VedeglatasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurdokController : ControllerBase
    {
        private readonly VendeglatasContext _context;
        public FurdokController(VendeglatasContext context)
        {
            _context = context;
        }
        ResponseDto responseDto = new ResponseDto();

        [HttpPost]
        public async Task<ActionResult> AddNewStrand(AddStrandDto addStrandDto)
        {
            try
            {

                var requestParam = new Furdok
                {
                  Nev=addStrandDto.Nev,
                  Cim=addStrandDto.Cim,
                  Irnyitoszam = addStrandDto.Irnyitoszam,
                  Varosid=addStrandDto.Varosid
                };

                if (requestParam != null)
                {
                    await _context.Furdoks.AddAsync(requestParam);
                    await _context.SaveChangesAsync();

                    responseDto.Message = "Sikeres hozzáadás.";
                    responseDto.Result = requestParam;

                    return StatusCode(201, responseDto);
                }

                responseDto.Message = "Sikeretlen hozzáadás.";
                responseDto.Result = requestParam;

                return StatusCode(400, responseDto);
            }
            catch (Exception ex)
            {
                responseDto.Message = ex.Message;
                responseDto.Result = null;

                return StatusCode(400, responseDto);
            }

        }
        
        [HttpGet]
        public async Task<ActionResult> GetAllVaros()
        {
            try
            {
                var requestParam = await _context.Furdoks.ToListAsync();

                if (requestParam.Count != 0)
                {
                    responseDto.Message = "Sikeres lekérdezés.";
                    responseDto.Result = requestParam;
                    return Ok(responseDto);
                }

                responseDto.Message = "Nincs adat.";
                responseDto.Result = requestParam;
                return NotFound(responseDto);
            }
            catch (Exception ex)
            {
                responseDto.Message = ex.Message;
                responseDto.Result = null;
                return Ok(responseDto);
            }
        }
    }
}
