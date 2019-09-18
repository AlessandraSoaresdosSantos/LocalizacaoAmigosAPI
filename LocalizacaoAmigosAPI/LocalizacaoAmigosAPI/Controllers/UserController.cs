namespace LocalizacaoAmigos.API.Controllers
{
    using LocalizacaoAmigos.Domain.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net;

    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userServices)
        {
            _userService = userServices;
        }

        
        /// <summary>
        /// Gerar token de acesso
        /// </summary>
        /// <param name="username"></param>
        /// /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("token")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post(string username, string password)
        {
            try
            {
                var response = _userService.Authenticate(username, password);

                return Ok(response.Token);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
