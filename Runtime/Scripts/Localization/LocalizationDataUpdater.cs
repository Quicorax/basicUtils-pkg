using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace Quicorax
{
    public static class LocalizationDataUpdater
    {
        [Serializable]
        private class Language { public List<LanguageDictionary.LocalizationEntry> data; }

        [Serializable]
        private class Languages
        {
            public Language English;
            public Language Spanish;
            public Language Catalan;
        }

        public static void UpdateLocalization(string url)
        {
            UnityWebRequest request = WebRequest(url);
            request.SendWebRequest().completed += operation =>
            {
                if (request.error != null)
                {
                    Debug.Log(request.error);
                    return;
                }

                Debug.Log("Localization Data updated with -> " + request.downloadHandler.text);

                Languages languages = JsonUtility.FromJson<Languages>(request.downloadHandler.text);

                Dictionary<string, Language> availableLanguages = new()
                {
                    { "English", languages.English},
                    { "Spanish", languages.Spanish},
                    { "Catalan", languages.Catalan}
                };

                foreach (var item in availableLanguages)
                {
                    System.IO.File.WriteAllText(Application.dataPath + "/Resources/"+ item.Key +"_file.json",
                        JsonUtility.ToJson(item.Value));
                }
                
                AssetDatabase.Refresh();
            };
        }

        public static UnityWebRequest WebRequest(string url) => new(url, "GET", new DownloadHandlerBuffer(), null);
    }
}