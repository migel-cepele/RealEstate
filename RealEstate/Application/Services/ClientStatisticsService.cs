using RealEstate.API.Application.Common;
using RealEstate.API.Application.Common.Constants;
using RealEstate.API.Application.Interfaces;
using RealEstate.API.Domain;

namespace RealEstate.API.Application.Services
{
    public class ClientStatisticsService
    {
        private readonly IClientItemRepository _clientItemRepository;
        private readonly IClientRepository _clientRepository;
        public ClientStatisticsService(IClientItemRepository clientItemRepository, IClientRepository clientRepository)
        {
            _clientItemRepository = clientItemRepository;
            _clientRepository = clientRepository;
        }

        // nr i klienteve total aktive ose jo ne sistem
        public int GetTotalClients(bool? isActive = true)
        {
            var clients = _clientRepository.GetAll();
            if (isActive.HasValue)
            {
                clients = clients.Where(x => x.IsActive == isActive).ToList();
            }
            return clients.Count;
        }

        // shuma minimale e shpenzuar nga klientet ne nje status te caktuar
        public Client? GetClientMin(string? itemStatus)
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
            if (!clientItems.Any()) return null;

            var groupedClients = clientItems
                .GroupBy(ci => ci.ClientId)
                .Select(g => new
                {
                    ClientId = g.Key,
                    TotalPrice = g.Sum(ci => ci.Price)
                });
            var minClient = groupedClients.ToList()
                .OrderBy(x => x.TotalPrice)
                .FirstOrDefault();
            if (minClient == null)
            {
                return null;
            }
            return _clientRepository.GetById(minClient.ClientId);
        }

        // klienti me shumen maksimale te shpenzuar per nje status te caktuar
        public Client? GetClientMax(string? itemStatus)
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
            if (!clientItems.Any()) return null;

