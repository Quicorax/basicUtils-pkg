using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Quicorax
{
    public class LocalizationService : IService
    {
        public event Action OnLanguageSet = delegate { };
        public LanguageDictionary CurrentLanguage { get; private set; }

        public Dictionary<string, LanguageDictionary> AvailableLanguages = new();

        public void Initialize()
        {
            foreach (LanguageDictionary language in Resources.LoadAll("Localization").OfType<LanguageDictionary>())
            {
                language.Initialize();
                AvailableLanguages.Add(language.name, language);
            }

            if (PlayerPrefs.GetString("Language") == string.Empty)
                PlayerPrefs.SetString("Language", "English");

            SetLanguage(PlayerPrefs.GetString("Language"));
        }

        public void SetLanguage(string language)
        {
            PlayerPrefs.SetString("Language", language);
            CurrentLanguage = AvailableLanguages[language];
            OnLanguageSet();
        }

        public string GetLanguage() => PlayerPrefs.GetString("Language");
    }
}