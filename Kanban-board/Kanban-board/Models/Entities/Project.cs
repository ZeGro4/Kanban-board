using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban_board.Models.Entities
{
    [Table(name:"Projects")]
    public class Project
    {
        public Guid Id { get;set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public required string CreatedByUserId { get; set; }

        public ICollection<UserProject> UserProjects { get; set; }
        public ICollection<ApplicationUser>? ApplicationUsers { get; set; }
        public ICollection<Board> Boards { get; set; }
        public ApplicationUser CreatedUser { get; set; }    
        
    }
}
