using ConsoleAppProducts.Entities;
using ConsoleAppProducts.Repositories;
using System.Diagnostics;

namespace ConsoleAppProducts.Services;

internal class CategoryService
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public CategoryEntity CreateCategory(string categoryName)
    {
        try
        {
            var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
            if (categoryEntity == null)
            {
                categoryEntity = _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName });
            }
            return categoryEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public CategoryEntity GetCategoryByCategoryName(string categoryName)
    {
        try
        {
            var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
            return categoryEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public CategoryEntity GetCategoryById(int id)
    {
        try
        {
            var categoryEntity = _categoryRepository.Get(x => x.Id == id);
            return categoryEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public IEnumerable<CategoryEntity> GetAllCategories()
    {
        try
        {
            var categories = _categoryRepository.GetAll();
            return categories;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        try
        {
            var updatedCategoryEntity = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
            return updatedCategoryEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }

    }

    public void DeleteCategory(int id)
    {
        try
        {
            _categoryRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}