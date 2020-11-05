using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MTAPI.Data.UnitOfWork;
using MTAPI.Services;
using MTAPI.ViewModel;

namespace MTAPI.Controllers
{
    [Route("api/[controller]")]
     public class MedicineController : Controller
    {
        private readonly IMedicineService _service;

        public MedicineController(IMedicineService service)
        {
            this._service = service;
            
        }

        [HttpGet]
        public  IActionResult Get()
        {
            var medicineLst =  this._service.GetAllMedicines();
            return Ok(medicineLst);
        }

        [HttpGet("{id}")]        
        public async Task<IActionResult> Get(int id)
        {
            var medicine = await this._service.GetMedicineByKeyAsync(id);
            return Ok(medicine);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MedicineViewWithNotes mvNotes)
        {
            var result =  this._service.SaveMedicineDetails(mvNotes);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MedicineViewWithNotes mvNotes)
        {
            var result = await this._service.UpdateMedicineDetails(mvNotes);
            return Ok(result);
        }
    }
}
