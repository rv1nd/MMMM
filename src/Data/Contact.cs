using System.Text.Json;

namespace DanteMarshal.Utilities.Telegram.ContactsJsonToVCardConverter.Data
{
    public class Contact
    {
        private string firstName, lastName, phoneNumber;
        public string FirstName => firstName;
        public string LastName => lastName;
        public string PhoneNumber => phoneNumber;
        private const string PROPNAME_FIRST_NAME = "first_name";
        private const string PROPNAME_LAST_NAME = "last_name";
        private const string PROPNAME_PHONE_NUMBER = "phone_number";
        internal Contact(JsonElement value)
        {
            foreach (var prop in value.EnumerateObject())
                InitializeProperty(prop);
        }
        private void InitializeProperty(JsonProperty prop)
        {
            if (prop.Value.ValueKind != JsonValueKind.String)
                return;
            switch (prop.Name)
            {
                case PROPNAME_FIRST_NAME:
                    this.firstName = prop.Value.GetString();
                    break;
                case PROPNAME_LAST_NAME:
                    this.lastName = prop.Value.GetString();
                    break;
                case PROPNAME_PHONE_NUMBER:
                    this.phoneNumber = prop.Value.GetString();
                    break;
            }
        }

    }
}