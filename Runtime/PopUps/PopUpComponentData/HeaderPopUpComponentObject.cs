using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quicorax
{
    public class HeaderPopUpComponentObject : MonoBehaviour, IPopUpComponentObject
    {
        public PopUpComponentType ModuleConcept;

        [SerializeField] 
        private GameObject _basicHeaderObject;
        [SerializeField] 
        private TMP_Text _basicHeaderTextObject;
        [SerializeField] 
        private GameObject _highlightedHeaderObject;
        [SerializeField] 
        private TMP_Text _highlightedHeaderTextObject;
        [SerializeField]
        private Image _image;

        public void SetData(IPopUpComponentData unTypedData, Action closeOnUse)
        {
            HeaderPopUpComponentData data = unTypedData as HeaderPopUpComponentData;

            _basicHeaderObject.SetActive(!data.IsHeaderHighlighted);
            _highlightedHeaderObject.SetActive(data.IsHeaderHighlighted);

            if (data.IsHeaderHighlighted)
                _highlightedHeaderTextObject.text = data.HeaderTextContent;
            else
                _basicHeaderTextObject.text = data.HeaderTextContent;

            ServiceLocator.GetService<AddressablesService>().
                LoadAdrsAssetOfType<Sprite>("BasePopUpImage", x => _image.sprite = x);
        }
    }
}