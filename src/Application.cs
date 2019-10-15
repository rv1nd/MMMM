using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using DanteMarshal.Utilities.Telegram.ContactsJsonToVCardConverter.Data;
using DanteMarshal.Utilities.Telegram.ContactsJsonToVCardConverter.Conversion;

namespace DanteMarshal.Utilities.Telegram.ContactsJsonToVCardConverter
{
    static class Application
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                    ShowHelp();
                else
                    Start(args);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled Exception : " + e);
            }
            Console.ReadKey();
        }
        private static void ShowHelp()
        {
            // TODO : Add Help text
            Console.WriteLine("TODO : ADD HELP TEXT");
        }
        private static void Start(string[] fileNames)
        {
            if (File.Exists(fileNames[0]))
            {
                Console.Write("File '" + Path.GetFileName(fileNames[0]) + "' already exists. Overwrite ? y / N");
                var ans = Console.ReadKey(intercept: true);
                Console.WriteLine();
                if (ans.Key == ConsoleKey.Y)
                    File.Delete(fileNames[0]);
                else
                {
                    Console.WriteLine("Ok :| Bye then ...");
                }
            }
            var cList = new List<Contact>();
            var fCount = fileNames.Length;
            for (var i = 1; i < fCount; i++)
            {
                var fn = fileNames[i];
                if (File.Exists(fn))
                    try
                    {
                        cList.AddRange(TgContactsReader.ReadAllContactsFromFile(fn));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unhandled Exception : " + e);
                    }
                else
                    Console.WriteLine("Skipping non-existing file '" + fn + "'");
            }
            var serialized = VCardContactsWriter.SerializeAllContacts(cList);
            // use constructor instead of factory property, In order to skip BOM, My smartphone didn't support BOM I guess !
            File.WriteAllLines(fileNames[0], serialized, new UTF8Encoding());
            Console.WriteLine("It's done. Everything has been written to '" + fileNames[0] + "'");
        }
    }
}
