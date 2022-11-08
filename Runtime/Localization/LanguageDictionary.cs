using System.Collections.Generic;
using System;
using UnityEngine;

namespace Quicorax
{
    [CreateAssetMenu]
    public class LanguageDictionary : ScriptableObject
    {
        [Serializable]
        public class LocalizationEntry
        {
            public string key;
            public string value;
        }

        [SerializeField]
        private List<LocalizationEntry> keys = new();

        [SerializeField]
        private TextAsset _textAsset;

        public void Initialize() =>
            JsonUtility.FromJsonOverwrite(_textAsset.text, this);

        public string Localize(string key) => keys.Find(x => x.key == key)?.value ?? key;
    }
}