using Microsoft.AspNetCore.Identity;

namespace Kanban_board.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }

        public Guid BoardTaskId { get; set; }



        public ICollection<UserProject>? UserProjects { get; set; }

        public ICollection<Project>? Projects { get; set; }

        public ICollection<Project>? CreatedProjects { get; set; }

        public ICollection<BoardTask>? CreatedBoardTasks { get; set; }

        public ICollection<BoardTask>? ExecutTasks { get; set; }

        
    }
}
