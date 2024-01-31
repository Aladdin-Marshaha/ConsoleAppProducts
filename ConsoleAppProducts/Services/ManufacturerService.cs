using ConsoleAppProducts.Entities;
using ConsoleAppProducts.Repositories;
using System.Diagnostics;

namespace ConsoleAppProducts.Services;

internal class ManufacturerService
{
    private readonly ManufacturerRepository _manufacturerRepository;

    public ManufacturerService(ManufacturerRepository manufactureRepository)
    {
        _manufacturerRepository = manufactureRepository;
    }

    public ManufacturerEntity CreateManufacturer(string manufacturerName)
    {
        try
        {
            var manufacturerEntity = _manufacturerRepository.Get(x => x.ManufacturerName == manufacturerName);
            if (manufacturerEntity == null)
            {
                manufacturerEntity = _manufacturerRepository.Create(new ManufacturerEntity { ManufacturerName = manufacturerName });
            }

            return manufacturerEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public ManufacturerEntity GetManufacturerByManufacturerName(string manufacturerName)
    {
        try
        {
            var manufacturerEntity = _manufacturerRepository.Get(x => x.ManufacturerName == manufacturerName);
            return manufacturerEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public ManufacturerEntity GetManufacturerById(int id)
    {
        try
        {
            var manufacturerEntity = _manufacturerRepository.Get(x => x.Id == id);
            return manufacturerEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public IEnumerable<ManufacturerEntity> GetAllManufacturers()
    {
        try
        {
            var manufacturers = _manufacturerRepository.GetAll();
            return manufacturers;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public ManufacturerEntity UpdateManufacturer(ManufacturerEntity manufacturerEntity)
    {
        try
        {
            var updatedManufacturerEntity = _manufacturerRepository.Update(x => x.Id == manufacturerEntity.Id, manufacturerEntity);
            return updatedManufacturerEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public void DeleteManufacturer(int id)
    {
        try
        {
            _manufacturerRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
