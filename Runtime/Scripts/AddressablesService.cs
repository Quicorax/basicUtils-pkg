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

        private IEnumerator AssetLoded(string adrsKey, Action<GameObject> onAssetLoaded)
        {
            var ardsAsset = Addressables.LoadAssetAsync<GameObject>(adrsKey);
            yield return ardsAsset;

            onAssetLoaded?.Invoke(ardsAsset.Result);
        }
    }
}
