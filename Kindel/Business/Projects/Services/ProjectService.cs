using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Projects.Mapping;
using Contracts.Project;
using Domain;

namespace Business.Projects.Services
{
    public class ProjectService : IProjectService
    {
        private readonly UnitOfWork unitOfWork;

        public ProjectService(ApplicationDbContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        public async Task<IReadOnlyCollection<ProjectDto>> GetList()
        {
            var projects = await this.unitOfWork.ProjectRepository.GetList();

            return projects.Select(ProjectMapper.Map).ToArray();
        }

        public async Task<ProjectDto> Get(int id)
        {
            var project = await this.unitOfWork.ProjectRepository.Get(id);

            return ProjectMapper.Map(project);
        }

        public async Task Create(ProjectDto category)
        {
            var result = ProjectMapper.MapCreate(category);

            await this.unitOfWork.ProjectRepository.Create(result);
        }

        public async Task Update(ProjectDto project)
        {
            var result = await this.unitOfWork.ProjectRepository.Get(project.Id);
            ProjectMapper.MapUpdate(result, project);

            await this.unitOfWork.ProjectRepository.Update(result);
        }

        public async Task Delete(int id)
        {
            var project = await this.unitOfWork.ProjectRepository.Get(id);

            await this.unitOfWork.ProjectRepository.Delete(project);
        }
    }
}
