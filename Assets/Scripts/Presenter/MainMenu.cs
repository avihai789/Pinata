using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pinataIcon;
    [SerializeField] private GameObject _StartButton;
    [SerializeField] private float animationDuration = 1f;

    void Start()
    {
        _ = AnimatePinataIcon(_pinataIcon, 2);
        _ = AnimatePinataIcon(_StartButton, 1);
    }

    private async UniTask AnimatePinataIcon(GameObject objectToScale, int scale)
    {
        var initialScale = Vector3.zero;
        var finalScale = Vector3.one * scale;
        var elapsedTime = 0f;

        objectToScale.transform.localScale = initialScale;

        while (elapsedTime < animationDuration)
        {
            objectToScale.transform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            await UniTask.Yield();
        }

        objectToScale.transform.localScale = finalScale;
    }

    public void StartGame()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
    }
}
