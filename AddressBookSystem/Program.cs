using System;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book system");

            AddressBook.EnterDetails();
            AddressBook obj = new AddressBook();
            obj.ViewTheDetails();
            Console.ReadLine();
        }
    }
}
