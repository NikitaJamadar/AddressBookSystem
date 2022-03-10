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

                Console.WriteLine("................................");
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
        public void EditDeatils()
        {
            if (Details.Count > 0)
            {
                Console.Write("Enter Name of the contact you want to edit: ");
                string editDetails = Console.ReadLine();



                foreach (var item in Details)
                {
                    if (editDetails.ToLower() == item.FirstName.ToLower())
                    {
                        Console.WriteLine("\nChoice what you want to edit\n 1.First name\n2.Last name\n3.Address" +
                            "\n4.City\n5.State\n6.Zip Code\n7.Phone Number\n8.Email");

                        int editChoice = int.Parse(Console.ReadLine());

                        switch (editChoice)
                        {
                            case 1:
                                Console.Write("Enter new First Name: ");
                                item.FirstName = Console.ReadLine();
                                break;

                            case 2:
                                Console.Write("Enter new Last Name: ");
                                item.LastName = Console.ReadLine();
                                break;

                            case 3:
                                Console.Write("Enter Your new Address: ");
                                item.Address = Console.ReadLine();
                                break;

                            case 4:
                                Console.Write("Enter Your new City Name: ");
                                item.City = Console.ReadLine();
                                break;

                            case 5:
                                Console.Write("Enter new State Name: ");
                                item.State = Console.ReadLine();
                                break;

                            case 6:
                                while (true)
                                {
                                    Console.Write("Enter new Zip Code: ");
                                    string code = Console.ReadLine();

                                    if (code.Length == 6)
                                    {
                                        item.ZipCode = code;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter a valid 6 digit Zip Code.");
                                    }
                                }
                                break;

                            case 7:
                                while (true)
                                {
                                    Console.Write("Enter Your new Phone Number: ");
                                    string Phonenumber = Console.ReadLine();

                                    if (Phonenumber.Length == 10)
                                    {
                                        item.PhoneNumber = Phonenumber;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter a valid 10 digit Phone Number.");
                                    }
                                }
                                break;

                            case 8:
                                while (true)
                                {
                                    Console.Write("Enter Your new Email Address: ");
                                    string Email = Console.ReadLine();

                                    if (Email.Contains("@"))
                                    {
                                        item.EmailId = Email;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter a valid Email Address.");
                                    }
                                }
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("{0} does not exists in Address Book.", editDetails);
                    }
                }

            }
            else
            {
                Console.WriteLine("Address Book is Empty");
            }

        }
        public void DeleteName()
        {
            if (Details.Count > 0)
            {
                Console.Write("Enter name of contact you want to delete: ");
                string deleteName = Console.ReadLine();


                foreach (var item in Details)
                {
                    if (deleteName.ToLower() == item.FirstName.ToLower())
                    {
                        Details.Remove(item);
                        Console.WriteLine(deleteName + "'s Contact is successfully deleted.");
                        break;
                    }

                    else
                    {
                        Console.WriteLine(deleteName + " does not exist in Address Book.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Address Book is Empty");
            }
        }
    }
}
