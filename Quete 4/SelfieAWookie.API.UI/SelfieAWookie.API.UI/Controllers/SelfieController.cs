using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;

namespace SelfieAWookie.API.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {
        private SelfieContext _context = null;
        public SelfieController(SelfieContext slf )
        {
            _context = slf;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //var model = Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });

            var model = this._context.Selfies.Include(item => item.Wookie).Select(item => 
            new {Id = item.Id, Title = item.Title, WookieId = item.Wookie.Id, NbSelfieFromOneWookie = item.Wookie.Selfies.Count})
                .ToList();


            return this.Ok(model);
        }
    }
}
