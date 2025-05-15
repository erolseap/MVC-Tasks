namespace ErolGYM.DAL.Models;

public class GymProgram : BaseModel
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImgFilename { get; set; } = "default.png";
}
