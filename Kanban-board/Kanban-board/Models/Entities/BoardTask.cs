using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban_board.Models.Entities
{
    [Table(name:"BoardTasks")]
    public class BoardTask
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        public string UserCreatorId { get; set; }

        public string? UserExecutorId { get; set; }

        public string? Comments { get; set; }

        [ForeignKey("UserCreatorId")]
        public ApplicationUser UserCreator { get; set; }
        [ForeignKey("UserExecutorId")]
        public ApplicationUser? UserExecutor { get; set; }
    }
}
