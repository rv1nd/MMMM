using System;
using System.Linq;
using MixERP.Net.VCards;
using System.Collections.Generic;
using MixERP.Net.VCards.Serializer;
using DanteMarshal.Utilities.Telegram.ContactsJsonToVCardConverter.Data;

namespace DanteMarshal.Utilities.Telegram.ContactsJsonToVCardConverter.Conversion
{
    internal class VCardContactsWriter
    {
        internal static IEnumerable<string> SerializeAllContacts(IList<Contact> contacts) => contacts.Select(c => c.ToVCard().Serialize());
    }
}