﻿using Microsoft.AspNetCore.Mvc;
using System;

namespace Object_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            var image = System.IO.File.OpenRead("res/maket1.jpg");
            return File(image, "image/jpg");
        }
    }
}