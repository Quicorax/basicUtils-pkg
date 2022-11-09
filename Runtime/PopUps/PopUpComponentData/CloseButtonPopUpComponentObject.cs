using System;
using UnityEngine;
using UnityEngine.UI;

namespace Quicorax
{
    public class CloseButtonPopUpComponentObject : MonoBehaviour, IPopUpComponentObject
    {
        public string ModuleConcept;
        
        private Image _image;

        private Action OnButtonAction;

        private void Awake()
        {
            _image = GetComponentInChildren<Image>();
        }
        public void SetData(IPopUpComponentData unTypedData, Action closeOnUse)
        {
            OnButtonAction = closeOnUse;

            ServiceLocator.GetService<AddressablesService>().
                LoadAdrsAssetOfType<Sprite>("Exit", x => _image.sprite = x);
        }

        public void OnButtonPressed() => OnButtonAction?.Invoke();
    }
}