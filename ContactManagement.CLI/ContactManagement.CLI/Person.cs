using System.Text.RegularExpressions;

namespace ContactManagementSystem.CLI
{
    class Person
    {
        public string Name { get; set; }
        public HashSet<string> EmailIds { get; set; }
        public Person()
        {
            Name = string.Empty;
            EmailIds = new HashSet<string>();
        }
        public void ViewContact()
        {
            Console.WriteLine(Name);
            foreach (var email in EmailIds)
                Console.WriteLine("\t" + email);
        }
        public void AddEmail()
        {
            bool isEmail = false;
            string email = string.Empty;
            while (!isEmail)
            {
                Console.Write("Enter new email: ");
                email = Console.ReadLine();
                isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
                if (!isEmail)
                {
                    Console.WriteLine("Error: Invalid Email Format.");
                }
            }
            if (EmailIds.Contains(email))
            {
                Console.WriteLine("Error: Email already exists in contact.");
            }
            else
            {
                EmailIds.Add(email);
                Console.WriteLine("Email added successfully.");
            }
        }
        public void RemoveEmail()
        {
            Console.Write("Enter email to remove: ");
            string email = Console.ReadLine();
            if (EmailIds.Remove(email))
            {
                Console.WriteLine("Email removed successfully.");
            }
            else
            {
                Console.WriteLine("Error: Email not found in contact.");
            }
        }
    }
}
