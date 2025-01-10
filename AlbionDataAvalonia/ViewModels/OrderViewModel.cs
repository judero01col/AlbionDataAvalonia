using AlbionDataAvalonia.Locations;
using AlbionDataAvalonia.Logging;
using AlbionDataAvalonia.Network.Models;
using AlbionDataAvalonia.Network.Services;
using AlbionDataAvalonia.Settings;
using AlbionDataAvalonia.State;
using Avalonia.Animation;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AlbionDataAvalonia.ViewModels
{
    public partial class OrderViewModel : ViewModelBase
    {
        private readonly SettingsManager _settingsManager;
        private readonly PlayerState _playerState;
        private readonly TradeService _tradeService;
        private readonly MarketOrderService _marketOrderService;

        [ObservableProperty]
        private string filterText = string.Empty;

        private ObservableCollection<MarketOrder> orders = new();
        public ObservableCollection<MarketOrder> Orders
        {
            get { return orders; }
            set { SetProperty(ref orders, value); }
        }

        private List<MarketOrder> UnfilteredOrders { get; set; } = new();

        public List<string> Locations { get; set; } = new();
        [ObservableProperty]
        private string selectedLocation = "Any";

        public List<string> TradeOperations { get; set; } = new() { "Any", "Bought", "Sold" };
        [ObservableProperty]
        private string selectedOperation = "Any";

        public List<string> TradeTypes { get; set; } = new() { "Any", "Instant", "Order" };
        [ObservableProperty]
        private string selectedTradeType = "Any";

        public List<string> Servers { get; set; } = new();
        [ObservableProperty]
        private string selectedServer = "Any";


        partial void OnFilterTextChanged(string? oldValue, string newValue) => FilterOrders();
        partial void OnSelectedLocationChanged(string? oldValue, string newValue) => Task.Run(() => LoadOrders());
        partial void OnSelectedOperationChanged(string? oldValue, string newValue) => Task.Run(() => LoadOrders());
        partial void OnSelectedTradeTypeChanged(string? oldValue, string newValue) => Task.Run(() => LoadOrders());
        partial void OnSelectedServerChanged(string? oldValue, string newValue) => Task.Run(() => LoadOrders());


        public OrderViewModel()
        {
        }

        public OrderViewModel(SettingsManager settingsManager, PlayerState playerState, TradeService tradeService, MarketOrderService marketOrderService)
        {
            _settingsManager = settingsManager;
            _playerState = playerState;
            _tradeService = tradeService;
            _marketOrderService = marketOrderService;

            //_tradeService.OnTradeAdded += HandleTradeAdded;

            Locations = AlbionLocations.GetAll().Select(x => x.FriendlyName).OrderBy(x => x).ToList();
            Locations.Insert(0, "Any");

            Servers = AlbionServers.GetAll().Select(x => x.Name).ToList();
            Servers.Insert(0, "Any");

            _playerState.OnPlayerStateChanged += (sender, args) =>
            {
                var currentServer = playerState.AlbionServer?.Name ?? "Any";

                if (SelectedServer != currentServer)
                {
                    SelectedServer = currentServer;
                    Task.Run(() => LoadOrders());
                }
            };
        }

        [RelayCommand]
        public async Task LoadOrders()
        {
            try
            {
                var location = AlbionLocations.Get(SelectedLocation);

                AlbionServers.TryParse(SelectedServer, out AlbionServer? server);
                TradeType? tradeType = SelectedTradeType == "Instant" ? TradeType.Instant : SelectedTradeType == "Order" ? TradeType.Order : null;
                TradeOperation? tradeOperation = SelectedOperation == "Sold" ? TradeOperation.Sell : SelectedOperation == "Bought" ? TradeOperation.Buy : null;

                UnfilteredOrders = await _marketOrderService.GetOrders(_settingsManager.UserSettings.OrdersPerPage, 0, server?.Id ?? null);
                //UnfilteredTrades = _tradeService.GetMarketOrderFromCache();

                FilterOrders();
            }
            catch
            {
                Log.Error("Failed to load trades");
            }
        }       

        private void FilterOrders()
        {
            List<MarketOrder> filteredList;

            if (!string.IsNullOrEmpty(FilterText))
            {
                filteredList = UnfilteredOrders.Where(x => x.ItemName.Replace(" ", "").Contains(FilterText.Replace(" ", ""), StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                filteredList = UnfilteredOrders;
            }
            Orders = new ObservableCollection<MarketOrder>(filteredList.OrderByDescending(x => x.Expires).Take(_settingsManager.UserSettings.TradesToShow));
        }

        private async void HandleTradeAdded(Trade trade)
        {
            await LoadOrders();
        }
    }
}
