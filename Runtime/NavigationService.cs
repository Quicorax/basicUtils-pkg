using UnityEngine;
using UnityEngine.SceneManagement;

namespace Quicorax
{
    public class NavigationService : IService
    {
        public void NavigateToScene(string sceneName) =>
            SceneManager.LoadScene(sceneName);

        public void ExitGame()
        {
#if (UNITY_EDITOR || UNITY_WEBGL)
            Debug.Log("Application Quit!");
            return;
#endif

            Application.Quit();
        }
    }
}