﻿namespace ErolCarvilla.Models;

public class FeaturedCar : BaseModel
{
    public required string Name { get; set; }
    public int Model { get; set; }
    public double Price { get; set; }
    public int HorsePower { get; set; }
    public int Mi { get; set; }
    public bool IsManual { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageName { get; set; } = "undefined.png";
}
