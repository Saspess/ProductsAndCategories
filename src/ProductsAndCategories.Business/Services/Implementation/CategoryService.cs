using AutoMapper;
using ProductsAndCategories.Business.DTOs.Category;
using ProductsAndCategories.Business.Exceptions;
using ProductsAndCategories.Business.Services.Contracts;
using ProductsAndCategories.Data.Entities;
using ProductsAndCategories.Data.Repositories.Contracts;

namespace ProductsAndCategories.Business.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CategoryViewDto>> GetAllAsync()
        {
            var categoryEntities = await _categoryRepository.GetAllAsync();
            var categoryViewDtos = _mapper.Map<IEnumerable<CategoryViewDto>>(categoryEntities);

            return categoryViewDtos;
        }

        public async Task<CategoryViewDto> GetByIdAsync(int id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Categort was not found.");

            var categoryViewDto = _mapper.Map<CategoryViewDto>(categoryEntity);

            return categoryViewDto;
        }

        public async Task<CategoryViewDto> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            ArgumentNullException.ThrowIfNull(categoryCreateDto, nameof(categoryCreateDto));

            var categoryEntity = _mapper.Map<CategoryEntity>(categoryCreateDto);

            var createdCategoryEntity = await _categoryRepository.CreateAsync(categoryEntity);
            var categoryViewDto = _mapper.Map<CategoryViewDto>(createdCategoryEntity);

            return categoryViewDto;
        }

        public async Task UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            ArgumentNullException.ThrowIfNull(categoryUpdateDto, nameof(categoryUpdateDto));

            var existingCategoryEntity = await _categoryRepository.GetByIdAsync(categoryUpdateDto.Id)
                ?? throw new NotFoundException("Category was not found.");

            var categoryEntity = _mapper.Map<CategoryEntity>(categoryUpdateDto);

            await _categoryRepository.UpdateAsync(categoryEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var existingCategoryEntity = await _categoryRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Category was not found.");

            await _categoryRepository.DeleteAsync(id);
        }
    }
}
