
namespace Quicorax
{
    public class ImagePopUpComponentData : IPopUpComponentData
    {
        public bool WithText;
        public string SpriteName;
        public string ImageText;

        public string ModuleConcept => "Image";

        public int ModuleHeight => 90;
    }
}