using System;

namespace FluentBuilder
{
    /*
     * Access Modifiers
     * 
     * public              - The type or member can be accessed by any other code in the same assembly or another assembly that references it.
     * 
     * private             - The type or member can be accessed only by code in the same class or struct
     * 
     * protected           - The type or member can be accessed only by code in the same class, or in a class that is derived from that class
     * 
     * internal            - The type or member can be accessed by any code in the same assembly, but not from another assembly.
     * 
     * protected internal  - The type or member can be accessed by any code in the assembly in which it's declared,
     *                       or from within a derived class in another assembly
     * 
     * private protected   - The type or member can be accessed only within its declaring assembly,
     *                       by code in the same class or in a type that is derived from that class.
     * 
     */

    public class Person
    {
        public string Name;
        public string Position;

        public class Builder : PersonJobBuilder<Builder>
        {
            
        }
        
        public static Builder New => new Builder();
        
        
        public override string ToString()
        {
            return $"{nameof(Name)} : {Name} , {nameof(Position)} : {Position}";
        }

    }


    public abstract class PersonBuilder
    {
        // we are using protected because we will implement inheritance 
        protected Person _person = new Person();

        public Person Build()
        {
            return _person;
        }
    }

    // Now creating person info builder 
    public class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
    {
        // Fluent method 
        public SELF Called(string name)
        {
            _person.Name = name;
            return (SELF) this;
        }
    }


    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>> where SELF: PersonJobBuilder<SELF>
    {
        public SELF WorkAsA(string position)
        {
            _person.Position = position;
            return (SELF) this;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var me = Person.New.Called("Ravi Kant Pal").WorkAsA("Consultant").Build();
            
            Console.WriteLine($"{me} , 😃");
        }
    }
}

