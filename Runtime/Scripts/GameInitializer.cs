using UnityEngine;

namespace Quicorax
{
    public class GameInitializer : MonoBehaviour
    {
        private CoroutinerService corroutiner;

        private void Start()
        {
            corroutiner = GetComponentInChildren<CoroutinerService>();
            LevelInitializer();
        }

        private void LevelInitializer()
        {
            ServiceLoader serviceLoader = new();
            serviceLoader.LoadServices(corroutiner);
        }
    }
}
