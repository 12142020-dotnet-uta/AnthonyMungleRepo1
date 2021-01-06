using System;
using System.ComponentModel.DataAnnotations;

namespace Project1
{
    public class Customer
    {
        private Guid customerId = Guid.NewGuid(); //Creates a new Guid For CustomerId
        [Key]//Sets the below to be the key for the database
        public Guid CustomerId { get { return customerId; } set { customerId = value; } } //Sets a public Guid to the above guid and returns the value


        public string Uname;
    
        public string Fname;

        public string Lname;


       

    }
}