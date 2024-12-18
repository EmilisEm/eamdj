﻿using EAMDJ.Dto.Shared;
using EAMDJ.Dto.UserDto;
using EAMDJ.Mapper;
using EAMDJ.Model;
using EAMDJ.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Service.UserService
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _repository;

		public UserService(IUserRepository repository)
		{
			_repository = repository;
		}

		public async Task<UserResponseDto> CreateUserAsync(UserCreateDto user)
		{
			User created = await _repository.CreateUserAsync(UserMapper.FromDto(user));

			return UserMapper.ToDto(created);


		}

		public async Task DeleteUserAsync(Guid id)
		{
			await _repository.DeleteUserAsync(id);
		}

		public async Task<IEnumerable<UserResponseDto>> GetAllUsersByBusinessIdAsync(Guid businessId)
		{
			IEnumerable<User> productCategories = await _repository.GetAllUsersByBusinessIdAsync(businessId);

			return productCategories.Select(UserMapper.ToDto);
		}

		public async Task<UserResponseDto> GetUserByUsernameAsync(string username)
		{
			User user = await _repository.GetUserByUsernameAsync(username);

			return UserMapper.ToDto(user);
		}

		public async Task<PaginatedResult<UserResponseDto>> GetAllUsersByBusinessIdAsync(Guid businessId, int page, int pageSize)
		{
			var skip = (page - 1) * pageSize;
			var query = _repository.GetQueryUsersByBusinessIdAsync(businessId);
			var totalCount = await query.CountAsync();

			var users = await query
				.Skip(skip)
				.Take(pageSize)
				.ToListAsync();

			var userDtos = users.Select(UserMapper.ToDto).ToList();

			return new PaginatedResult<UserResponseDto>
			{
				Items = userDtos,
				TotalCount = totalCount,
				Page = page,
				PageSize = pageSize
			};
		}
		public async Task<UserResponseDto> GetUserAsync(Guid id)
		{
			User user = await _repository.GetUserAsync(id);

			return UserMapper.ToDto(user);
		}

		public async Task<UserResponseDto> UpdateUserAsync(Guid id, UserUpdateDto user)
		{
			User original = await _repository.GetUserAsync(id);
			User updated = await _repository.UpdateUserAsync(id, UserMapper.FromDto(user, original.BusinessId, original.Password, original.Id));

			return UserMapper.ToDto(updated);
		}
	}
}
