using System;
using System.Collections.Generic;


namespace SpreadsheetFixer
{
    public partial class main
    {
        static List<string> file_path = new List<string>();

        public static void Main( string[] args )
        {
            foreach ( string arg in args )
            {
                if ( System.IO.Directory.Exists(arg) )
                {
                    foreach ( string file in System.IO.Directory.GetFiles(arg) )
                    {
                        string extension = file.Split('.')[file.Split('.').Length - 1];

                        // check to make sure it has CSV extension
                        if (extension.ToUpper() == "CSV")
                        {
                            file_path.Add(file);
                        }
                        else
                        {
                            Console.WriteLine("\"" + file + "\" has the wrong extension type (must be CSV).");
                        }
                    }
                }
                else if ( System.IO.File.Exists(arg) )
                {
                    string extension = arg.Split('.')[arg.Split('.').Length - 1];

                    // check to make sure it has CSV extension
                    if (extension.ToUpper() == "CSV")
                    {
                        file_path.Add(arg);
                    }
                    else
                    {
                        Console.WriteLine("\"" + arg + "\" has the wrong extension type (must be CSV).");
                    }
                }
                else
                {
                    Console.WriteLine("\"" + arg + "\" is not a valid file or directory.");
                }
            }

            // In the event no args were provided use current directory
            if ( file_path.Count < 1 )
            {
                foreach ( string file in System.IO.Directory.GetFiles(@".\") )
                {
                    string extension = file.Split('.')[file.Split('.').Length - 1];

                    // check to make sure it has CSV extension
                    if (extension.ToUpper() == "CSV")
                    {
                        file_path.Add(file);
                    }
                    else
                    {
                        Console.WriteLine("\"" + file + "\" has the wrong extension type (must be CSV).");
                    }
                }
            }

            // This is where the money is made :)
            foreach ( string path in file_path )
            {
                // create name of transcribed file
                string extension = path.Split('.')[path.Split('.').Length - 1];
                string new_path = path.Insert( path.Length - extension.Length - 1, "_Fixed" );
                int creditColumn = -1;
                bool firstPass = true;

                using ( var reader = new System.IO.StreamReader( path ) )
                {
                    using ( var writer = new System.IO.StreamWriter( new_path ) )
                    {
                        if (firstPass)
                        {
                            string header_line = reader.ReadLine();
                            firstPass = false;

                            // look through the columns and find the "Credit or Debit" column
                            int count = 0;
                            foreach ( string column in header_line.Split(',') )
                            {
                                if (column.ToUpper() == "\"CREDIT OR DEBIT\"")
                                {
                                    creditColumn = count;
                                    break;
                                }
                                count++;
                            }

                            Console.WriteLine( creditColumn );
                            writer.WriteLine( header_line );
                        }

                        while ( !reader.EndOfStream )
                        {
                            writer.WriteLine( reader.ReadLine() );
                        }
                    }
                }
            }
        }
    }
}