            var groupedClients = clientItems
                .GroupBy(ci => ci.ClientId)
                .Select(g => new
                {
                    ClientId = g.Key,
                    TotalPrice = g.Sum(ci => ci.Price)
                });
            var maxClient = groupedClients.ToList()
                .OrderByDescending(x => x.TotalPrice)
                .FirstOrDefault();
            if (maxClient == null)
            {
                return null;
            }
            return _clientRepository.GetById(maxClient.ClientId);
        }

        // shuma totale e shpenzuar per cdo date nga klienti ne nje interval fiks kohor
        public Dictionary<DateTime, decimal> GetClientActivityHistory(long clientId, string? itemStatus, string timeInterval)
        {
            CalculateTimeInterval calculateTimeInterval = new CalculateTimeInterval();
            calculateTimeInterval.Calculate(timeInterval);

            List<ClientItem> clientItems;
            if (!string.IsNullOrEmpty(itemStatus))
            {
                clientItems = _clientItemRepository.GetByClientId(clientId)
                    .Where(ci => ci.Status == itemStatus).ToList();
            }
            else
            {
                clientItems = _clientItemRepository.GetByClientId(clientId);
            }

            clientItems = clientItems
                .Where(ci => ci.CreatedAt >= calculateTimeInterval.StartDateTime && ci.CreatedAt <= calculateTimeInterval.EndDateTime)
                .ToList();

            if (!clientItems.Any()) return new Dictionary<DateTime, decimal>();

            return clientItems
                .GroupBy(ci => ci.CreatedAt.Date)
                .ToDictionary(g => g.Key, g => g.Sum(ci => ci.Price));
        }

        // shuma totale e shpenzuar per cdo date nga klienti ne nje interval te caktuar kohor
        public Dictionary<DateTime, decimal> GetClientActivityHistory(long clientId, string? itemStatus, DateTime startDate, DateTime endDate)
        {

            List<ClientItem> clientItems;
            if (!string.IsNullOrEmpty(itemStatus))
            {
                clientItems = _clientItemRepository.GetByClientId(clientId)
                    .Where(ci => ci.Status == itemStatus).ToList();
            }
            else
            {
                clientItems = _clientItemRepository.GetByClientId(clientId);
            }

            clientItems = clientItems
                .Where(ci => ci.CreatedAt >= startDate && ci.CreatedAt <= endDate)
                .ToList();

            if (!clientItems.Any()) return new Dictionary<DateTime, decimal>();

            return clientItems
                .GroupBy(ci => ci.CreatedAt.Date)
                .ToDictionary(g => g.Key, g => g.Sum(ci => ci.Price));
        }

        //nr total i klienteve te regjistruar per cdo date ne nje interval fiks kohor
        public Dictionary<DateTime, int> GetClientsAdded(string timeInterval)
        {
            CalculateTimeInterval calculateTimeInterval = new CalculateTimeInterval();
            calculateTimeInterval.Calculate(timeInterval);
            var clients = _clientRepository.GetAll()
                .Where(c => c.CreatedAt >= calculateTimeInterval.StartDateTime && c.CreatedAt <= calculateTimeInterval.EndDateTime)
                .GroupBy(c => c.CreatedAt.Date)
                .ToDictionary(g => g.Key, g => g.Count());
            return clients ?? new Dictionary<DateTime, int>();
        }

        //nr total i klienteve te regjistruar per cdo date ne nje interval te caktuar kohor
        public Dictionary<DateTime, int> GetClientsAddedInterval(DateTime startDate, DateTime endDate)
        {

            var clients = _clientRepository.GetAll()
                .Where(c => c.CreatedAt >= startDate && c.CreatedAt <= endDate)
                .GroupBy(c => c.CreatedAt.Date)
                .ToDictionary(g => g.Key, g => g.Count());
            return clients ?? new Dictionary<DateTime, int>();
        }

        // lista e top n klientëve me prioritet të lartë
        public List<Client> GetClientsWithHighestPriority(int topN)
        {
            var allClients = _clientRepository.GetAll();
            var sortedClients = allClients
                .Where(c => c.PriorityNo.HasValue)
                .OrderByDescending(c => c.PriorityNo ?? 0)
                .Take(topN)
                .ToList();
            return sortedClients ?? new List<Client>();
        }

        //shuma totale e shpenzuar per cdo date nga top n klietet me prioritet te larte ne nje interval fiks kohor
        public Dictionary<DateTime, decimal> GetClientPriorityHistory(int topN, string timeInterval, string? itemStatus)
        {
            CalculateTimeInterval calculateTimeInterval = new CalculateTimeInterval();
            calculateTimeInterval.Calculate(timeInterval);

            List<Client> topClients = GetClientsWithHighestPriority(topN);
            if (!topClients.Any()) return new Dictionary<DateTime, decimal>();

            List<ClientItem> clientItems;
            if (!string.IsNullOrEmpty(itemStatus))
            {
                clientItems = _clientItemRepository.GetAll()
                .Where(ci => topClients.Select(c => c.Id).Contains(ci.ClientId))
                .Where(ci => ci.CreatedAt >= calculateTimeInterval.StartDateTime && ci.CreatedAt <= calculateTimeInterval.EndDateTime
                        && ci.Status == itemStatus)
                .ToList();
            }
            else
            {
                clientItems = _clientItemRepository.GetAll()
                .Where(ci => topClients.Select(c => c.Id).Contains(ci.ClientId))
                .Where(ci => ci.CreatedAt >= calculateTimeInterval.StartDateTime && ci.CreatedAt <= calculateTimeInterval.EndDateTime)
                .ToList();
            }


            if (!clientItems.Any()) return new Dictionary<DateTime, decimal>();

            return clientItems
                .GroupBy(ci => ci.CreatedAt.Date)
                .ToDictionary(g => g.Key, g => g.Sum(ci => ci.Price));
        }

        //shuma totale e shpenzuar per cdo date nga top n klientet me prioritet te larte ne nje interval te caktuar kohor
        public Dictionary<DateTime, decimal> GetClientPriorityHistoryInterval(int topN, DateTime startDate, DateTime endDate, string? itemStatus)
        {
            List<Client> topClients = GetClientsWithHighestPriority(topN);
            if (!topClients.Any()) return new Dictionary<DateTime, decimal>();

            List<ClientItem> clientItems;
            if (!string.IsNullOrEmpty(itemStatus))
            {
                clientItems = _clientItemRepository.GetAll()
                .Where(ci => topClients.Select(c => c.Id).Contains(ci.ClientId))
                .Where(ci => ci.CreatedAt >= startDate && ci.CreatedAt <= endDate
                        && ci.Status == itemStatus)
                .ToList();
            }
            else
            {
                clientItems = _clientItemRepository.GetAll()
                .Where(ci => topClients.Select(c => c.Id).Contains(ci.ClientId))
                .Where(ci => ci.CreatedAt >= startDate && ci.CreatedAt <= endDate)
                .ToList();
            }

            if (!clientItems.Any()) return new Dictionary<DateTime, decimal>();

            return clientItems
                .GroupBy(ci => ci.CreatedAt.Date)
                .ToDictionary(g => g.Key, g => g.Sum(ci => ci.Price));
        }
    }
}
