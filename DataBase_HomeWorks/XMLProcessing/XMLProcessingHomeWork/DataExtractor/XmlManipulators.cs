namespace XMLProcessingHomeWork
{
    using System;
    using System.Collections;
    using System.Xml.Linq;
    using System.Xml;
    using System.Linq;

    class XmlManipulators
    {
        private static XmlDocument xmlDoc;
        private static string xmlDocPath = Config.XMLDOCUMENTPATH;
        private static XmlNode rootNode;
        private static Hashtable artistsHash;
        private static XDocument xDoc;

        //Method that extracts XML data using DOM Parser.
        public static void DomExtractXmlDocument()
        {
            Console.WriteLine("Using DOM Parser");
            artistsHash = new Hashtable();
            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlDocPath);
            rootNode = xmlDoc.DocumentElement;
            
            foreach(XmlNode node in rootNode.ChildNodes)
            {
                string currentArtist = node["artist"].InnerText;
                if (artistsHash.ContainsKey(currentArtist))
                {
                    int temp = Int32.Parse(artistsHash[currentArtist].ToString());
                    temp++;
                    artistsHash[currentArtist] = temp;
                }
                else
                {
                    artistsHash.Add(currentArtist, 1);
                }
            }
            foreach(string key in artistsHash.Keys)
            {
                Console.WriteLine("Artist: {0} has {1} albums!", key, artistsHash[key].ToString());
            }
        }

        //Method that extracts XML data using XPath.
        public static void XPathExtractXmlDocument()
        {
            Console.WriteLine("Using xPath:");
            artistsHash = new Hashtable();
            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlDocPath);

            string xPathQuery = "catalogue/album/artist";
            XmlNodeList artistList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode node in artistList)
            {
                string currentArtist = node.InnerText;
                if (artistsHash.ContainsKey(currentArtist))
                {
                    int temp = Int32.Parse(artistsHash[currentArtist].ToString());
                    temp++;
                    artistsHash[currentArtist] = temp;
                }
                else
                {
                    artistsHash.Add(currentArtist, 1);
                }
            }
            foreach (string key in artistsHash.Keys)
            {
                Console.WriteLine("Artist: {0} has {1} albums!", key, artistsHash[key].ToString());
            }
        }

        //Method that outputs the price of all albums older than 5 years. Using XPath.
        public static void OldAlbumPrice()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(Config.XMLDOCUMENTPATH);
            string xPathQuery = "catalogue/album/year";
            XmlNodeList albumsList = xmlDoc.SelectNodes(xPathQuery);

            foreach(XmlNode node in albumsList)
            {
                int albumYear = Int32.Parse(node.InnerText);
                int currentYear = DateTime.Now.Year;
                if((currentYear - albumYear) > 5)
                {
                    XmlNodeList priceList = node.ParentNode.SelectNodes("price");
                    Console.WriteLine("Album year: {0} | Price: {1}", albumYear, priceList[0].InnerText);
                }
                
            }
        }

        //Method that uses XDocument and LINQ to output the prices for albums older than 5 years.
        public static void OldAlbumPriceLinq()
        {
            xDoc = XDocument.Load(Config.XMLDOCUMENTPATH);
            var result = from n in xDoc.Descendants("album")
                         where DateTime.Now.Year - Int32.Parse(n.Element("year").Value) > 5
                         select n;
            foreach (var node in result)
            {
                Console.WriteLine("Album name: {0} | year: {1} | price:{2} ",
                    node.Element("name").Value, node.Element("year").Value, node.Element("price").Value);
            }
        }

        //Method that deletes albums with prices larger than 20.
        public static void DomEraser()
        {
            Console.WriteLine("Deleting albums using DOM Parser");
            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlDocPath);
            rootNode = xmlDoc.DocumentElement;

            for(int i = 0; i < rootNode.ChildNodes.Count; i++)
            {
                XmlNode albumNode = rootNode.ChildNodes[i];
                for(int j = 0; j < albumNode.ChildNodes.Count; j++)     
                {
                    XmlNode albumChild = albumNode.ChildNodes[j];
                    if (albumChild.Name == "price")
                    {
                        int temp = 0;
                        Int32.TryParse(albumChild.InnerText, out temp);
                        if (temp > 20)
                        {
                            Console.WriteLine("Album name: {0}", albumNode.FirstChild.InnerText);
                            Console.WriteLine("Price: {0}", albumChild.InnerText);
                            rootNode.RemoveChild(albumChild.ParentNode);
                        }
                    }
                }
            }
            xmlDoc.Save(xmlDocPath);
        }

        //Method that extracts XML data using XmlReader.
        public static void XmlReaderExtractor()
        {
            using (XmlReader xmlReader = XmlReader.Create(Config.XMLDOCUMENTPATH))
            {
                while (xmlReader.Read())
                {
                    if((xmlReader.NodeType == XmlNodeType.Element) && 
                        (xmlReader.Name == "title"))
                    {
                        Console.WriteLine(xmlReader.ReadElementString());
                    }
                }
            }
        }

        //Method that extracts XML data using XDocument.
        public static void XDocumentExtractor()
        {
            xDoc = XDocument.Load(Config.XMLDOCUMENTPATH);
            var result = from n in xDoc.Descendants("song")
                         select new
                         {
                             Title = n.Element("title").Value
                         };
            foreach (var node in result)
            {
                Console.WriteLine(node);
            }           
        }

        //Method that extracts all Albums and stores them in a new XML file.
        public static void AlbumExtractor()
        {
            using (XmlReader xmlReader = XmlReader.Create(Config.XMLDOCUMENTPATH))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(Config.ALBUMXMLDOCUMENTPATH))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("albums");
                    while (xmlReader.Read())
                    {

                        if ((xmlReader.NodeType == XmlNodeType.Element) &&
                        (xmlReader.Name == "album"))
                        {
                            xmlWriter.WriteStartElement("album");
                        }
                        if ((xmlReader.NodeType == XmlNodeType.Element) &&
                            (xmlReader.Name == "name"))
                        {
                            xmlWriter.WriteElementString("name", xmlReader.ReadElementString());
                        }
                        if ((xmlReader.NodeType == XmlNodeType.Element) &&
                        (xmlReader.Name == "artist"))
                        {
                            xmlWriter.WriteElementString("author", xmlReader.ReadElementString());
                        }
                    }
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
            }
        }
    }
}
