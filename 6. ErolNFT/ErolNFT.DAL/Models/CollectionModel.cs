namespace ErolNFT.DAL.Models;

public class CollectionModel : BaseModel
{
    public required string Name { get; set; }
    public string Category { get; set; } = string.Empty;
    public int ItemsIn { get; set; } = 0;
    public int ItemsTotal { get; set; } = 0;
    public string ImgFilename { get; set; } = string.Empty;
}
