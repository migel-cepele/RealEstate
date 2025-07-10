using RealEstate.API.Application.Common;
using RealEstate.API.Application.Common.Constants;
using RealEstate.API.Application.Interfaces;
using RealEstate.API.Domain;

namespace RealEstate.API.Application.Services
{
    public class ItemStatisticsService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IClientItemRepository _clientItemRepository;
        private readonly IClientRepository _clientRepository;
        public ItemStatisticsService(IItemRepository itemRepository, IClientItemRepository clientItemRepository, IClientRepository clientRepository)
        {
            _itemRepository = itemRepository;
            _clientItemRepository = clientItemRepository;
            _clientRepository = clientRepository;
        }

        public List<Item> GetItemsWithMaxPrice(string? saleType, bool isActive = true)
        {
            var items = _itemRepository.GetAll();
            items = items.Where(x => x.IsActive == isActive).ToList();
            if (saleType != null)
            {
                items = items.Where(x => x.SaleType == saleType).ToList();
            }
            if (!items.Any()) return new List<Item>();
            decimal maxPrice = items.Max(x => x.Price);
            return items.Where(x => x.Price == maxPrice).ToList();
        }

        public List<Item> GetItemWithMinPrice(string? saleType, bool isActive = true)
        {
            var items = _itemRepository.GetAll();
            items = items.Where(x => x.IsActive == isActive).ToList();
            if (saleType != null)
            {
                items = items.Where(x => x.SaleType == saleType).ToList();
            }
            if (!items.Any()) return new List<Item>();
            decimal minPrice = items.Min(x => x.Price);
            return items.Where(x => x.Price == minPrice).ToList();
        }

        public decimal GetAverageItemPrice(string? saleType, bool isActive = true)
        {
            var items = _itemRepository.GetAll();
            items = items.Where(x => x.IsActive == isActive).ToList();
            if (saleType != null)
            {
                items = items.Where(x => x.SaleType == saleType).ToList();
            }
            if (!items.Any()) return 0;
            return Math.Round(items.Average(x => x.Price), 2);
        }

        public int GetTotalItemsAvailableNo(string? saleType, bool isActive = true)
        {
            var items = _itemRepository.GetAll();
            items = items.Where(x => x.IsActive == isActive).ToList();
            if (saleType != null)
            {
                items = items.Where(x => x.SaleType == saleType).ToList();
            }
            return items.Count;
        }

        public int GetTotalItemsGivenNo(string? itemStatus, string timeInterval)
        {
            CalculateTimeInterval calculateTimeInterval = new CalculateTimeInterval();
            calculateTimeInterval.Calculate(timeInterval);
            List<ClientItem> clientItems;
            if (!string.IsNullOrEmpty(itemStatus))
            {
                clientItems = _clientItemRepository.GetByStatus(itemStatus);
            }
            else
            {
                clientItems = _clientItemRepository.GetAll();
            }
            clientItems = clientItems.Where(x => x.CreatedAt >= calculateTimeInterval.StartDateTime && x.CreatedAt <= calculateTimeInterval.EndDateTime).ToList();
            return clientItems.Count;
        }

        public int GetTotalItemsGivenNo(string? itemStatus, DateTime startDate, DateTime endDate)
        {
            List<ClientItem> clientItems;
            if (!string.IsNullOrEmpty(itemStatus))
            {
                clientItems = _clientItemRepository.GetByStatus(itemStatus);
            }
            else
            {
                clientItems = _clientItemRepository.GetAll();
            }
            clientItems = clientItems.Where(x => x.CreatedAt >= startDate && x.CreatedAt <= endDate).ToList();
            return clientItems.Count;
        }

        public Dictionary<DateTime, int> GetItemsAdded(string? saleType, string timeInterval)
        {
            CalculateTimeInterval calculateTimeInterval = new CalculateTimeInterval();
            calculateTimeInterval.Calculate(timeInterval);
            var items = _itemRepository.GetAll();
            if (saleType != null)
            {
                items = items.Where(x => x.SaleType == saleType).ToList();
            }
            items = items.Where(x => x.CreatedAt >= calculateTimeInterval.StartDateTime && x.CreatedAt <= calculateTimeInterval.EndDateTime).ToList();
            if (!items.Any()) return new Dictionary<DateTime, int>();
            return items.GroupBy(x => x.CreatedAt.Date).OrderBy(x => x.Key).ToDictionary(g => g.Key, g => g.Count());
        }

