using System;
using System.Collections;
using UnityEngine;

namespace Quicorax
{
    public class CoroutinerService : IService
    {
        public class Runner : MonoBehaviour { }

        private Runner _runner = null;

        public void Initialize()
        {
            _runner = new GameObject("Corroutiner").AddComponent<Runner>();
            UnityEngine.Object.DontDestroyOnLoad(_runner.gameObject);
        }

        public void RunCoroutine(IEnumerator corroutine) =>
            _runner.StartCoroutine(corroutine);

    }
}