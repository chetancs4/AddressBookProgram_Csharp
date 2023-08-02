namespace AddressBookProgram
{
    public class Program
    {
        static AddressBookManager addressBookManager = new AddressBookManager();

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Address Book!");

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display All Contacts");
                Console.WriteLine("5. Add Multiple Contacts");
                Console.WriteLine("6. Add New Address Book");
                Console.WriteLine("7. Select Address Book");
                Console.WriteLine("8. Exit");

                int choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        EditContact();
                        break;
                    case 3:
                        DeleteContact();
                        break;
                    case 4:
                        DisplayContacts();
                        break;
                    case 5:
                        AddMultipleContacts();
                        break;
                    case 6:
                        CreateAddressBook();
                        break;
                    case 7:
                        SelectAddressBook();
                        break;
                    case 8:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static int GetUserChoice()
        {
            Console.Write("Enter your choice: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Write("Enter your choice: ");
            }
            return choice;
        }

        static void AddContact()
        {
            AddressBook addressBook = GetSelectedAddressBook();
            if (addressBook != null)
            {
                ContactPerson newContact = GetContactDetails();
                addressBook.AddContact(newContact);
                Console.WriteLine("Contact added successfully!");
            }
        }

        static void EditContact()
        {
            AddressBook addressBook = GetSelectedAddressBook();
            if (addressBook != null)
            {
                ContactPerson updatedContact = GetContactDetails();
                Console.WriteLine("\nEnter the contact's name you want to edit:");
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();

                if (addressBook.EditContact(firstName, lastName, updatedContact))
                {
                    Console.WriteLine("Contact updated successfully!");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
        }

        static void DeleteContact()
        {
            AddressBook addressBook = GetSelectedAddressBook();
            if (addressBook != null)
            {
                Console.WriteLine("\nEnter the contact's name you want to delete:");
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();

                if (addressBook.DeleteContact(firstName, lastName))
                {
                    Console.WriteLine("Contact deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
        }

        static void DisplayContacts()
        {
            AddressBook addressBook = GetSelectedAddressBook();
            if (addressBook != null)
            {
                addressBook.DisplayContacts();
            }
        }

        static void AddMultipleContacts()
        {
            AddressBook addressBook = GetSelectedAddressBook();
            if (addressBook != null)
            {
                Console.WriteLine("\nAdding multiple contacts:");
                while (true)
                {
                    ContactPerson newContact = GetContactDetails();
                    addressBook.AddContact(newContact);
                    Console.WriteLine("Contact added successfully!");

                    Console.Write("Do you want to add another contact? (yes/no): ");
                    string answer = Console.ReadLine().ToLower();
                    if (answer != "yes")
                    {
                        break;
                    }
                }
            }
        }
        static void CreateAddressBook()
        {
            Console.Write("Enter the name of the new Address Book: ");
            string addressBookName = Console.ReadLine();
            addressBookManager.AddAddressBook(addressBookName);
        }

        static void SelectAddressBook()
        {
            List<string> addressBookNames = addressBookManager.GetAddressBookNames();
            if (addressBookNames.Count > 0)
            {
                Console.WriteLine("\nAvailable Address Books:");
                foreach (string name in addressBookNames)
                {
                    Console.WriteLine(name);
                }

                Console.Write("Enter the name of the Address Book you want to select: ");
                string selectedAddressBook = Console.ReadLine();
                if (addressBookManager.GetAddressBook(selectedAddressBook) != null)
                {
                    Console.WriteLine($"Selected Address Book: {selectedAddressBook}");
                }
                else
                {
                    Console.WriteLine("Invalid Address Book name.");
                }
            }
            else
            {
                Console.WriteLine("No Address Books found. Please create a new Address Book first.");
            }
        }

        static AddressBook GetSelectedAddressBook()
        {
            Console.Write("Enter the name of the Address Book you want to use: ");
            string selectedAddressBook = Console.ReadLine();
            return addressBookManager.GetAddressBook(selectedAddressBook);
        }

        static ContactPerson GetContactDetails()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter City: ");
            string city = Console.ReadLine();
            Console.Write("Enter State: ");
            string state = Console.ReadLine();
            Console.Write("Enter Zip: ");
            string zip = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            return new ContactPerson
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                PhoneNumber = phoneNumber,
                Email = email
            };
        }
    }
}




