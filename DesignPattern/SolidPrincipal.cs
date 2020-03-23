using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPattern
{
    /*
     * S - Single Responsibility Principle
     * O - Open Close Principal
     * L - Liskov Substitution Principal
     * I - Interface Segregation Principal
     * D - Dependency Principal
     */
    public class Journal // This class is only responsible to manipulate journal 
    {
        private readonly List<string> _entries = new List<string>();
        private static int _count = 0;


        public int AddEntry(string text)
        {
            _entries.Add($"{++_count} : {text}");
            return _count; // memento pattern 
        }

        public void RemoveEntry(int index)
        {
            _entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries);
        }
    }

    public class Persistence // this class only responsible for persisting data 
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }

        // public static Journal Load(string filename)
        // {
        // }
        //
        // public void Load(Uri url)
        // {
        // }
    }
}