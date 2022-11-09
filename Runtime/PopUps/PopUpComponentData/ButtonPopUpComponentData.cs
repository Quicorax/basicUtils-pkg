using System;

namespace Quicorax
{
    public class ButtonPopUpComponentData : IPopUpComponentData
    {
        public string ButtonText;
        public Action OnButtonAction;
        public bool CloseOnAction;

        public PopUpComponentType ModuleConcept => PopUpComponentType.Button;

        public int ModuleHeight => 70;
    }
}