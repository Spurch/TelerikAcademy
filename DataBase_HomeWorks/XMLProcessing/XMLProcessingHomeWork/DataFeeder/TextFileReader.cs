/*
The following code reads from PersonDetails.txt and writes into TextParseResult.xml
That are located in the project. Just run the TextParser() method from AppStart and 
then check the TextParseResult file.
*/
namespace XMLProcessingHomeWork
{ 
    using System.IO;
    class TextFileReader
    {
        private static StreamReader sRead;
        private static StreamWriter sWriter;
        private static string currentLine;

        public static void TextParser()
        {
            sWriter = new StreamWriter(Config.TEXTPARSERESULTFILE);
            sRead = new StreamReader(Config.PERSONDETAILSPATH);
            /*
            Yes, I know this is a Caveman implementation but thats all I was able to think of
            having 10 more exercises waiting for me :D
            */
            int count = 0;
            sWriter.WriteLine("<?xml version=\"1.0\" encoding=\"utf - 8\" ?>");
            sWriter.WriteLine("<details>");
            /*
            Basically we read the file line by line using a counter to count the number of lines
            on each third line we reset the counter. This way we can use a simple switch to write 
            into the resulting xml file.
            */
            while((currentLine = sRead.ReadLine()) != null)
            {
                switch (count)
                {
                    case 0:
                        sWriter.WriteLine("<person>");
                        sWriter.WriteLine("<name>{0}</name>", currentLine); count++;
                        break;
                    case 1:
                        sWriter.WriteLine("<address>{0}</address>", currentLine); count++;
                        break;
                    case 2:
                        sWriter.WriteLine("<phone>{0}</phone>", currentLine); count = 0;
                        sWriter.WriteLine("</person>");
                        break;
                }
            }
            sWriter.WriteLine("</details>");
            sRead.Close();
            sWriter.Close();
        }
    }
}
