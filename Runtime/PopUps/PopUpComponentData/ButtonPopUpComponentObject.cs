using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quicorax
{
    public class ButtonPopUpComponentObject : MonoBehaviour, IPopUpComponentObject
    {
        public PopUpComponentType ModuleConcept;
        
        [SerializeField]
        private Image _image;

        [SerializeField] 
        private TMP_Text _buttonTextObject;

        private Action _onButtonAction;
        private Action _onButtonClose;

        private bool _closeOnAction;

        public void SetData(IPopUpComponentData unTypedData, Action closeOnUse)
        {
            ButtonPopUpComponentData data = unTypedData as ButtonPopUpComponentData;

            _buttonTextObject.text = data.ButtonText;
            _onButtonAction = data.OnButtonAction;
            _closeOnAction = data.CloseOnAction;
            _onButtonClose = closeOnUse;

            ServiceLocator.GetService<AddressablesService>().
                LoadAdrsAssetOfType<Sprite>("BasePopUpImage", x => _image.sprite = x);
        }

        public void OnButtonPressed()
        {
            _onButtonAction?.Invoke();

            if (_closeOnAction)
                _onButtonClose?.Invoke();
        }
    }
}