using System;
using System.Collections.Generic;
using System.IO;
using DanteMarshal.Utilities.Telegram.ContactsJsonToVCardConverter.Conversion;
using DanteMarshal.Utilities.Telegram.ContactsJsonToVCardConverter.Data;

namespace DanteMarshal.Utilities.Telegram.ContactsJsonToVCardConverter
{
    static class Application
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length < 1)
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
            var cList = new List<Contact>();
            foreach (var fn in fileNames)
            {
                if (File.Exists(fn))
                    try
                    {
                        cList.AddRange(TgContactsReader.ReadAllContactsFromFile(fn));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unhandled Exception : " + e);
                    }
            }
            VCardContactsWriter.WriteAllContacts(cList);
        }
    }
}
