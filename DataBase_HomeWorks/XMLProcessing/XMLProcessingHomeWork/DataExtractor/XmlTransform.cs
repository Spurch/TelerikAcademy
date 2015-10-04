namespace XMLProcessingHomeWork
{
    using System;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Xsl;

    class XmlTransform
    {
        public static void XmlToHtml(string template, string xml, string html)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(template);
            xslt.Transform(xml, html);
        }

        public static void ValidateXml(string schema, string xmlFile)
        {
            XDocument xDoc = XDocument.Load(xmlFile);
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", XmlReader.Create(schema));
            Console.WriteLine("Validating XML document");
            bool errors = false;
            xDoc.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });
            Console.WriteLine("XML Document {0}", errors ? "did not validate!" : "validated!");
        }
    }
}
