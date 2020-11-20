using Contracts.Project;
using Domain.Entity;

namespace Business.Projects.Mapping
{
    public static class ProjectMapper
    {
        public static Project MapCreate(ProjectDto project)
        {
            return new Project
            {
                Id = project.Id,
                Name = project.Name,
            };
        }

        public static void MapUpdate(Project oldProject, ProjectDto newProject)
        {
            oldProject.Name = newProject.Name;
        }

        public static ProjectDto Map(Project projects)
        {
            return new ProjectDto
            {
                Id = projects.Id,
                Name = projects.Name,   
            };
        }
    }
}
