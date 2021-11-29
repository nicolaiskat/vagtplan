using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vagtplanen.Server.Services;

namespace vagtplanen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private ShiftService _service;
        public ShiftController(ShiftService service)
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

        [HttpGet("{id}", Name = "ShiftById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var coor = await _service.Get(id);
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
        //public async Task<IActionResult> Create(Shift coor)
        //{
        //    try
        //    {
        //        var _coor = await _service.Create(coor);
        //        return CreatedAtRoute("ShiftById", new { id = _coor.id }, _coor);
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
