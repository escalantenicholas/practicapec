using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using pecanopractico.Interfaces;
using pecanopractico.Models;
using pecanopractico.Views;

namespace pecanopractico.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class TrabajadorController : Controller
    {
        ITrabajadorRepository _repository;
        public TrabajadorController(ITrabajadorRepository repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<TrabajadorView> additionalList = _repository.GetAll();
                return Ok(additionalList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{dni}")]
        public IActionResult GetByDni(string dni)
        {
            try
            {
                TrabajadorView additionalList = _repository.GetByDni(dni);
                return Ok(additionalList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
