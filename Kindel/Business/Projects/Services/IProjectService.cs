using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Project;

namespace Business.Projects.Services
{
    public interface IProjectService
    {
        Task<IReadOnlyCollection<ProjectDto>> GetList();

        Task<ProjectDto> Get(int id);

        Task Create(ProjectDto category);

        Task Update(ProjectDto category);

        Task Delete(int id);
    }
}
