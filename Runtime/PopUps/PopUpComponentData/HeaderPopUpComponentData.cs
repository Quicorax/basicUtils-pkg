
namespace Quicorax
{
    public class HeaderPopUpComponentData : IPopUpComponentData
    {
        public bool IsHeaderHighlighted;
        public string HeaderTextContent;

        public string ModuleConcept => "Header";
        public int ModuleHeight => 80;
    }
}