using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Quicorax
{
    public class AddressablesService : IService
    {
        private CoroutinerService _coroutiner;

        public void Initialize(CoroutinerService coroutiner) =>
            _coroutiner = coroutiner;

        public void LoadAdrsAsset(string adrsKey, Action<GameObject> onAssetLoaded) =>
            _coroutiner.RunCoroutine(AssetLoded(adrsKey, onAssetLoaded));
        public void LoadAdrsAssetOfType<T>(string adrsKey, Action<T> onAssetLoaded) =>
            _coroutiner.RunCoroutine(AssetLoded(adrsKey, onAssetLoaded));
        public void InstanceAdrsOfComponent<T>(string key, Transform parent, Action<T> taskAction) =>
            _coroutiner.RunCoroutine(LoadAdrsOfComponentAsync(key, parent, taskAction));

        private IEnumerator AssetLoded<T>(string adrsKey, Action<T> onAssetLoaded)
        {
            var ardsAsset = Addressables.LoadAssetAsync<T>(adrsKey);
            yield return ardsAsset;

            onAssetLoaded?.Invoke(ardsAsset.Result);
        }

        private IEnumerator LoadAdrsOfComponentAsync<T>(string key, Transform parent, Action<T> taskAction)
        {
            var ardsAsset = Addressables.LoadAssetAsync<GameObject>(key);
            yield return ardsAsset;

            var adrsObject = Addressables.InstantiateAsync(key, parent);
            yield return adrsObject;

            GameObject loadedAsset = adrsObject.Result;
            taskAction?.Invoke(loadedAsset.GetComponent<T>());
        }
    }
}
