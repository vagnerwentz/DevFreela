﻿using DevFreela.Application.ViewModel;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        ProjectDetailsViewModel GetById(int id);
    }
}

