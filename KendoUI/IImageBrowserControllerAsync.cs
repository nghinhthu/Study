using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KendoUI
{
    public interface IImageBrowserControllerAsync
    {
        Task<IActionResult> Create(string name, FileBrowserEntry entry);
        Task<IActionResult> Destroy(string name, FileBrowserEntry entry);
        Task<IActionResult> Image(string path);
        Task<JsonResult> Read(string path);
        Task<IActionResult> Thumbnail(string path);
        Task<IActionResult> Upload(string name, IFormFile file);
    }
}
