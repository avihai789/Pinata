using Logic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public void RestartGame()
    {
        ScenesManager.LoadScene(ScenesManager.ScenesEnum.MainMenu);
    }
}
