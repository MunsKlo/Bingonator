using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoWortGeber
{
    class FileReaderAndWriter
    {
        public static string ReadTxt(Stream fileStreamer)
        {
            var fileContent = string.Empty;
            using(StreamReader reader = new StreamReader(fileStreamer))
            {
                fileContent = reader.ReadToEnd();
            }
            return fileContent;
        }
    }
}
