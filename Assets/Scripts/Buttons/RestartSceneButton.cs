using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class RestartSceneButton : MonoBehaviour
    {
        public void Restart() => SceneManager.LoadScene(0);
    }
}