namespace LocalizacaoAmigos.API.Controllers
{
    using LocalizacaoAmigos.Domain.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;



    [Route("api/friends")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        [Authorize]
        [HttpGet("GetFriends/{latitude}/{longitude}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(int latitude, int longitude, [FromServices]IFriendsService friendsService)
        {
            try
            {
                return new ObjectResult(friendsService.GetFriends(latitude, longitude));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
