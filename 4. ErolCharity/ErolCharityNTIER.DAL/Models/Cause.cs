namespace ErolCharityNTIER.DAL.Models;

public class Cause : BaseModel
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Raised { get; set; } = 0.0m;
    public decimal Goal { get; set; } = 0.0m;
    public string ImgFilename { get; set; } = "undefined.png";
}
