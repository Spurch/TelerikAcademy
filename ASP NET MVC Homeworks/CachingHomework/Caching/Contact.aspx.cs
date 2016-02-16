using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Caching
{
    public partial class Contact : Page
    {
        private static void WalkDirectoryTree(System.IO.DirectoryInfo root, ref StringBuilder wr, HttpResponse response, HttpServerUtility server, HttpRequest request)
        {
            string fileDependencyPath = "";
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException ex)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
            }

            catch (System.IO.DirectoryNotFoundException ex)
            {
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    fileDependencyPath = server.MapPath(request.ServerVariables[fi.FullName]);
                    response.AddFileDependency(fileDependencyPath);
                    wr.AppendLine(fi.FullName);
                    wr.AppendLine("\n");
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(dirInfo, ref wr, response, server, request);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Set additional properties to enable caching.
            Response.Cache.SetExpires(DateTime.Now.AddMinutes(5));
            Response.Cache.SetCacheability(HttpCacheability.Public);
            Response.Cache.SetValidUntilExpires(true);

            var temp = new StringBuilder();
            var path = Environment.CurrentDirectory;
            DirectoryInfo root = new DirectoryInfo(path);
            WalkDirectoryTree(root, ref temp, Response, Server, Request);
            h3Content.InnerText = temp.ToString();
        }
    }
}