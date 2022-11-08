using TMPro;
using UnityEngine;

namespace Quicorax
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextLocalizer : MonoBehaviour
    {
        [SerializeField]
        private string Key;

        private TMP_Text _text;

        private LocalizationService _localization;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _localization = ServiceLocator.GetService<LocalizationService>();

            _localization.OnLanguageSet += TrySetTextByKey;
        }
        private void OnDisable() => _localization.OnLanguageSet -= TrySetTextByKey;

        private void Start() => TrySetTextByKey();

        private void TrySetTextByKey()
        {
            if (Key != string.Empty)
                SetLocalizableText(Key);
        }
        public void SetLocalizableText(string textKey) =>
            _text.text = _localization.CurrentLanguage.Localize(textKey) ?? _text.text;
    }
}