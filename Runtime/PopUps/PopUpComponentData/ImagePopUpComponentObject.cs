using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quicorax
{
    public class ImagePopUpComponentObject : MonoBehaviour, IPopUpComponentObject
    {
        public PopUpComponentType ModuleConcept;

        [SerializeField] 
        private Image _imageDisplay;
        [SerializeField] 
        private GameObject _imageTextGameObject;
        [SerializeField] 
        private TMP_Text _imageTextObject;

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