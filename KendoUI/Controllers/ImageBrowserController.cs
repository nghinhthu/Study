﻿using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace KendoUI.Controllers
{
    public class ImageBrowserController : EditorImageBrowserController
    {
        private const string contentFolderRoot = "UserFiles/";
        private const string folderName = "Images/";
        private static readonly string[] foldersToCopy = new[] { "UserFiles/Images/Copy" };

        /// <summary>
        /// Gets the base paths from which content will be served.
        /// </summary>
        public override string ContentPath
        {
            get
            {
                return CreateUserFolder();
            }
        }

        public ImageBrowserController(IHostingEnvironment hostingEnvironment)
            : base(hostingEnvironment)
        {
        }

        private string CreateUserFolder()
        {
            var virtualPath = Path.Combine(contentFolderRoot, "UserFiles", folderName);
            //var path = HostingEnvironment.WebRootFileProvider.GetFileInfo(virtualPath).PhysicalPath;

            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //    foreach (var sourceFolder in foldersToCopy)
            //    {
            //        CopyFolder(HostingEnvironment.WebRootFileProvider.GetFileInfo(sourceFolder).PhysicalPath, path);
            //    }
            //}
            return virtualPath;
        }

        private void CopyFolder(string source, string destination)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            foreach (var file in Directory.EnumerateFiles(source))
            {
                var dest = Path.Combine(destination, Path.GetFileName(file));
                System.IO.File.Copy(file, dest);
            }

            foreach (var folder in Directory.EnumerateDirectories(source))
            {
                var dest = Path.Combine(destination, Path.GetFileName(folder));
                CopyFolder(folder, dest);
            }
        }
    }
}