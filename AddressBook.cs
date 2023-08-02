namespace AddressBookProgram
{
    public class AddressBook
    {
        private List<ContactPerson> contacts = new List<ContactPerson>();

        public void AddContact(ContactPerson contact)
        {
            contacts.Add(contact);
        }

        public void DisplayContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                Console.WriteLine("\nAll Contacts:");
                foreach (ContactPerson contact in contacts)
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
    }

}



