using System.ComponentModel.DataAnnotations;

namespace CloneIntime.Models.DTO
{
    public class GroupDTO
    {
        public DirectionDTO Direction;
        [Required]
        public string Number;
        [Required]
        public string Name;
    }
}
