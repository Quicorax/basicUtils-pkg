using System.Collections.Generic;

namespace Quicorax
{
    public class LocalizationService : IService
    {
        public LanguageDictionary CurrentLanguage { get; private set; }
        public Dictionary<string, LanguageDictionary> AvailableLanguages = new();
    }
}