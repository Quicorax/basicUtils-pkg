using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quicorax
{
    public class HeaderPopUpComponentObject : MonoBehaviour, IPopUpComponentObject
    {
        public string ModuleConcept;

        private GameObject _basicHeaderObject;
        private TMP_Text _basicHeaderTextObject;

        private GameObject _highlightedHeaderObject;
        private TMP_Text _highlightedHeaderTextObject;
        private Image _image;

        private void Awake()
        {
            Transform baseText = transform.GetChild(0);
            _basicHeaderObject = baseText.gameObject;
            _basicHeaderTextObject = baseText.GetComponent<TMP_Text>();

            Transform hightlightedText = transform.GetChild(1);
            _highlightedHeaderObject = hightlightedText.gameObject;
            _image = hightlightedText.GetComponent<Image>();
            _highlightedHeaderTextObject = hightlightedText.GetComponentInChildren<TMP_Text>();
        }

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