using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vagtplanen.Server.Services;

namespace vagtplanen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private CouponService _service;
        public CouponController(CouponService service)
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

        [HttpGet("{id}", Name = "CouponById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var obj = await _service.Get(id);
                if (obj == null)
                    return NotFound();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(Coupon coor)
        //{
        //    try
        //    {
        //        var _obj = await _service.Create(coor);
        //        return CreatedAtRoute("CouponById", new { id = _obj.id }, _obj);
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
