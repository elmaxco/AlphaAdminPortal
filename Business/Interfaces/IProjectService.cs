﻿using Business.Dtos;
using Business.Models;


namespace Business.Interfaces;

public interface IProjectService
{
    Task<int> CreateProjectAsync(AddProjectForm form);
    Task<ProjectDto?> GetProjectAsync(int id);
    Task<IEnumerable<ProjectDto?>> GetProjectsAsync();
    Task<bool> UpdateProjectAsync(ProjectUpdateDto dto, int id);
    Task<bool> DeleteProjectAsync(ProjectDto dto);
}
