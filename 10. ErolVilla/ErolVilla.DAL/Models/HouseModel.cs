namespace ErolVilla.DAL.Models;

public class HouseModel : BaseModel
{
    public required string Name { get; set; }
    public string Note { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0.0m;
    public int BedroomsCount { get; set; } = 0;
    public int BathroomsCount { get; set; } = 0;
    public int Area { get; set; } = 0;
    public int Floor { get; set; } = 0;
    public int ParkingSpotsCount { get; set; } = 0;
    public string ImgFilename { get; set; } = string.Empty;
}
