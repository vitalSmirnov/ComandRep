using Microsoft.AspNetCore.Mvc;

namespace CloneIntime.Controllers
{
    [ApiController]
    [Route("api/teacher")]
    public class ProfessorsController : Controller
    {
        [HttpGet]
        public async Task GetTeachers()
        {
            return Task.FromResult(0);
        }

        public async Task GetTeachers()
    }
}
