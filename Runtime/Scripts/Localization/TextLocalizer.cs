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

        [SerializeField]
        private GenericEventBus _onLanguageSet;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _onLanguageSet.Event += NewLenguageSet;
        }
        private void OnDisable() => _onLanguageSet.Event -= NewLenguageSet;

        private void Start() => TrySetTextByKey();

        private void TrySetTextByKey()
        {
            if (Key != string.Empty)
                SetLocalizableText(Key);
        }
        private void NewLenguageSet() => TrySetTextByKey();
        public void SetLocalizableText(string textKey) =>
            _text.text = ServiceLocator.GetService<LocalizationService>().
            CurrentLanguage.Localize(textKey) ?? textKey;
    }
}