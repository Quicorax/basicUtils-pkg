using UnityEngine;

namespace Quicorax
{
    public class GameInitializer : MonoBehaviour
    {
        private CoroutinerService _corroutiner;

        private void Start()
        {
            _corroutiner = GetComponentInChildren<CoroutinerService>();
            LevelInitializer();
        }

        private void LevelInitializer()
        {
            ServiceLoader serviceLoader = new();
            serviceLoader.LoadServices(_corroutiner);
        }
    }
}
