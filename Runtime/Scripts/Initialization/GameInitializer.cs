using UnityEngine;

namespace Quicorax
{
    public class GameInitializer : MonoBehaviour
    {

        private void Start()
        {
            LevelInitializer();
        }

        private void LevelInitializer()
        {
            ServiceLoader serviceLoader = new();
            serviceLoader.LoadServices();
        }
    }
}
