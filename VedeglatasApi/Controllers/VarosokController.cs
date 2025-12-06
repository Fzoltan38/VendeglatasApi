using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VedeglatasApi.Models;
using VedeglatasApi.Models.Dtos;

namespace VedeglatasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VarosokController : ControllerBase
    {
        private readonly VendeglatasContext _context;
        public VarosokController(VendeglatasContext context)
        {
            _context = context;
        }
        ResponseDto responseDto = new ResponseDto();
        [HttpPost]
        public async Task<ActionResult> AddNewCity(AddVarosDto addVarosDto)
        {
            try
            {
               
                var varos = new Varosok
                {
                    Nev = addVarosDto.Nev,
                    Tipus = addVarosDto.Tipus,
                    Lakosokszama = addVarosDto.Lakosokszama
                };

                if (varos != null)
                {
                    await _context.Varosoks.AddAsync(varos);
                    await _context.SaveChangesAsync();

                    responseDto.Message = "Sikeres hozzáadás.";
                    responseDto.Result = varos;

                    return StatusCode(201, responseDto);
                }

                responseDto.Message = "Sikeretlen hozzáadás.";
                responseDto.Result = varos;

                return StatusCode(400, responseDto);
            }
            catch (Exception ex)
            {
                responseDto.Message = ex.Message;
                responseDto.Result = null;

                return StatusCode(400, responseDto);
            }
            
        }
    }
}
