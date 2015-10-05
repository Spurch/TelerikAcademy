/*
A simple method that goes through a directory structure and lists all its subdirs 
and files to an XML structure. The results can be found in the project folder -
directorytree.xml file.
*/
namespace XMLProcessingHomeWork
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;

    class DirectoryCrawer
    {
        /*
        NOTE: We use and additional method StartCrawer in order to pass the XmlWriter 
        object to the real method. Otherwise trying to use XmlWriter object directly 
        in the Crawly method will result in error due to the recursion and the lock 
        on the output file by the XmlWriter. This is a simple yet useful workaround.
        */
        public static void StartCrawer(string targetDir)
        {
            using (XmlWriter writer = XmlWriter.Create(Config.DIRECTORYCRAWERXML))
            {
                writer.WriteStartDocument();
                Crawly(writer, targetDir);
                writer.WriteEndDocument();
            }
        }

        public static void StartXCrawer(string targetDir)
        {
            var xmlResult = XPathCrawer(targetDir);
            xmlResult.Save(Config.XRESULT);
        }

        /*
        Method that uses recursion to craw through all the files and subdirs
        in a given directory.
        */
        private static void Crawly(XmlWriter writer, string targetDir)
        {
            if (!Directory.Exists(targetDir))
            {
                throw new ArgumentException("Incorrect directory path!");
            }
                var root = Directory.CreateDirectory(targetDir);
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", root.Name);
                FileInfo[] files = null;
                DirectoryInfo[] subDirs = null;
                files = root.GetFiles("*.*");
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        writer.WriteStartElement("file");
                        writer.WriteAttributeString("name", file.Name);
                        writer.WriteAttributeString("extension", file.Extension);
                        writer.WriteFullEndElement();
                    }
                }
                subDirs = root.GetDirectories();
                foreach (var dir in subDirs)
                {
                    Crawly(writer, dir.FullName);
                }
                writer.WriteEndElement();
        }

        private static XElement XPathCrawer(string targetDir)
        {
            if (!Directory.Exists(targetDir))
            {
                throw new ArgumentException("Incorrect directory path!");
            }
            var root = Directory.CreateDirectory(targetDir);
            var node = new XElement("dir", new XAttribute("path", targetDir));

            foreach (var directory in Directory.GetDirectories(targetDir))
            {
                node.Add(XPathCrawer(directory));
            }

            foreach (var file in Directory.GetFiles(targetDir))
            {
                node.Add(new XElement("file", new XAttribute("name", Path.GetFileName(file))));
            }
            return node;
        }
    }
}
