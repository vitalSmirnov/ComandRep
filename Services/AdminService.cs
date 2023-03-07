using CloneIntime.Entities;
using CloneIntime.Models.DTO;
using CloneIntime.Models;
using CloneIntime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using CloneIntime.Models.Entities;

namespace CloneIntime.Services
{
    public class AdminService
    {
        private readonly Context _context;
        private readonly SupportService _support;
        public AdminService(Context context, SupportService support)
        {
            _context = context;
            _support = support;
        }

        public async Task<IActionResult> AddTeacher(ProffessorDTO newTeacher)// Получить группы на определенном направлении
        {
            await _context.AddAsync(new TeacherEntity
            {
                Name = newTeacher.Name,
                Email = newTeacher.Email,
                Id = Guid.NewGuid(),
                IsActive = true,
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

        private List<GroupEntity> fillGroups(List<string> groups)
        {
            var groupEntity = _context.GroupEntities.Where(x => groups.Contains(x.Name) && x.IsActive).ToList();
            return groupEntity;
        }

        public async Task<IActionResult> SetPair(string pairId, SetTimeSlotModel newPairData)// Получить группы на определенном направлении
        {
            var auditory = await _context.AuditoryEntities.FirstOrDefaultAsync(x => x.Number == newPairData.Audiroty);
            var discipline = await _context.DisciplineEntities.FirstOrDefaultAsync(x => x.Name == newPairData.Discipline);
            var teacher = await _context.TeachersEntities.FirstOrDefaultAsync(x => x.Name == newPairData.Professor);
            var id = Guid.NewGuid();

            var newPair = new PairEntity
            {
                Auditory = auditory,
                Discipline = discipline,
                Group = fillGroups(newPairData.Groups),
                IsActive = true,
                Id = id,
                LessonType = newPairData.Type,
                Teacher = teacher
            };

            await _context.PairEntities.AddAsync(newPair);
            await _context.SaveChangesAsync();
            var message = "All right";
            return new OkObjectResult(message);
        }
        public async Task<IActionResult> UpdatePair(string id, SetTimeSlotModel PairNewData)
        {
            var pair = await _context.PairEntities.FirstOrDefaultAsync(x => x.Id.ToString() == id && x.IsActive);
            var auditory = await _context.AuditoryEntities.FirstOrDefaultAsync(x => x.Number == PairNewData.Audiroty);
            var discipline = await _context.DisciplineEntities.FirstOrDefaultAsync(x => x.Name == PairNewData.Discipline);
            var teacher = await _context.TeachersEntities.FirstOrDefaultAsync(x => x.Name == PairNewData.Professor);

            if (pair == null)
                return new NotFoundObjectResult(new {message =  "Pair not found" }); // прописать ошибку
            if (auditory == null)
                return new NotFoundObjectResult(new { message = "auditory not found" }); // прописать ошибку
            if (discipline == null)
                return new NotFoundObjectResult(new { message = "discipline not found" }); // прописать ошибку
            if (teacher == null)
                return new NotFoundObjectResult(new { message = "teacher not found" }); // прописать ошибку

            pair.Auditory = auditory;
            pair.Discipline = discipline;
            pair.Teacher = teacher;
            pair.Group = fillGroups(PairNewData.Groups);

            _context.PairEntities.Update(pair);
            await _context.SaveChangesAsync();

            return new OkObjectResult(pair);

        }
        /*public async Task<IActionResult> DeletePair(string pairId)
        {
            var pair = await _context.PairEntities.FirstOrDefaultAsync(x => x.Id.ToString() == pairId && x.IsActive);


            if (pair == null)
                return new NotFoundObjectResult(new { message = "Pair not found" }); // прописать ошибку

            await _context.

        }*/

        public async Task<ActionResult<TokenResponseDTO>> Login(CredentialsModel model)
        {
            var user = await _context.EditorEntity.FirstOrDefaultAsync(x => x.Login == model.Email);

            /*if (user == null)
                throw new UserNotFoundException();*/

            if (user.Password != model.Password)
                return new BadRequestObjectResult(new { 
                    message = "Incorrect Password",
                });

            var id = user.Id;
            var token = new JwtSecurityTokenHandler().WriteToken(_support.GenerateJWT(model.Email, user.Id.ToString()));


            return new TokenResponseDTO
            {
                Token = token
            };
        }
        public async Task<IActionResult> Logout(string userToken)
        {
            var id = Guid.NewGuid();
            var token = new TokenEntity
            {
                Id = id,
                Token = userToken

            };
            await _context.TokenEntity.AddAsync(token);
            await _context.SaveChangesAsync();

            return new JsonResult(new { message = "Logged out" });
        }
    }
}
