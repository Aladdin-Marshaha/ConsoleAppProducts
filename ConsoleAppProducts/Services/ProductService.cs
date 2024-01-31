using ConsoleAppProducts.Entities;
using ConsoleAppProducts.Repositories;
using System.Diagnostics;

namespace ConsoleAppProducts.Services;

internal class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryService _categoryService;
    private readonly ManufacturerService _manufacturerService;
    private readonly DescriptionService _descriptionService;
    private readonly PriceListService _priceListService;

    public ProductService(ProductRepository productRepository, CategoryService categoryService, ManufacturerService manufacturerService, DescriptionService descriptionService, PriceListService priceListService)
    {
        _productRepository = productRepository;
        _categoryService = categoryService;
        _manufacturerService = manufacturerService;
        _descriptionService = descriptionService;
        _priceListService = priceListService;
    }

    public ProductEntity CreateProduct(string articleNumber, string title, string manufacturerName, string ingress, string description, string specifications, decimal price, decimal discountPrice, string categoryName)
    {
        try
        {
            var categoryEntity = _categoryService.CreateCategory(categoryName);
            var manufacturerEntity = _manufacturerService.CreateManufacturer(manufacturerName);
            var descriptionEntity = _descriptionService.CreateDescription(ingress, description, specifications);
            var priceListEntity = _priceListService.CreatePriceList(price, discountPrice);


            var productEntity = new ProductEntity
            {
                ArticleNumber = articleNumber,
                Title = title,
                CategoryId = categoryEntity.Id,
                ManufacturerId = manufacturerEntity.Id,
                DescriptionId = descriptionEntity.Id,
                PriceListId = priceListEntity.Id,

            };

            productEntity = _productRepository.Create(productEntity);
            return productEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public ProductEntity GetProductByArticleNumber (string articleNumber)
    {
        try
        {
            var productEntity = _productRepository.Get(x => x.ArticleNumber == articleNumber);
            return productEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public IEnumerable<ProductEntity> GetProducts ()
    {
        try
        {
            return _productRepository.GetAll();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public ProductEntity UpdateProduct(ProductEntity productEntity)
    {
        try
        {
            var updatedProductEntity = _productRepository.Update(x => x.ArticleNumber == productEntity.ArticleNumber, productEntity);
            return updatedProductEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public bool DeleteProduct (string articleNumber)
    {
        try
        {
            _productRepository.Delete(x => x.ArticleNumber == articleNumber);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

}
