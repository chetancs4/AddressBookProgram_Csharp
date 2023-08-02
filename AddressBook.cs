namespace AddressBookProgram
{
    public class AddressBook
    {
        public List<ContactPerson> contacts = new List<ContactPerson>();

        public void AddContact(ContactPerson contact)
        {
            contacts.Add(contact);
        }

        public bool EditContact(string firstName, string lastName, ContactPerson updatedContact)
        {
            ContactPerson contact = FindContact(firstName, lastName);
            if (contact != null)
            {
                contact.FirstName = updatedContact.FirstName;
                contact.LastName = updatedContact.LastName;
                contact.Address = updatedContact.Address;
                contact.City = updatedContact.City;
                contact.State = updatedContact.State;
                contact.Zip = updatedContact.Zip;
                contact.PhoneNumber = updatedContact.PhoneNumber;
                contact.Email = updatedContact.Email;
                return true;
            }
            return false;
        }

        public bool DeleteContact(string firstName, string lastName)
        {
            ContactPerson contactToDelete = FindContact(firstName, lastName);
            if (contactToDelete != null)
            {
                contacts.Remove(contactToDelete);
                return true;
            }
            return false;
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

        public ContactPerson FindContact(string firstName, string lastName)
        {
            return contacts.Find(contact => contact.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) && contact.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }
    }
}



