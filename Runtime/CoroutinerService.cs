using System;
using System.Collections;
using UnityEngine;

namespace Quicorax
{
    public class CoroutinerService : MonoBehaviour, IService
    {
        public void RunCoroutine<T>(T delayer, Action onComplete) =>
            StartCoroutine(EventCoroutineRunner(delayer, onComplete));
        public void RunCoroutine(float delayer, Action onComplete) =>
            StartCoroutine(NumericCoroutineRunner(delayer, onComplete));
        public void RunCoroutine(int delayer, Action onComplete) =>
            StartCoroutine(NumericCoroutineRunner(delayer, onComplete));

        private IEnumerator EventCoroutineRunner<T>(T delayer, Action onComplete)
        {
            yield return delayer;
            onComplete?.Invoke();
        }
        private IEnumerator NumericCoroutineRunner(float delayer, Action onComplete)
        {
            yield return new WaitForSeconds(delayer);
            onComplete?.Invoke();
        }
    }
}
