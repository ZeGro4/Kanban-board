using Microsoft.AspNetCore.Identity;

namespace Kanban_board.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
