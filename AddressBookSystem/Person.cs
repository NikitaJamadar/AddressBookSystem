using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }

        public override string ToString()
        {
            return $"firstName : {this.FirstName}\nlastName : {this.LastName}\naddress : {this.Address}\ncity : {this.City}\nstate : {this.State}\nzipCode : {this.ZipCode}\nphoneNo : {this.PhoneNumber}\nemail : {this.EmailId}";
        }
    }
}




