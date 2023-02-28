﻿using CloneIntime.Models;
using CloneIntime.Models.DTO;
using CloneIntime.Services;
using CloneIntime.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloneIntime.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService; // вернуть интерфейс вмесо сервиса

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        /*[HttpPost("login")]
        public async Task Login([FromBody] CredentialsModel loginCredentials)
        {
            await _adminService.Login(loginCredentials);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task Logout()
        {
            await _adminService.Logout(HttpContext);
        }*/

        [HttpPost("add/teacher")]
        //[Authorize]
        public async Task AddTeacher([FromBody] ProffessorDTO newTeacher)
        {
            await _adminService.AddTeacher(newTeacher);
        }

        [HttpPut("update/teacher/{teacherId}")]
        //[Authorize]
        public async Task UpdateTeacher(string teacherId, [FromBody] ProffessorDTO newTeacherData)
        {
            await _adminService.UpdateTeacher(teacherId, newTeacherData);
        }

        [HttpDelete("delete/teacher/{teacherId}")]
        //[Authorize]
        public async Task DeleteTeacher(string teacherId)
        {
            await _adminService.DeleteTeacher(teacherId);
        }


        /*[HttpPost("add/pair")]
        [Authorize]
        public async Task SetPair([FromQuery] string id, [FromBody] SetTimeSlotModel newPairData)
        {
            await _adminService.SetPair(id, newPairData);
        }

        [HttpDelete("delete/pair/{id}")]
        [Authorize]
        public async Task DeletePair([FromQuery] string id)
        {
            await _adminService.DeletePair(id);
        }

        [HttpPut("update/pair/{id}")]
        [Authorize]
        public async Task UpdatePair([FromQuery] string id, [FromBody] SetTimeSlotModel PairNewData)
        {
            await _adminService.UpdatePair(id, PairNewData);
        }*/
    }
}