﻿
namespace Quicorax
{
    public class TextPopUpComponentData : IPopUpComponentData
    {
        public string TextContent;

        public PopUpComponentType ModuleConcept => PopUpComponentType.Text;

        public int ModuleHeight => 90;
    }
}