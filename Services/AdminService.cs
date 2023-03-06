﻿using CloneIntime.Entities;
using CloneIntime.Models.DTO;
using CloneIntime.Models;
using CloneIntime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace CloneIntime.Services
{
    public class AdminService
    {
        private readonly Context _context;
        public AdminService(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddTeacher(ProffessorDTO newTeacher)// Получить группы на определенном направлении
        {
            await _context.AddAsync(new TeacherEntity
            {
                Name = newTeacher.Name,
                Email = newTeacher.Email,
                Id = Guid.NewGuid(),
                IsActive = true,
                DateCreated = DateOnly.FromDateTime(DateTime.Now).ToString(),
            }); ;


            _context.SaveChangesAsync();

            return new OkResult();
        }
        public async Task<IActionResult> UpdateTeacher(string teacherId, ProffessorDTO newTeacher)// Получить группы на определенном направлении
        {
            var teacher = await _context.TeachersEntities.FirstOrDefaultAsync(x => x.Id.ToString() == teacherId && x.IsActive);

            if (teacher == null)
                return new NotFoundResult();
            teacher.Name = newTeacher.Name;
            teacher.Email = newTeacher.Email;
            teacher.DateUpdated = DateOnly.FromDateTime(DateTime.Now).ToString();

             _context.Update(teacher);
            _context.SaveChangesAsync();

            return new OkResult();
        }
        public async Task<IActionResult> DeleteTeacher(string teacherId)// Получить группы на определенном направлении
        {
            var teacher = await _context.TeachersEntities.FirstOrDefaultAsync(x => x.Id.ToString() == teacherId && x.IsActive);

            if (teacher == null)
                return new NotFoundResult();

            teacher.IsActive = false;

            return new OkResult();
        }
        /*public async Task<IActionResult> SetPair(string pairId, SetTimeSlotModel newPairData)// Получить группы на определенном направлении
        {

        }
        public async Task<IActionResult> UpdatePair(string id, SetTimeSlotModel PairNewData)
        {

        }
        public async Task<IActionResult> DeletePair(string pairId)// Получить группы на определенном направлении
        {*/


        public async Task<ActionResult<TokenResponseDTO>> Login(CredentialsModel model)
        {
            var user = _context.AdminEntities.FirstOrDefault(x => x.Login == model.Email);

            /*if (user == null)
                throw new UserNotFoundException();*/

            if (user.Password != model.Password)
                return new BadRequestObjectResult(new { 
                    message = "Incorrect Password",
                });

            var id = user.Id;
            var token = new JwtSecurityTokenHandler().WriteToken(Generate(model.Email, user.Id));

            await _context.Token.AddAsync(new TokenEntity
            {
                Id = id,
                Token = token
            });

            return new TokenResponse
            {
                Token = token
            };
        }
        public async Task<IActionResult> Logout(string userToken)
        {
            var token = _context.Token.FirstOrDefault(x => x.Token == userToken);

            if (token != null)
                _context.Token.Remove(token);
            await _context.SaveChangesAsync();

            return new JsonResult(new { message = "Logged out" });
        }
    }
}
