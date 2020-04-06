using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vs;
        public VaultsController(VaultsService vs)
        {
            _vs = vs;
        }
        [HttpGet]
        // [Authorize]
        public ActionResult<IEnumerable<Vault>> Get()
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vs.GetMyVaults(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       
       [HttpGet("{id}")]
        public ActionResult<Vault> GetById(int id)
        {
            try
            {
                return Ok(_vs.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Vault> Post([FromBody] Vault newVault)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newVault.UserId = userId;
                return Ok(_vs.Create(newVault));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Vault> Delete(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
                return Ok(_vs.Delete(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}