using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using User.Api.Core.Interface;
using User.Api.Entities;

namespace User.Api
{

    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly ILogger<UserController> _logger;

        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        [Route("api/users"), HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetList(int Page = 0, int Size = 25)
        {


            _logger.LogInformation("start GetList");
            var result = new List<User>();
            try
            {

                result = await _userService.GetList();
                result = result?.Skip(Size * Page)?.Take(Size)?.ToList();

            }
            catch (System.Exception ex)
            {
                _logger.LogError("Error Users", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            _logger.LogInformation("Completed GetList");
            return result;

        }

        // GET: api/Employee/5
        [HttpGet("api/user/{id}", Name = "Get")]
        public async Task<ActionResult<User>> Get(int id)
        {
            _logger.LogInformation("start Get");

            if (id <= 0 || id > 1000)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var result = new User();
            try
            {
                result = await _userService.Get(id);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error Users", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            _logger.LogInformation(" End Get ");

            return result;
        }

        // POST: api/Employee
        [HttpPost, Route("api/user")]
        [Produces("application/json")]
        public ActionResult<bool> Post([FromBody] User userData)
        {
            if (userData == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            _logger.LogInformation(" Insert User");

            try
            {
                var result = _userService.Insert(userData);
                return result;

            }
            catch (System.Exception ex)
            {
                _logger.LogError("Error Users", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        // PUT: api/Employee/5
        [HttpPut("api/user/{id}")]
        public ActionResult<bool> Put(int id, [FromBody] User userData)
        {


            _logger.LogInformation(" Insert User");
            if (id <= 0 || id > 1000)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var result = _userService.Update(userData);

                return result;

            }
            catch (System.Exception ex)
            {
                _logger.LogError("Error Users", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Employee/5
        [HttpDelete("api/user/{id}")]
        public ActionResult<bool> Delete(int id)
        {

            if (id <= 0 || id > 1000)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            _logger.LogInformation(" Insert User");

            try
            {
                var result = _userService.Delete(id);

                return result;

            }
            catch (System.Exception ex)
            {
                _logger.LogError("Error Users", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }

}

