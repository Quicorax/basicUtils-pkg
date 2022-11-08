using System;
using UnityEngine;
using System.Collections.Generic;

namespace Quicorax
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

        public static void RegisterService<T>(T service) where T : class, IService
        {
            Type type = typeof(T);

            if (_services.ContainsKey(type))
            {
                Debug.LogError("Service already registered: " + type.Name);
                return;
            }

            _services.Add(type, service);
        }

        public static T GetService<T>() where T : class, IService
        {
            if (!_services.TryGetValue(typeof(T), out IService service))
            {
                Debug.LogError("Service not registered: " + typeof(T).Name);
                return default;
            }
            return (T)service;
        }
    }
}
