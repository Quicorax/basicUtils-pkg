using System;

namespace Quicorax
{
    public class ButtonPopUpComponentData : IPopUpComponentData
    {
        public string ButtonText;
        public Action OnButtonAction;
        public bool CloseOnAction;

        public string ModuleConcept => "Button";

        public int ModuleHeight => 70;
    }
}