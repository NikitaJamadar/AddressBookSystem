using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class AddressBook
    {
        public static List<Person> Details = new List<Person>();


        public static void EnterDetails()
        {
            Console.WriteLine("How many contacts do you want to add?");
            int Count = Convert.ToInt32(Console.ReadLine());
            while (Count > 0)
            {

                Person details = new Person();

                Console.Write("Enter First name : ");
                details.FirstName = Console.ReadLine();

                Console.Write("Enter Last Name : ");
                details.LastName = Console.ReadLine();

                Console.Write("Enter Address : ");
                details.Address = Console.ReadLine();

                Console.Write("Enter City : ");
                details.City = Console.ReadLine();

                Console.Write("Enter State : ");
                details.State = Console.ReadLine();

                while (true)
                {
                    Console.Write("Enter Zip Code  : ");
                    string code = Console.ReadLine();

                    if (code.Length == 6)
                    {
                        details.ZipCode = code;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid 6 digit Zip Code.");
                    }
                }


                while (true)
                {
                    Console.Write("Enter Your Phone Number: ");
                    string Phonenumber = Console.ReadLine();

                    if (Phonenumber.Length == 10)
                    {
                        details.PhoneNumber = Phonenumber;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid 10 digit Phone Number.");
                    }
                }

                while (true)
                {
                    Console.Write("Enter Your Email Address: ");
                    string Email = Console.ReadLine();

                    if (Email.Contains("@"))
                    {
                        details.EmailId = Email;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid Email Address.");
                    }
                }

                Details.Add(details);

                Console.WriteLine("..................");
                Count--;
            }
        }

        public void ViewTheDetails()
        {
            foreach (var item in Details)
            {
                PrintTheDetails(item);
                Console.WriteLine("......................................");
            }

        }

        public void PrintTheDetails(Person item)
        {
            Console.WriteLine("First Name :   " + item.FirstName);
            Console.WriteLine("Last Name :    " + item.LastName);
            Console.WriteLine("Address :      " + item.Address);
            Console.WriteLine("City    :      " + item.City);
            Console.WriteLine("State   :      " + item.State);
            Console.WriteLine("Zip     :      " + item.ZipCode);
            Console.WriteLine("Phone Number  : " + item.PhoneNumber);
            Console.WriteLine("email  :       " + item.EmailId);


        }
    }
}
