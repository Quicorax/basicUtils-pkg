using System;

namespace Quicorax
{
    //public enum PopUpComponentType { Price, Button, CloseButton, Image, Text, Header };
    public interface IPopUpComponentObject
    {
        public void SetData(IPopUpComponentData unTypedData, Action closeOnUse);
    }
}