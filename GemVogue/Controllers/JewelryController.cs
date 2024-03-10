namespace GemVogue.Controllers;

using Data;
using Microsoft.AspNetCore.Mvc;

public class JewelryController : Controller
{
    private readonly GemVogueDbContext data;
    private readonly IWebHostEnvironment env;

    public JewelryController(
        GemVogueDbContext data,
        IWebHostEnvironment env)
    {
        this.data = data;
        this.env = env;
    }

}