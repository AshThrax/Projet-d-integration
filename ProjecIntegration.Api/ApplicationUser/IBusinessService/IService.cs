﻿using ApplicationUser.Dto;
using Domain.Entity;
using Domain.ServiceResponse;

namespace ApplicationUser.Service
{
    public interface IService<TEntity,TDto, TAddDto, TUpdateDto>
        where TEntity : BaseEntity
        where TDto : BasicDto
        where TAddDto : AddBaseDto
        where TUpdateDto : UpdateUserDetailDto
    {
        Task<ServiceResponse<TDto>> AddAsync(TAddDto entity);
        Task<ServiceResponse<TDto>> UpdateAsync(int Id, TUpdateDto entity);
        Task<ServiceResponse<TDto>> DeleteAsync(int entityId);
        Task<ServiceResponse<TDto>> GetByIdAsync(int id);
        Task<ServiceResponse<List<TDto>>> GetAsync();

    }
}
