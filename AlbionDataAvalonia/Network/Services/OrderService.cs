using AlbionDataAvalonia.DB;
using AlbionDataAvalonia.Localization.Services;
using AlbionDataAvalonia.Locations;
using AlbionDataAvalonia.Migrations;
using AlbionDataAvalonia.Network.Models;
using AlbionDataAvalonia.Settings;
using AlbionDataAvalonia.State;
using Avalonia.Animation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDataAvalonia.Network.Services
{
    public class OrderService
    {
        private readonly PlayerState _playerState;
        private readonly SettingsManager _settingsManager;
        private readonly LocalizationService _localizationService;
        private List<MarketOrder> MarketOrders { get; set; } = new();
        public Action<List<MarketOrder>> OnOrderAdded;
        public Action<MarketOrder> OnOrderDataAdded;

        public OrderService(PlayerState playerState, SettingsManager settingsManager, LocalizationService localizationService)
        {
            _playerState = playerState;
            _settingsManager = settingsManager;
            _localizationService = localizationService;
        }

        public async Task<List<MarketOrder>> GetOrders(int countPerPage, int pageNumber = 0, int? albionServerId = null, bool showDeleted = false, int? locationId = null, AuctionType? auctionType = null)
        {
            try
            {
                using (var db = new LocalContext())
                {
                    var query = db.MarketOrders.AsQueryable();

                    if (albionServerId.HasValue)
                    {
                        query = query.Where(x => x.AlbionServerId == albionServerId);
                    }

                    if (locationId.HasValue)
                    {
                        query = query.Where(x => x.LocationId == locationId);
                    }

                    if (auctionType != null)
                    {
                        query = query.Where(x => x.AuctionType == auctionType);
                    }

                    if (!showDeleted)
                    {
                        query = query.Where(x => !x.Deleted);
                    }

                    var result = await query.OrderByDescending(x => x.Expires).AsNoTracking().Skip(countPerPage * pageNumber).Take(countPerPage).ToListAsync();

                    GetOrderProperties(result);

                    Log.Debug("Loaded {Count} mails", result.Count);

                    return result;
                }
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return new List<MarketOrder>();
            }
        }

        private void GetOrderProperties(List<MarketOrder> orders)
        {
            foreach (var order in orders)
            {
                order.Location = AlbionLocations.Get(order.LocationId);
                order.Server = AlbionServers.GetAll().SingleOrDefault(x => x.Id == order.AlbionServerId);
                order.ItemName = _localizationService.GetUsName(order.ItemTypeId);
            }

            Log.Verbose("Set order properties for {count} orders", orders.Count);
        }

        private void SetOrderProperties(List<MarketOrder> orders)
        {
            foreach (var order in orders)
            {
                order.Location = AlbionLocations.Get(order.LocationId);
                order.Server = AlbionServers.GetAll().SingleOrDefault(x => x.Id == order.AlbionServerId);
                order.ItemName = _localizationService.GetUsName(order.ItemTypeId);
            }

            Log.Verbose("Set order properties for {count} orders", orders.Count);
        }

        public async Task AddOrders(List<MarketOrder> orders)
        {
            try
            {
                using (var db = new LocalContext())
                {
                    var existingOrderIds = await db.MarketOrders.Select(x => x.Id).ToListAsync();
                    var newOrders = orders.Where(order => !existingOrderIds.Contains(order.Id)).ToList();

                    if (newOrders.Any())
                    {
                        await db.MarketOrders.AddRangeAsync(newOrders);
                        await db.SaveChangesAsync();

                        SetOrderProperties(newOrders);

                        OnOrderAdded?.Invoke(newOrders);

                        Log.Debug("Added {Count} new orders", newOrders.Count);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
            }
        }

        public async Task AddOrderData(ulong orderId, string orderString)
        {
            try
            {
                using (var db = new LocalContext())
                {
                    var order = await db.MarketOrders.Where(x => x.Id == orderId).SingleOrDefaultAsync();

                    if (order == null) return;

                    order.SetData(orderString);

                    await db.SaveChangesAsync();

                    SetOrderProperties(new List<MarketOrder>([order]));

                    OnOrderDataAdded?.Invoke(order);

                    Log.Debug("Added data for order {OrderId}", orderId);
                }
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
            }
        }

        public async Task DeleteOrder(ulong orderId)
        {
            try
            {
                using (var db = new LocalContext())
                {
                    var mail = await db.MarketOrders.Where(x => x.Id == orderId).SingleOrDefaultAsync();

                    if (mail == null) return;

                    mail.Deleted = true;

                    await db.SaveChangesAsync();

                    Log.Debug("Deleted order {OrderId}", orderId);
                }
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
            }
        }
    }
}
