using UnityEngine.SceneManagement;

namespace Logic
{
    public static class ScenesManager
    {
        public enum ScenesEnum
        {
            MainMenu,
            MainScene,
            EndScene
        }
        
        public static void LoadScene(ScenesEnum scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
    }
}