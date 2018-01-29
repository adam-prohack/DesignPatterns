using CompositePattern.DOM;
using System;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var div = new DivElement();
            var paragraph = new PElement();
            var br = new BrElement();
            var text = new TextElement("Example text");
            var image = new ImageElement();

            image.SetAttribute("src", "http://opensourceforu.com/wp-content/uploads/2016/03/Microsoft.png");
            paragraph.Add(text);
            paragraph.Add(br);
            div.Add(image);
            div.Add(paragraph);

            Console.WriteLine("Render div:");
            Console.Write(div.Render());

            Console.WriteLine("Render paragraph:");
            Console.Write(paragraph.Render());

            Console.WriteLine("It works");
        }
    }
}
