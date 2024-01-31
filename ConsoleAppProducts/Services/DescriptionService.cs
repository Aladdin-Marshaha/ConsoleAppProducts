using ConsoleAppProducts.Entities;
using ConsoleAppProducts.Repositories;
using System.Diagnostics;

namespace ConsoleAppProducts.Services;

internal class DescriptionService
{
    private readonly DescriptionRepository _descriptionRepository;

    public DescriptionService(DescriptionRepository descriptionRepository)
    {
        _descriptionRepository = descriptionRepository;
    }

    public DescriptionEntity CreateDescription(string ingress, string description, string specifications)
    {
        try
        {
            var descriptionEntity = _descriptionRepository.Get(x => x.Ingress == ingress && x.Description == description && x.Specifications == specifications);
            if (descriptionEntity == null)
            {
                descriptionEntity = _descriptionRepository.Create(new DescriptionEntity { Ingress = ingress, Description = description, Specifications = specifications });
            }

            return descriptionEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }

    }

    public DescriptionEntity GetDescriptionByIngress(string ingress)
    {
        try
        {
            var descriptionEntity = _descriptionRepository.Get(x => x.Ingress == ingress);
            return descriptionEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public DescriptionEntity GetDescriptionById(int id)
    {
        try
        {
            var descriptionEntity = _descriptionRepository.Get(x => x.Id == id);
            return descriptionEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public IEnumerable<DescriptionEntity> GetAllDescriptions()
    {
        try
        {
            var Descriptions = _descriptionRepository.GetAll();
            return Descriptions;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public DescriptionEntity UpdateDescription(DescriptionEntity descriptionEntity)
    {
        try
        {
            var updatedDescriptionEntity = _descriptionRepository.Update(x => x.Id == descriptionEntity.Id, descriptionEntity);
            return updatedDescriptionEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public void DeleteDescription(int id)
    {
        try
        {
            _descriptionRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
