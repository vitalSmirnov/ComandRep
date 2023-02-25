using CloneIntime.Models.DTO;
using CloneIntime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CloneIntime.Controllers
{
    [Route("api/disciplines")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {

        private readonly IDisciplineService _disciplineService;

        public DisciplineController(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        [HttpGet("{facultyId}")]
        public async Task<List<DirectionDTO>> GetDisciplines(string facultyId)
        {
            return await _disciplineService.GetDisciplines(facultyId);
        }
    }
}
