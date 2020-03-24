using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyPrincipal
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name { get; set; }
    }

    // low - level [ MODULE ]
    public class Relationships : IRelationshipBrowser
    {
        // tuples were introduced in c# 7
        private List<(Person, Relationship, Person)> _relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            _relations.Add((parent, Relationship.Parent, child));
            _relations.Add((child, Relationship.Child, parent));
        }

        // public List<(Person, Relationship, Person)> Relations => _relations;
        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return _relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent)
                .Select(r => r.Item3);
        }
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }


    // how to find that a person have how many children 
    // therefore we create a class 
    public class Research
    {
        // public Research(Relationships relationships)
        // {
        //     var relations = relationships.Relations;
        //     foreach (var r in relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
        //     {
        //         Console.WriteLine($"John has child called {r.Item3.Name} 🤷‍️ \n");
        //     }
        // }

        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John 🙎‍ has a child called {p.Name} 🧍");
            }
        }

     

        static void Main(string[] args)
        {
            Console.WriteLine("Dependency Inversion Principal !!");

            /*  DI - It states that high level module should not be tightly coupled with low level module  */

            // This is implemented using some kind of abstraction using interfaces


            var parent = new Person {Name = "John"};
            var child1 = new Person {Name = "Chris"};
            var child2 = new Person {Name = "Mary"};

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
            Console.ReadKey();
        }
    }

    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         Console.WriteLine("Dependency Inversion Principal !!");
    //
    //         /*  DI - It states that high level module should not be tightly coupled with low level module  */
    //         
    //         // This is implemented using some kind of abstraction using interfaces
    //         
    //
    //         Console.ReadKey();
    //     }
    // }
}