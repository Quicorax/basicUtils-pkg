using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Quicorax
{
    public class LocalizationService : IService
    {
        public event Action OnLanguageSet;
        public LanguageDictionary CurrentLanguage { get; private set; }

        public Dictionary<string, LanguageDictionary> AvailableLanguages = new();

        public void Initialize()
        {
            foreach (LanguageDictionary language in Resources.LoadAll("Languages").OfType<LanguageDictionary>())
            {
                language.Initialize();
                AvailableLanguages.Add(language.name, language);
            }

            SetLenguage("English");
        }

        public void SetLenguage(string language)
        {
            PlayerPrefs.SetString("Language", language);
            CurrentLanguage = Resources.Load<LanguageDictionary>(language);
            OnLanguageSet();
        }

        public string GetLanguage() => PlayerPrefs.GetString("Language");
    }
}