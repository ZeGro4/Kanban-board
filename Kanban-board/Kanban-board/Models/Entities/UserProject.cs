using Kanban_board.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban_board.Models.Entities
{
    public class UserProject
    {

        public string UserId { get; set; }

        public Guid ProjectId { get; set; }

        public RoleName RoleName { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? ApplicationUsers { get; set; }
        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }

    }
}
