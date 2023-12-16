using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarEnergy.Services;
using SolarEnergy.ViewModel;

namespace SolarEnergy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicalDesignFormsController : ControllerBase
    {
        private readonly IMechanicalDesignForm _mechanicalRepository;

        public MechanicalDesignFormsController(IMechanicalDesignForm mechanicalRepository)
        {
            _mechanicalRepository = mechanicalRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mechanicalDesignForms = await _mechanicalRepository.GetAllAsync();
            return Ok(mechanicalDesignForms);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var categorymechanicalDesignForm = await _mechanicalRepository.GetByIdAsync(id);
        //    return Ok(categorymechanicalDesignForm);
        //}

        [HttpPost]
        public async Task<ActionResult<Category>> Add(MechanicalDesignForm form)
        {
            var newForm = new MechanicalDesignForm()
            {
                FullName = form.FullName,
                PhoneNumber = form.PhoneNumber,
                Title = form.Title,
                Email = form.Email,
                Id = form.Id,
                Details = form.Details,
                AmountOfElectricity = form.AmountOfElectricity,
                PlaceArea = form.PlaceArea,
                Basetype = form.Basetype,
                PanelsNumber = form.PanelsNumber,

            };
            await _mechanicalRepository.AddAsync(form);
            return Ok(form);
        }
    }
}
