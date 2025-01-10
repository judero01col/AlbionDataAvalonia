using AlbionDataAvalonia.Locations;
using AlbionDataAvalonia.Logging;
using AlbionDataAvalonia.Network.Models;
using AlbionDataAvalonia.Network.Services;
using AlbionDataAvalonia.Settings;
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
    public partial class RadarViewModel : ViewModelBase
    {
        private readonly ListSink _listSink;
        private readonly SettingsManager _settingsManager;
        private readonly MarketOrderService _marketOrderService;

        [ObservableProperty]
        private string filterText = string.Empty;

        private ObservableCollection<MarketOrder> orders = new();
        public ObservableCollection<MarketOrder> Orders
        {
            get { return orders; }
            set { SetProperty(ref orders, value); }
        }

        private List<MarketOrder> UnfilteredTrades { get; set; } = new();

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

        partial void OnFilterTextChanged(string? oldValue, string newValue) => FilterTrades();
        partial void OnSelectedLocationChanged(string? oldValue, string newValue) => Task.Run(() => LoadOrders());
        partial void OnSelectedOperationChanged(string? oldValue, string newValue) => Task.Run(() => LoadOrders());
        partial void OnSelectedTradeTypeChanged(string? oldValue, string newValue) => Task.Run(() => LoadOrders());
        partial void OnSelectedServerChanged(string? oldValue, string newValue) => Task.Run(() => LoadOrders());


        public RadarViewModel()
        {

        }

        public RadarViewModel(ListSink listSink, SettingsManager settingsManager, MarketOrderService marketOrderService)
        {
            _listSink = listSink;
            _settingsManager = settingsManager;
            _marketOrderService = marketOrderService;

            _marketOrderService.OnOrderAdded += HandleOrderAdded;
            
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

                UnfilteredTrades = await _marketOrderService.GetOrders( 0, 0, server?.Id ?? null);
                FilterTrades();
            }
            catch
            {
                Log.Error("Failed to load trades");
            }
        }

        private async void HandleOrderAdded(List<MarketOrder> orders)
        {
            await LoadOrders();
        }

        private void FilterTrades()
        {
            List<MarketOrder> filteredList;

            if (!string.IsNullOrEmpty(FilterText))
            {
                filteredList = UnfilteredTrades.Where(x => x.ItemName.Replace(" ", "").Contains(FilterText.Replace(" ", ""), StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                filteredList = UnfilteredTrades;
            }
            Orders = new ObservableCollection<MarketOrder>(filteredList.OrderByDescending(x => x.Expires).Take(_settingsManager.UserSettings.TradesToShow));
        }
    }
}
