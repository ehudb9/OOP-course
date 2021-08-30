using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Owner
    {
        public Owner(string i_Name, string i_PhoneNumber)
        {
            Name = i_Name;
            PhoneNumber = i_PhoneNumber;
        }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public void GetData(Dictionary<string, string> i_DataDictionary)
        {
            i_DataDictionary.Add("ownerName", Name);
            i_DataDictionary.Add("ownerPhoneNumber", PhoneNumber);
        }
    }
}
