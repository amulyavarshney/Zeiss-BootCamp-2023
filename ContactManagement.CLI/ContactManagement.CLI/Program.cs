namespace ContactManagementSystem.CLI
{   
    class Program
    {
        public static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ContactManagementSystem.AddContact();
                        break;
                    case "2":
                        ContactManagementSystem.ViewContacts();
                        break;
                    case "3":
                        ContactManagementSystem.EditContact();
                        break;
                    case "4":
                        ContactManagementSystem.DeleteContact();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}