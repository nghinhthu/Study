using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KendoUI.Controllers
{
    public abstract class EditorFileBrowserController : BaseFileBrowserController
    {
        /// <summary>
        /// Gets the valid file extensions by which served files will be filtered.
        /// </summary>
        public override string Filter
        {
            get
            {
                return EditorFileBrowserSettings.DefaultFileTypes;
            }
        }

        public EditorFileBrowserController(IHostingEnvironment hostingEnvironment)
            : base(hostingEnvironment)
        {

        }
    }
}
