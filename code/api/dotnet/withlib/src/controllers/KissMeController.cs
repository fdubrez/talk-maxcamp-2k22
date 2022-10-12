using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace peachme_api.controllers;

[ApiController]
[Route("kissme")]
public class WatermarkController : ControllerBase
{
    public class KissMeRequest
    {
        [Required]
        public string? Image { get; set; }
    }

    public class KissMeResponse
    {
        public string? Image { get; set; }
    }
    
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    public Task<KissMeResponse> KissMe([FromBody] KissMeRequest uploadModel)
    {
        using var image = Image.Load(Convert.FromBase64String(uploadModel.Image ?? ""));
        var fond = Image.Load("fond.png");
        var casquette = Image.Load("casquette.png");
        using var output = fond.Clone(ctx =>
        {
            ctx
                .DrawImage(image, new Point
                {
                    X= 0,
                    Y= 0
                }, PixelColorBlendingMode.Normal, 1)
                .DrawImage(casquette, new Point
                {
                    X= 0,
                    Y= 0
                }, PixelColorBlendingMode.Normal, 1) 
                ;
        });
        return Task.FromResult(new KissMeResponse { Image = output.ToBase64String(SixLabors.ImageSharp.Formats.Png.PngFormat.Instance) });
    }
}