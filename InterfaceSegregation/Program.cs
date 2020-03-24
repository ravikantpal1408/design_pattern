using System;

namespace InterfaceSegregation
{
    public class Document
    {
        
    }

    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class MultiFunctionPrinter : IPrinter, IScan
    {
        public void Print(Document d)
        {
            // 
        }

        public void Scan(Document d)
        {
            //
        }

        public void Fax(Document d)
        {
            //
        }
    }

    public class OldFashionedPrinter
    {
        
    }
    
    // instead of having one big IMachine interface one can chunk the functionality into different printer 
    public interface IPrinter
    {
        // contains Printing contracts
        void Print(Document d);
    }

    public interface IScan
    {
        // contains Scanning contracts
        void Scan(Document d);
    }
    
    // now suppose there is a Photocopier class we can implement both the interface face into that class

    public class Photocopier: IPrinter, IScan
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            /* If interface is getting populated then you should chunk into pieces */
            
            Console.WriteLine("Interface Segregation Principal !!");
        }
        
        
    }
}