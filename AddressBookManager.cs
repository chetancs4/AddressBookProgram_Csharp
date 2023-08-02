namespace AddressBookProgram
{
    class AddressBookManager
    {
        private Dictionary<string, AddressBook> addressBooks = new Dictionary<string, AddressBook>();

        public void AddAddressBook(string name)
        {
            if (!addressBooks.ContainsKey(name))
            {
                addressBooks.Add(name, new AddressBook(name));
                Console.WriteLine($"Address Book '{name}' created successfully!");
            }
            else
            {
                Console.WriteLine("An Address Book with that name already exists.");
            }
        }

        public AddressBook GetAddressBook(string name)
        {
            return addressBooks.ContainsKey(name) ? addressBooks[name] : null;
        }

        public List<string> GetAddressBookNames()
        {
            return new List<string>(addressBooks.Keys);
        }
    }
}



