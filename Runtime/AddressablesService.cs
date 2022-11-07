using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Quicorax
{
    public class AddressablesService : IService
    {
        private CoroutinerService _coroutiner;

        public void Initialize(CoroutinerService coroutiner) =>
            _coroutiner = coroutiner;

        public void LoadAdrsAsset(string adrsKey, Action<GameObject> onAssetLoaded)
        {
            var ardsAsset = Addressables.LoadAssetAsync<GameObject>(adrsKey);
            _coroutiner.RunCoroutine(ardsAsset, () =>
            {
                onAssetLoaded?.Invoke(ardsAsset.Result);
            });
        }
    }
}
