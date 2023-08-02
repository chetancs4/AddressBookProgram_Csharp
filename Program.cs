namespace AddressBookProgram
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Address Book!");

            AddressBook addressBook = new AddressBook();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Display All Contacts");
                Console.WriteLine("4. Exit");

                int choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        AddContact(addressBook);
                        break;
                    case 2:
                        EditContact(addressBook);
                        break;
                    case 3:
                        addressBook.DisplayContacts();
                        break;
                    case 4:
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

        static void AddContact(AddressBook addressBook)
        {
            Console.WriteLine("\nAdding a new contact:");
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

            ContactPerson newContact = new ContactPerson
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

            addressBook.AddContact(newContact);
            Console.WriteLine("Contact added successfully!");
        }

        static void EditContact(AddressBook addressBook)
        {
            Console.WriteLine("\nEnter the contact's name you want to edit:");
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            ContactPerson existingContact = addressBook.FindContact(firstName, lastName);

            if (existingContact != null)
            {
                ContactPerson updatedContact = new ContactPerson
                {
                    FirstName = existingContact.FirstName,
                    LastName = existingContact.LastName,
                    Address = existingContact.Address,
                    City = existingContact.City,
                    State = existingContact.State,
                    Zip = existingContact.Zip,
                    PhoneNumber = existingContact.PhoneNumber,
                    Email = existingContact.Email
                };

                Console.WriteLine("\nEditing contact details:");
                Console.Write("Enter First Name: ");
                updatedContact.FirstName = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                updatedContact.LastName = Console.ReadLine();
                Console.Write("Enter Address: ");
                updatedContact.Address = Console.ReadLine();
                Console.Write("Enter City: ");
                updatedContact.City = Console.ReadLine();
                Console.Write("Enter State: ");
                updatedContact.State = Console.ReadLine();
                Console.Write("Enter Zip: ");
                updatedContact.Zip = Console.ReadLine();
                Console.Write("Enter Phone Number: ");
                updatedContact.PhoneNumber = Console.ReadLine();
                Console.Write("Enter Email: ");
                updatedContact.Email = Console.ReadLine();

                if (addressBook.EditContact(firstName, lastName, updatedContact))
                {
                    Console.WriteLine("Contact updated successfully!");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }

}



