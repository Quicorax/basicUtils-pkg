
namespace Quicorax
{
    public class ServiceLoader
    {
        public void LoadServices()
        {
            AddressablesService addressables = new();
            NavigationService navigation = new();
            LocalizationService localization = new();
            CoroutinerService coroutiner = new();

            ServiceLocator.RegisterService(coroutiner);
            ServiceLocator.RegisterService(addressables);
            ServiceLocator.RegisterService(navigation);
            ServiceLocator.RegisterService(localization);

            coroutiner.Initialize();
            addressables.Initialize(coroutiner);
            localization.Initialize();
        }
    }
}
