using AlbionDataAvalonia.Locations.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlbionDataAvalonia.Network.Models;

public class MarketOrder
{
    public ulong Id { get; set; }
    public int AlbionServerId { get; set; }
    public string ItemTypeId { get; set; }
    public string ItemGroupTypeId { get; set; }
    public int LocationId { get; set; }
    public byte QualityLevel { get; set; }
    public byte EnchantmentLevel { get; set; }
    public ulong UnitPriceSilver { get; set; }
    public uint Amount { get; set; }
    public AuctionType AuctionType { get; set; }
    public DateTime Expires { get; set; }
    public bool Deleted { get; set; }
    public ulong UnitSilver => (UnitPriceSilver / 10000);
    public ulong TotalSilver => (ulong)(UnitSilver * (ulong)Amount);

    [NotMapped]
    public string ItemName { get; set; } = string.Empty;

    [NotMapped]
    public AlbionLocation? Location { get; set; }

    [NotMapped]
    public AlbionServer? Server { get; set; }

    public void SetData(string mailString)
    {

    }
}
