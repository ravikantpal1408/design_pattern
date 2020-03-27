using System;
using System.Collections.Generic;
using System.Text;

namespace Builder {
    public class HtmlElement {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement> ();
        private const int indentSize = 2;

        public HtmlElement () { }

        public HtmlElement (string name, string text) {
            Name = name ??
                throw new ArgumentNullException (paramName: nameof (name));
            Text = text ??
                throw new ArgumentNullException (paramName: nameof (text));
        }

        private string ToStringImpl (int indent) {
            var sb = new StringBuilder ();
            var i = new string (' ', indentSize * indent);
            sb.Append ($"{i}<{Name}>");
            if (!string.IsNullOrWhiteSpace (Text)) {
                sb.Append (new string (' ', indentSize * (indent + 1)));
                sb.AppendLine (Text);
            }

            foreach (var element in Elements) {
                sb.Append (element.ToStringImpl (indent + 1));
            }

            sb.Append ($"{i}</{Name}>");

            return sb.ToString ();
        }

        public override string ToString () {
            return ToStringImpl (0);
        }
    }

    public class HtmlBuilder {
        private readonly string _rootName;
        HtmlElement root = new HtmlElement ();

        public HtmlBuilder (string rootName) {
            _rootName = rootName;
            root.Name = rootName;
        }

        public void AddChild (string childName, string childText) {
            var e = new HtmlElement (childName, childText);
            root.Elements.Add (e);
        }

        public override string ToString () {
            return root.ToString ();
        }

        public void Clear () {
            root = new HtmlElement { Name = _rootName };
        }

    }

    class Program {
        /* Builder creation design pattern */

        // Motivation :
        // 1- Some object are simple and can be created in a single constructor call
        // 2- Other object require a lot of ceremony to create
        // 3- HaHaving an object 10 constructor argument is not productive
        // 4- Instead, opt for piecewise construction
        // 5- Builder provides an API for constructing an object step by step
        static void Main (string[] args) {
            var hello = "hello";
            var sb = new StringBuilder ();
            sb.Append ("<p>");
            sb.Append (hello);
            sb.Append ("</p>");
            Console.WriteLine (sb); // simple example of builder pattern

            var words = new [] { "Hello", "World" };
            sb.Clear ();
            sb.Append ("<ul>");
            foreach (var word in words) {
                sb.AppendFormat ("<li>{0}</li>", word);
            }

            sb.Append ("</ul>");

            Console.WriteLine (sb);

            var builder = new HtmlBuilder ("ul");
            builder.AddChild ("li", "hello");
            builder.AddChild ("li", "world");

            Console.WriteLine (builder.ToString ());

            Console.ReadKey ();
        }
    }
}