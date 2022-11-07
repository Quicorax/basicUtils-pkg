using UnityEngine;

namespace Quicorax
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField]
        private CoroutinerService corroutinerPref;
        private CoroutinerService corroutinerInstance;

        private void Start()
        {
            corroutinerInstance = Instantiate(corroutinerPref);

            LevelInitializer();
        }

        private void LevelInitializer()
        {
            ServiceLoader serviceLoader = new();
            serviceLoader.LoadServices(corroutinerInstance);
        }
    }
}
