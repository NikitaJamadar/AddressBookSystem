using System;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book system");

            while (true)
            {
                Console.WriteLine("\n Enter your choice \n 1 for Adding Contacts \n 2 for viewing Address book" +
                    " \n 3 for editing the existing contact \n 4 for deleting the contact");
                Console.WriteLine("................................................");

                int choice = int.Parse(Console.ReadLine());

                Console.WriteLine("................................................");

                switch (choice)
                {
                    case 1:
                        AddressBook.EnterDetails();
                        break;

                    case 2:
                        AddressBook obj1 = new AddressBook();
                        obj1.ViewTheDetails();
                        break;

                    case 3:
                        AddressBook obj2 = new AddressBook();
                        obj2.EditDeatils();
                        break;


                    case 4:
                        AddressBook obj3 = new AddressBook();
                        obj3.DeleteName();
                        break;

                    default:
                        Console.WriteLine("Enter valid choice.");
                        break;

                }
            }
        }
    }
}
