using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban_board.Models.Entities
{
    [Table(name:"Projects")]
    public class Project
    {
        public Guid Id { get;set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedByUserId { get; set; }


        
    }
}
