using ConsoleAppProducts.Entities;
using ConsoleAppProducts.Repositories;
using System.Diagnostics;

namespace ConsoleAppProducts.Services;

internal class PriceListService
{
    private readonly PriceListRepository _priceListRepository;

    public PriceListService(PriceListRepository priceListRepository)
    {
        _priceListRepository = priceListRepository;
    }

    public PriceListEntity CreatePriceList(decimal price, decimal discountPrice )
    {
        try
        {
            var priceListEntity = _priceListRepository.Get(x => x.Price == price && x.DiscountPrice == discountPrice);
            if (priceListEntity == null)
            {
                priceListEntity = _priceListRepository.Create(new PriceListEntity { Price = price, DiscountPrice = discountPrice });
            }

            return priceListEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public PriceListEntity GetPriceListById(int id)
    {
        try
        {
            var priceListEntity = _priceListRepository.Get(x => x.Id == id);
            return priceListEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public IEnumerable<PriceListEntity> GetAllPriceLists()
    {
        try
        {
            var priceLists = _priceListRepository.GetAll();
            return priceLists;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public PriceListEntity UpdatePriceList(PriceListEntity priceListEntity)
    {
        try
        {
            var updatedPriceListEntity = _priceListRepository.Update(x => x.Id == priceListEntity.Id, priceListEntity);
            return updatedPriceListEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public void DeletePriceList(int id)
    {
        try
        {
            _priceListRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
