﻿using CloneIntime.Models.DTO;
using CloneIntime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CloneIntime.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class ProfessorsController : Controller
    {
        private readonly IProfessorsService _professorsService;

        public ProfessorsController(IProfessorsService professorsService)
        {
            _professorsService = professorsService;
        }

        [HttpGet]
        public async Task<List<ProffessorDTO>> GetTeachers()
        {
            return await _professorsService.GetTeachers();
        }
    }
}
