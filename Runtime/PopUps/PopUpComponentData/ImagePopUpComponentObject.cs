using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quicorax
{
    public class ImagePopUpComponentObject : MonoBehaviour, IPopUpComponentObject
    {
        public string ModuleConcept;

        private Image _imageDisplay;
        private GameObject _imageTextGameObject;
        private TMP_Text _imageTextObject;

        private void Awake()
        {
            _imageDisplay = GetComponentInChildren<Image>();

            _imageTextGameObject = transform.GetChild(1).gameObject;
            _imageTextObject = _imageTextGameObject.GetComponent<TMP_Text>();
        }

        public void SetData(IPopUpComponentData unTypedData, Action closeOnUse)
        {
            ImagePopUpComponentData data = unTypedData as ImagePopUpComponentData;

            GetSprite(data.SpriteName);

            if (data.WithText)
            {
                _imageTextGameObject.SetActive(true);
                _imageTextObject.text = data.ImageText;
            }
        }

        private void GetSprite(string data) =>
            ServiceLocator.GetService<AddressablesService>().
            LoadAdrsAssetOfType<Sprite>(data, x => _imageDisplay.sprite = x);
    }
}