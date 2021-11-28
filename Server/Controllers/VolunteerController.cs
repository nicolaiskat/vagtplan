using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vagtplanen.Server.Services;

namespace vagtplanen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private VolunteerService _service;
        public VolunteerController(VolunteerService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var list = await _service.Get();
                return Ok(list);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{un}", Name = "VolunteerById")]
        public async Task<IActionResult> Get(string un)
        {
            try
            {
                var coor = await _service.Get(un);
                if (coor == null)
                    return NotFound();
                return Ok(coor);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpPost]
        //public IActionResult Create(Volunteer obj)
        //{
        //    try
        //    {
        //        var _obj = _service.CreateVolunteer(obj);
        //        return CreatedAtRoute("VolunteerById", _obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        //log error
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCompany(int id, CompanyForUpdateDto company)
        //{
        //    try
        //    {
        //        var dbCompany = await _companyRepo.GetCompany(id);
        //        if (dbCompany == null)
        //            return NotFound();
        //        await _companyRepo.UpdateCompany(id, company);
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        //log error
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCompany(int id)
        //{
        //    try
        //    {
        //        var dbCompany = await _companyRepo.GetCompany(id);
        //        if (dbCompany == null)
        //            return NotFound();
        //        await _companyRepo.DeleteCompany(id);
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        //log error
        //        return StatusCode(500, ex.Message);
        //    }
        //}
    }
}
