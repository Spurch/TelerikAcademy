namespace XMLProcessingHomeWork
{
    class AppStart
    {
        static void Main()
        {
            //XmlExtractors.DomExtractXmlDocument();
            //XmlExtractors.XPathExtractXmlDocument();
            //XmlManipulators.DomEraser();
            //XmlManipulators.XmlReaderExtractor();
            //XmlManipulators.XDocumentExtractor();
            //XmlManipulators.AlbumExtractor();
            //TextFileReader.TextParser();
            //DirectoryCrawer.StartCrawer(@"C:\Users\Ivan\Documents\Visual Studio 2015\Projects\XMLProcessing\XMLProcessingHomeWork");
            //XmlTransform.XmlToHtml(Config.XSLTTEMPLATE, Config.XMLDOCUMENTPATH, Config.HTMLRESULT);
            //XmlTransform.ValidateXml(Config.XMLSCHEMA, Config.XMLDOCUMENTPATH);
            //XmlManipulators.OldAlbumPrice();
            //XmlManipulators.OldAlbumPriceLinq();
            DirectoryCrawer.XPathCrawer(@"C:\Users\Ivan\Documents\Visual Studio 2015\Projects\XMLProcessing\XMLProcessingHomeWork");
        }
    }
}
