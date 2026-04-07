using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban_board.Models.Entities
{
    [Table(name:"Boards")]
    public class Board
    {
        [Key]
        public Guid Id { get; set;  }

        public string Name { get; set; }    
        public Guid ProjectId { get; set; }


        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public ICollection<BoardTask>? BoardTasks { get; set; }
    }
}
