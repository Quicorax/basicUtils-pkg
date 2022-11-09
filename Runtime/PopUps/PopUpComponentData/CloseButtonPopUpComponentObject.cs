using System;
using UnityEngine;
using UnityEngine.UI;

namespace Quicorax
{
    public class CloseButtonPopUpComponentObject : MonoBehaviour, IPopUpComponentObject
    {
        public PopUpComponentType ModuleConcept;
        
        [SerializeField]
        private Image _image;

        private Action OnButtonAction;

        public void SetData(IPopUpComponentData unTypedData, Action closeOnUse)
        {
            OnButtonAction = closeOnUse;

            ServiceLocator.GetService<AddressablesService>().
                LoadAdrsAssetOfType<Sprite>("Exit", x => _image.sprite = x);
        }

        public void OnButtonPressed() => OnButtonAction?.Invoke();
    }
}