        public Dictionary<DateTime, int> GetItemsAdded(string? saleType, DateTime startDate, DateTime endDate)
        {
            var items = _itemRepository.GetAll();
            if (saleType != null)
            {
                items = items.Where(x => x.SaleType == saleType).ToList();
            }
            items = items.Where(x => x.CreatedAt >= startDate && x.CreatedAt <= endDate).ToList();
            if (!items.Any()) return new Dictionary<DateTime, int>();
            return items.GroupBy(x => x.CreatedAt.Date).OrderBy(x => x.Key).ToDictionary(g => g.Key, g => g.Count());
        }

        public Dictionary<DateTime, int> GetItemsGiven(string? itemStatus, string timeInterval)
        {
            CalculateTimeInterval calculateTimeInterval = new CalculateTimeInterval();
            calculateTimeInterval.Calculate(timeInterval);
            List<ClientItem> clientItems;
            if (!string.IsNullOrEmpty(itemStatus))
            {
                clientItems = _clientItemRepository.GetByStatus(itemStatus);
            }
            else
            {
                clientItems = _clientItemRepository.GetAll();
            }
            clientItems = clientItems.Where(x => x.CreatedAt >= calculateTimeInterval.StartDateTime && x.CreatedAt <= calculateTimeInterval.EndDateTime).ToList();
            if (!clientItems.Any()) return new Dictionary<DateTime, int>();
            return clientItems.GroupBy(x => x.CreatedAt.Date).OrderBy(x => x.Key).ToDictionary(g => g.Key, g => g.Count());
        }

        public Dictionary<DateTime, int> GetItemsGiven(string? itemStatus, DateTime startDate, DateTime endDate)
        {
            List<ClientItem> clientItems;
            if (!string.IsNullOrEmpty(itemStatus))
            {
                clientItems = _clientItemRepository.GetByStatus(itemStatus);
            }
            else
            {
                clientItems = _clientItemRepository.GetAll();
            }
            clientItems = clientItems.Where(x => x.CreatedAt >= startDate && x.CreatedAt <= endDate).ToList();
            if (!clientItems.Any()) return new Dictionary<DateTime, int>();
            return clientItems.GroupBy(x => x.CreatedAt.Date).OrderBy(x => x.Key).ToDictionary(g => g.Key, g => g.Count());
        }

        public Dictionary<DateTime, decimal> GetItemsGivenPriceSum(string? itemStatus, string timeInterval)
        {
            CalculateTimeInterval calculateTimeInterval = new CalculateTimeInterval();
            calculateTimeInterval.Calculate(timeInterval);
            List<ClientItem> clientItems;
            if (!string.IsNullOrEmpty(itemStatus))
            {
                clientItems = _clientItemRepository.GetByStatus(itemStatus);
            }
            else
            {
                clientItems = _clientItemRepository.GetAll();
            }
            clientItems = clientItems.Where(x => x.CreatedAt >= calculateTimeInterval.StartDateTime && x.CreatedAt <= calculateTimeInterval.EndDateTime).ToList();
            if (!clientItems.Any()) return new Dictionary<DateTime, decimal>();
            return clientItems.GroupBy(x => x.CreatedAt.Date).OrderBy(x => x.Key).ToDictionary(g => g.Key, g => g.Sum(x => x.Price));
        }

        public Dictionary<DateTime, decimal> GetItemsGivenPriceSum(string? itemStatus, DateTime startDate, DateTime endDate)
        {
            List<ClientItem> clientItems;
            if (!string.IsNullOrEmpty(itemStatus))
            {
                clientItems = _clientItemRepository.GetByStatus(itemStatus);
            }
            else
            {
                clientItems = _clientItemRepository.GetAll();
            }
            clientItems = clientItems.Where(x => x.CreatedAt >= startDate && x.CreatedAt <= endDate).ToList();
            if (!clientItems.Any()) return new Dictionary<DateTime, decimal>();
            return clientItems.GroupBy(x => x.CreatedAt.Date).OrderBy(x => x.Key).ToDictionary(g => g.Key, g => g.Sum(x => x.Price));
        }
    }
}
