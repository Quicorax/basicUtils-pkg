using System;
using TMPro;
using UnityEngine;

namespace Quicorax
{
    public class TextPopUpComponentObject : MonoBehaviour, IPopUpComponentObject
    {
        public string ModuleConcept;

        private TMP_Text TextObject;

        private void Awake()
        {
            TextObject = GetComponentInChildren<TMP_Text>();
        }

        public void SetData(IPopUpComponentData unTypedData, Action closeOnUse)
        {
            TextPopUpComponentData data = unTypedData as TextPopUpComponentData;

            TextObject.text = data.TextContent;
        }
    }
}