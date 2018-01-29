using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositePattern.DOM
{
    public class DOMComposite : DOMElement
    {
        protected IList<DOMElement> ChildItems { get; set; } = new List<DOMElement>();

        public override string Render()
        {
            var result = new StringBuilder();

            result.AppendLine($"<{TagName}{GetAttributesString()}>");
            foreach (var childItemResult in ChildItems.Select(e => e.Render()).SelectMany(e => e.Split('\n')))
            {
                result.AppendLine($"\t{childItemResult}");
            }
            result.AppendLine($"</{TagName}>");

            return result.ToString();
        }

        public override bool Add(DOMElement element)
        {
            element.Parent = this;
            ChildItems.Add(element);
            return true;
        }
        public override bool Remove(DOMElement element)
        {
            if (ChildItems.IndexOf(element) >= 0)
            {
                element.Parent = null;
                ChildItems.Remove(element);
                return true;
            }
            return false;
        }
        public override IEnumerable<DOMElement> GetChildItems() => ChildItems;
        public override DOMElement GetChildItem(int id) => ChildItems[id];
    }
}
