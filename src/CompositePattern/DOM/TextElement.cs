namespace CompositePattern.DOM
{
    public class TextElement : DOMElement
    {
        readonly string _value;

        public override string Render() => _value;

        public TextElement(string value)
        {
            _value = value;
        }
    }
}
