﻿namespace GemVogue.Data.Models;

public class Brand
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public List<Jewel> Jewels { get; set; } = new ();
}