using AutoMapper;
using ProductsAndCategories.Business.DTOs.Product;
using ProductsAndCategories.Business.Exceptions;
using ProductsAndCategories.Business.Services.Contracts;
using ProductsAndCategories.Data.Entities;
using ProductsAndCategories.Data.Repositories.Contracts;

namespace ProductsAndCategories.Business.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductViewDto>> GetAllAsync()
        {
            var productEntities = await _productRepository.GetAllAsync();
            var productViewDtos = _mapper.Map<IEnumerable<ProductViewDto>>(productEntities);

            return productViewDtos;
        }

        public async Task<IEnumerable<ProductWithCategoryViewDto>> GetWithCategoryAsync()
        {
            var productEntities = await _productRepository.GetWithCategoryAsync();
            var productWithCategoryViewDtos = _mapper.Map<IEnumerable<ProductWithCategoryViewDto>>(productEntities);

            return productWithCategoryViewDtos;
        }

        public async Task<IEnumerable<ProductWithCategoryViewDto>> GetByCategoryIdAsync(int categoryId)
        {
            var existingCategoryEntity = await _categoryRepository.GetByIdAsync(categoryId)
                ?? throw new NotFoundException("Category was not found.");

            var productEntities = await _productRepository.GetByCategoryIdAsync(categoryId);
            var productWithCategoryViewDtos = _mapper.Map<IEnumerable<ProductWithCategoryViewDto>>(productEntities);

            return productWithCategoryViewDtos;
        }

        public async Task<ProductViewDto> GetByIdAsync(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Product was not found.");

            var productViewDto = _mapper.Map<ProductViewDto>(productEntity);

            return productViewDto;
        }

        public async Task<ProductViewDto> CreateAsync(ProductCreateDto productCreateDto)
        {
            ArgumentNullException.ThrowIfNull(productCreateDto, nameof(productCreateDto));

            var productEntity = _mapper.Map<ProductEntity>(productCreateDto);

            var createdProductEntity = await _productRepository.CreateAsync(productEntity);
            var productViewDto = _mapper.Map<ProductViewDto>(createdProductEntity);

            return productViewDto;
        }

        public async Task UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            ArgumentNullException.ThrowIfNull(productUpdateDto, nameof(productUpdateDto));

            var existingProductEntity = await _productRepository.GetByIdAsync(productUpdateDto.Id)
                ?? throw new NotFoundException("Product was not found.");

            var productEntity = _mapper.Map<ProductEntity>(productUpdateDto);

            await _productRepository.UpdateAsync(productEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var existingProductEntity = await _productRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Product was not found.");

            await _productRepository.DeleteAsync(id);
        }
    }
}
