using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    class AddressBook
    {
        public static Dictionary<string, List<Person>> AddressBookDictionary = new Dictionary<string, List<Person>>();
        public static List<Person> addressBook;



        public static void AddressBookNewNameValidator()
        {
            Console.WriteLine("Enter the new addressbook name\n");
            string addressBookName = Console.ReadLine();
            if (AddressBookDictionary.ContainsKey(addressBookName))
            {
                Console.WriteLine("Please enter a new addressbook name. The name entered already exist");
                AddressBookNewNameValidator();
            }
            else
            {
                AddressBookDictionary[addressBookName] = new List<Person>();
                EnterDetails(addressBookName);
            }
        }
        public static void AddressBookExistingNameValidator()
        {
            Console.WriteLine("Enter the Existing addressbook name\n");
            string addressBookName = Console.ReadLine();
            if (!AddressBookDictionary.ContainsKey(addressBookName))
            {
                Console.WriteLine("Please enter a new addressbook name. The name entered already exist");
                AddressBookExistingNameValidator();
            }
            else
            {
                EnterDetails(addressBookName);
            }
        }
        public static void EnterDetails(string addressBookName)
        {
            Console.WriteLine("How many person's contact details do you want to add?");
            int personNum = Convert.ToInt32(Console.ReadLine());
            while (personNum > 0)
            {
                Person details = new Person();
                FirstName:
                Console.WriteLine("Enter your First name");
                string FirstName = Console.ReadLine();
                if (NameDuplicationCheck(addressBookName, FirstName))
                {
                    details.FirstName = FirstName;
                }
                else
                {
                    Console.WriteLine("The name {0} already  exist in the current address book. please enter a new name", FirstName);
                    goto FirstName;
                }
                Console.WriteLine("Enter your Last name");
                details.LastName = Console.ReadLine();
                Console.WriteLine("Enter your address");
                details.Address = Console.ReadLine();
                Console.WriteLine("Enter your city");
                details.City = Console.ReadLine();
                Console.WriteLine("Enter your State");
                details.State = Console.ReadLine();
                Console.WriteLine("Enter your Zip code");
                details.ZipCode = Console.ReadLine();
                Console.WriteLine("Enter your Phone number");
                details.PhoneNumber = Console.ReadLine();
                Console.WriteLine("Enter your Email ID");
                details.EmailId = Console.ReadLine();

                AddressBookDictionary[addressBookName].Add(details);
                Console.WriteLine("{0}'s contact succesfully added", details.FirstName);

                personNum--;
            }
        }

        public static bool NameDuplicationCheck(string addressBookName, string FirstName)
        {
            int flag = 0;
            if (AddressBookDictionary[addressBookName].Count > 0)
            {
                foreach (Person contact in AddressBookDictionary[addressBookName])
                {
                    if (!(contact.FirstName == FirstName))
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
            }
            else
            {
                return true;
            }
            if (flag == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void ViewTheDetails()
        {
            Console.WriteLine("Enter the name of the addressbook that you wants to use for displaying contacts");
            string addressBookName = Console.ReadLine();
            if (AddressBookDictionary[addressBookName].Count > 0)
            {
                Console.WriteLine("Enter the name of the person to get all the contact details");
                string nameKey = Console.ReadLine();
                int flag = 0;
                foreach (Person contact in AddressBookDictionary[addressBookName])
                {
                    if (nameKey.ToLower() == contact.FirstName.ToLower())
                    {
                        flag = 1;
                        Console.WriteLine("First name-->{0}", contact.FirstName);
                        Console.WriteLine("Last name-->{0}", contact.LastName);
                        Console.WriteLine("Address-->{0}", contact.Address);
                        Console.WriteLine("City-->{0}", contact.City);
                        Console.WriteLine("State-->{0}", contact.State);
                        Console.WriteLine("Zip code-->{0}", contact.ZipCode);
                        Console.WriteLine("Phone number-->{0}", contact.PhoneNumber);
                        Console.WriteLine("E-Mail ID-->{0}", contact.EmailId);
                        break;
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("contact of the person {0} does not exist", nameKey);
                }
            }
            else
            {
                Console.WriteLine("Your address book is empty");
            }
        }

        public static void EditDetails()
        {
            Console.WriteLine("Enter the name of the addressbook that you wants to use for editing contacts");
            string addressBookName = Console.ReadLine();
            Console.WriteLine("Enter the first name of the person whoom you want to edit the details");
            string editKey = Console.ReadLine();
            int flag = 0;
            if (AddressBookDictionary[addressBookName].Count > 0)
            {
                foreach (Person contact in AddressBookDictionary[addressBookName])
                {
                    if (editKey.ToLower() == contact.FirstName.ToLower())
                    {
                        while (true)
                        {
                            Console.WriteLine("Enter the key number for editing the details\n 1. First name\n 2. Last name\n 3. Address\n 4. City\n 5. State\n 6. Zipcode\n 7. Phone number\n 8. Email ID\n 9. Exit editor");
                            int key = Convert.ToInt32(Console.ReadLine());
                            switch (key)
                            {
                                case 1:
                                    Console.WriteLine("Enter the new First name");
                                    contact.FirstName = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the new Last name");
                                    contact.LastName = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("Enter the new address");
                                    contact.Address = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.WriteLine("Enter the new city");
                                    contact.City = Console.ReadLine();
                                    break;
                                case 5:
                                    Console.WriteLine("Enter the new state");
                                    contact.State = Console.ReadLine();
                                    break;
                                case 6:
                                    Console.WriteLine("Enter the new zip code");
                                    contact.ZipCode = Console.ReadLine();
                                    break;
                                case 7:
                                    Console.WriteLine("Enter the new phone");
                                    contact.PhoneNumber = Console.ReadLine();
                                    break;
                                case 8:
                                    Console.WriteLine("Enter the new E-Mail ID");
                                    contact.EmailId = Console.ReadLine();
                                    break;
                                case 9:
                                    flag = 1;
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid input");
                                    EditDetails();
                                    break;
                            }
                            if (flag == 1)
                            {
                                break;
                            }
                        }
                        Console.WriteLine("{0}'s contact has been sucessfully updated", editKey);
                        break;
                    }
                }
                if (flag == 0)
                {

                    Console.WriteLine("contact of the person {0} does not exist", editKey);
                }
            }
            else
            {
                Console.WriteLine("Your address book is empty");
            }
        }
        public static void DeleteName()
        {
            Console.WriteLine("Enter the name of the addressbook that you wants to use for Deleting contacts");
            string addressBookName = Console.ReadLine();
            Console.WriteLine("Enter the first name of the person whose contact you want to delete from the addressbook");
            string deleteKey = Console.ReadLine();
            int flag = 0;
            if (AddressBookDictionary[addressBookName].Count > 0)
            {
                foreach (Person contact in AddressBookDictionary[addressBookName])
                {
                    if (deleteKey.ToLower() == contact.FirstName.ToLower())
                    {
                        flag = 1;
                        addressBook.Remove(contact);
                        break;
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                Console.WriteLine("Your address book is empty");
            }
            if (flag == 0)
            {

                Console.WriteLine("contact of the person {0} does not exist", deleteKey);
            }
        }
        public static void PersonSearch()
        {
            Dictionary<string, List<Person>> cityPersons = new Dictionary<string, List<Person>>();
            Dictionary<string, List<Person>> statePerson = new Dictionary<string, List<Person>>();

            Console.WriteLine("Enter the city that you want to search");
            string cityKey = Console.ReadLine();
            cityPersons[cityKey] = new List<Person>();
            Console.WriteLine("Enter the state that you want to search");
            string stateKey = Console.ReadLine();
            statePerson[stateKey] = new List<Person>();
            foreach (string addressBookName in AddressBookDictionary.Keys)
            {
                foreach (Person contact in AddressBookDictionary[addressBookName])
                {
                    if (cityKey.ToLower() == contact.City.ToLower())
                    {
                        cityPersons[cityKey].Add(contact);
                    }
                    if (stateKey.ToLower() == contact.State.ToLower())
                    {
                        statePerson[stateKey].Add(contact);
                    }
                }
            }
            PersonSearchDisplay(cityPersons, statePerson, cityKey, stateKey);
        }


        public static void PersonSearchDisplay(Dictionary<string, List<Person>> cityPersons, Dictionary<string, List<Person>> statePersons, string cityKey, string stateKey)
        {
            Console.WriteLine("------------------- Persons in {0} city-------------------------", cityKey);
            foreach (Person contact in cityPersons[cityKey])
            {
                Console.WriteLine("{0}", contact.FirstName);
            }
            Console.WriteLine("--------------------Persons in {0} state", stateKey);
            foreach (Person contact in statePersons[stateKey])
            {
                Console.WriteLine("{0}", contact.FirstName);
            }
            Console.WriteLine("Total count of persons in the city {0} is {1}", cityKey, cityPersons[cityKey].Count);
            Console.WriteLine("--------------------Persons in {0} state", stateKey);
            foreach (Person contact in statePersons[stateKey])
            {
                Console.WriteLine("{0}", contact.FirstName);
            }


            Console.WriteLine("Total count of persons in the state {0} is {1}", stateKey, statePersons[stateKey].Count);
        }
        public static void SortEntriesAlphabetically()
        {
            Console.Write("Enter the name of address book you want to sort: ");
            string addressBookName = Console.ReadLine();
            Console.WriteLine();

            if (AddressBookDictionary.ContainsKey(addressBookName))
            {
                AddressBookDictionary[addressBookName].Sort((x, y) => x.FirstName.CompareTo(y.FirstName));
                ViewTheDetails();
            }
            else
            {
                Console.WriteLine("This address book doesn't exists in our record.");
            }
        }
        public static void SortByCityStateZip()
        {
            Console.Write("Enter the name of address book you want to sort: ");
            string addressBookName = Console.ReadLine();
            Console.WriteLine("\nNow enter \n1. To sort by cities \n2. To sort by State \n3. To sort by Zip-Code");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (AddressBookDictionary.ContainsKey(addressBookName))
            {
                switch (choice)
                {
                    case 1:
                        AddressBookDictionary[addressBookName].Sort((x, y) => x.City.CompareTo(y.City));
                        break;

                    case 2:
                        AddressBookDictionary[addressBookName].Sort((x, y) => x.State.CompareTo(y.State));
                        break;

                    case 3:
                        AddressBookDictionary[addressBookName].Sort((x, y) => x.ZipCode.CompareTo(y.ZipCode));
                        break;

                    default:
                        Console.WriteLine("Please enter valid input.");
                        break;
                }

                ViewTheDetails();
            }
            else
            {
                Console.WriteLine("This address book doesn't exists in our record.");
            }
        }
        public static void WriteAddressBookUsingStreamWriter()
        {
            string path = @"D:\Blabz\RFP\AddressBookSystem\AddressBookSystem\Files\AddressBook.txt";
            using (StreamWriter se = File.AppendText(path))
            {
                foreach (KeyValuePair<string, List<Person>> item in AddressBookDictionary)
                {
                    foreach (var items in item.Value)
                    {
                        se.WriteLine("First Name -" + items.FirstName);
                        se.WriteLine("Last Name -" + items.LastName);
                        se.WriteLine("Address -" + items.Address);
                        se.WriteLine("Phone Number - " + items.PhoneNumber);
                        se.WriteLine("Email ID -" + items.EmailId);
                        se.WriteLine("City -" + items.City);
                        se.WriteLine("State -" + items.State);
                        se.WriteLine("ZIP Code -" + items.ZipCode);
                    }
                    se.WriteLine("--------------------------------------------------------------");
                }
                se.Close();
                Console.WriteLine(File.ReadAllText(path));
            }
        }
        public static void ReadAddressBookUsingStreamReader()
        {
            Console.WriteLine("The contact List using StreamReader method ");

            string path = @"D:\Blabz\RFP\AddressBookSystem\AddressBookSystem\Files\AddressBook.txt";
            using (StreamReader se = File.OpenText(path))
            {
                string s = " ";
                while ((s = se.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }

            }
        }
        //Writing Csv File

        public static void WriteAddressBookUsingCsvWriter()
        {
            string csvPath = @"D:\Blabz\RFP\AddressBookSystem\AddressBookSystem\Files\AddressBook.csv";
           
            using (var writer=new StreamWriter(csvPath))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach (KeyValuePair<string, List<Person>> item in AddressBookDictionary)
                    {
                        foreach (var items in item.Value)
                        {
                            List<Person> CSV = new List<Person>();
                            CSV.Add(items);
                            csv.WriteRecords(CSV);
                        }
                    }
                }
                writer.Close();
            }
            
        }
        public static void ReadingAllPersonContactsfromCSVFile()
        {
            string csvPath = @"D:\Blabz\RFP\AddressBookSystem\AddressBookSystem\Files\AddressBook.csv";

            using (StreamReader streamreader = new StreamReader(csvPath))
            using (CsvReader csvReader = new CsvReader(streamreader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<Person>().ToList();
                foreach (Person contact in records)
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }


    }
}
