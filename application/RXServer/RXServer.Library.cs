using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RXServer
{
    namespace Library
    {
        public class Mail
        {

        }
        public static class File
        {
            public static String GetTempFileName()
            {
                return Path.GetFileNameWithoutExtension(Path.GetTempFileName());
            }
        }

    }
}
