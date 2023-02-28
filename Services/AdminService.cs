using CloneIntime.Entities;
using CloneIntime.Models.DTO;
using CloneIntime.Models;
using CloneIntime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        {

        }
        public async Task<IActionResult> Login(CredentialsModel loginCredentials)
        {

        }
        public async Task<IActionResult> Logout(HttpContext httpContext)
        {

        }*/
    }
}
