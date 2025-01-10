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

    [NotMapped]
    public string AuctionTypeFormatted
    {//AuctionType? type = SelectedType == "Sold" ? AuctionType.offer : SelectedType == "Bought" ? AuctionType.request : null;
        get
        {
            switch (AuctionType)
            {
                case AuctionType.offer:
                    return "Sold";
                case AuctionType.request:
                    return "Bought";
                default:
                    return "Unknown";
            }
        }
    }

   
    [NotMapped]
    public string QualityLevelFormatted
    {
        get
        {
            return QualityLevel switch
            {
                1 => "Normal",
                2 => "Good",
                3 => "Outstanding",
                4 => "Excellent",
                8 => "Masterpiece",
                _ => "Unknown"
            };
        }
    }

    public void SetData(string mailString)
    {

    }
}
