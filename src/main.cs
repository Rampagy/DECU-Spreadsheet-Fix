using System;

namespace SpreadsheetFixer
{
    public partial class main
    {
        static string file_path = "./";

        public static void Main(string[] args)
        {
            // first argument (if exists) denotes the file/folder to convert
            try {
                file_path = args[0];
            } catch { }

            Console.WriteLine(file_path);
        }
    }
}