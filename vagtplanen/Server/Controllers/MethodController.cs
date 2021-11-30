using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vagtplanen.Server.Services;

namespace vagtplanen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MethodController : ControllerBase
    {
        private MethodService _service;
        public MethodController(MethodService service)
        {
            _service = service;
        }


        [HttpGet("login/{un}/{pw}")]
        public async Task<ActionResult> Get(string un, string pw)
        {
            try
            {
                var result = await _service.CheckLogin(un, pw);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{type}/{vol}/{coup}")]
        public async void Get(string type, int id1, int id2)
        {
            if(type == "usecoupon")
            {
                try
                {
                    await _service.UseCoupon(id1, id2);
                }
                catch (Exception ex)
                {
                    //log error
                    StatusCode(500, ex.Message);
                }
            }
            else if (type == "buycoupon")
            {
                try
                {
                    await _service.BuyCoupon(id1, id2);
                }
                catch (Exception ex)
                {
                    //log error
                    StatusCode(500, ex.Message);
                }
            }
            else if (type == "assignshift")
            {
                try
                {
                    await _service.AssignShift(id1, id2);
                }
                catch (Exception ex)
                {
                    //log error
                    StatusCode(500, ex.Message);
                }
            }
            else if (type == "deassignshift")
            {
                try
                {
                    await _service.DeassignShift(id1, id2);
                }
                catch (Exception ex)
                {
                    //log error
                    StatusCode(500, ex.Message);
                }
            }

        }
    }
}
