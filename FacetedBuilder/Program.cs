using System;

namespace FacetedBuilder
{
    public class Person
    {
        // address 
        public string StreetAddress, Postcode, City;

        // employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return
                $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class PersonBuilder // facade
    {
        // this is the reference object ->  for which the  
        protected Person _person = new Person();

        // return new instance of the object that we are building - 
        public PersonJobBuilder Works => new PersonJobBuilder(_person); // we now have a property 'Works'
        public PersonAddressBuilder Lives => new PersonAddressBuilder(_person);


        public static implicit operator Person(PersonBuilder pb)
        {
            return pb._person;
        }
        
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            _person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            _person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostalCode(string postalCode)
        {
            _person.Postcode = postalCode;
            return this;
        }

        public PersonAddressBuilder City(string city)
        {
            _person.City = city;
            return this;
        }
    }


    public class PersonJobBuilder : PersonBuilder
    {
        /* we need constructor argument to take a reference to the person that we are actually building */
        public PersonJobBuilder(Person person)
        {
            // whats happening here is that we are building the object 
            _person = person;
        }

        // now building fluent API to build the object for the person 
        public PersonJobBuilder At(string companyName)
        {
            _person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            _person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            _person.AnnualIncome = amount;
            return this;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var personBuilder = new PersonBuilder();
            Person person = personBuilder
                .Works
                    .At("AllState")
                    .AsA("Consultant")
                    .Earning(725000)
                .Lives
                    .At("Kharadi")
                    .City("Pune")
                    .WithPostalCode("123131");
                

            Console.WriteLine(person);
        }
    }
}