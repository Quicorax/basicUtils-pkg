using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace Quicorax
{
    public class LocalizationDataUpdater
    {
        [Serializable]
        private class Language
        {
            public string language;
            public List<LanguageDictionary.LocalizationEntry> keys;
        }

        [Serializable]
        private class Languages { public List<Language> data; }

        public static void UpdateLocalization(string url)
        {
            Debug.Log("Updating Localization Data...");

            UnityWebRequest request = WebRequest(url);
            request.SendWebRequest().completed += operation =>
            {
                if (request.error != null)
                {
                    Debug.LogError(request.error);
                    return;
                }

                Languages languages = JsonUtility.FromJson<Languages>(request.downloadHandler.text);             

                foreach (Language specificLanguage in languages.data)
                {
                    System.IO.File.WriteAllText(Application.dataPath + "/Resources/Localization/"+specificLanguage.language + "_data.json",
                        JsonUtility.ToJson(specificLanguage));
                }

                Debug.Log("Succesfully Updated Localization Data!");

                AssetDatabase.Refresh();
            };
        }

        public static UnityWebRequest WebRequest(string url) => new(url, "GET", new DownloadHandlerBuffer(), null);
    }

}
