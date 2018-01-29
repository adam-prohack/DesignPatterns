using System.Collections.Generic;
using System.Text;

namespace CompositePattern.DOM
{
    public abstract class DOMElement
    {
        protected IDictionary<string, string> Attributes = new SortedDictionary<string, string>();
        protected string TagName { get => GetType().Name.Replace("Element", "").ToLower(); }
        protected string GetAttributesString()
        {
            var result = new StringBuilder();

            foreach (var attribute in Attributes)
            {
                result.Append($"{attribute.Key}=\"{attribute.Value}\" ");
            }

            return result.ToString().TrimEnd(' ');
        }

        public DOMElement Parent { get; set; } = null;

        public virtual string Render() => $"<{TagName} {GetAttributesString()}/>";
        public virtual bool SetAttribute(string name, string value)
        {
            Attributes[name] = value;
            return true;
        }
        public virtual bool Add(DOMElement element) => false;
        public virtual bool Remove(DOMElement element) => false;
        public virtual IEnumerable<DOMElement> GetChildItems() => null;
        public virtual DOMElement GetChildItem(int id) => null;
    }
}
