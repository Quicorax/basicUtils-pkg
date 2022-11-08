using System;
using UnityEngine;

namespace Quicorax
{
    [CreateAssetMenu(fileName = "GenericEventBus", menuName = "ScriptableObjects/EventBus/Generic")]
    public class GenericEventBus : ScriptableObject
    {
        public event Action Event = delegate () { };
        public void NotifyEvent() => Event?.Invoke();
    }
}