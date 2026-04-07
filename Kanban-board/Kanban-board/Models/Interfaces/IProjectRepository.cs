using Kanban_board.Models.Entities;

namespace Kanban_board.Models.Interfaces
{
    public interface IProjectRepository : IRepository<Project,Guid>
    {
    }
}
