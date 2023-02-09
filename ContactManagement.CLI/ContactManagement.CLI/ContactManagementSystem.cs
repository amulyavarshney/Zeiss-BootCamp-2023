namespace ContactManagementSystem.CLI
{
    class ContactManagementSystem
    {
        static List<Person> contacts = new List<Person>();
        public static void AddContact()
        {
            string name;
            while (true)
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();
                Person contact = contacts.Find(x => x.Name.ToLower() == name.ToLower());
                if (contact is null)
                    break;
                else
                {
                    Console.WriteLine("Name already exists in Contact.");
                    return;
                }
            }

            Person person = new Person();
            person.Name = name;
            person.EmailIds = new HashSet<string>();

            bool addMore = true;
            while (addMore)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Email");
                Console.WriteLine("2. Save Contact");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        person.AddEmail();
                        break;
                    case "2":
                        contacts.Add(person);
                        Console.WriteLine("Contact saved successfully!");
                        addMore = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        public static void ViewContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }
            Console.WriteLine("Contacts:");
            foreach (var contact in contacts)
            {
                contact.ViewContact();
            }
        }
        public static void EditContact()
        {
            Console.Write("Enter contact name: ");
            string name = Console.ReadLine();
            Person contactToEdit = contacts.Find(x => x.Name.ToLower() == name.ToLower());
            if (contactToEdit == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }
            contactToEdit.ViewContact();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Email");
                Console.WriteLine("2. Remove Email");
                Console.WriteLine("3. View Contact");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        contactToEdit.AddEmail();
                        break;
                    case "2":
                        contactToEdit.RemoveEmail();
                        break;
                    case "3":
                        contactToEdit.ViewContact();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        public static void DeleteContact()
        {
            Console.Write("Enter contact name: ");
            string name = Console.ReadLine();
            Person contactToDelete = contacts.Find(x => x.Name.ToLower() == name.ToLower());
            if (contactToDelete == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }
            contacts.Remove(contactToDelete);
            Console.WriteLine("Contact deleted.");
        }
    }
}
