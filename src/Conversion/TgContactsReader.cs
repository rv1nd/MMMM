using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using DanteMarshal.Utilities.Telegram.ContactsJsonToVCardConverter.Data;

namespace DanteMarshal.Utilities.Telegram.ContactsJsonToVCardConverter.Conversion
{
    internal static class TgContactsReader
    {
        internal static LinkedList<Contact> ReadAllContactsFromFile(string fileName)
        {
            var doc = JsonDocument.Parse(File.OpenRead(fileName));
            foreach (var o in doc.RootElement.EnumerateObject())
            {
                if (o.Name == "contacts")
                {
                    var list = o.Value.GetProperty("list");
                    if (list.ValueKind == JsonValueKind.Array)
                        return ReadAllContacts(list);
                }
            }
            return new LinkedList<Contact>();
        }
        private static LinkedList<Contact> ReadAllContacts(JsonElement arr)
        {
            var ll = new LinkedList<Contact>();
            foreach (var co in arr.EnumerateArray())
            {
                ll.AddLast(new Contact(co));
            }
            return ll;
        }
    }
}