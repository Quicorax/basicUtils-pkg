using System;

namespace Quicorax
{
    public class ServiceLoader
    {
        public void LoadServices(CoroutinerService coroutiner)
        {
            AddressablesService addressables = new();
            NavigationService navigation = new();
            LocalizationService localization = new();

            ServiceLocator.RegisterService(coroutiner);
            ServiceLocator.RegisterService(addressables);
            ServiceLocator.RegisterService(navigation);
            ServiceLocator.RegisterService(localization);

            addressables.Initialize(coroutiner);
            localization.Initialize();
        }
    }
}
