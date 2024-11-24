using DG.Tweening;
using Logic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject pinataIcon;
    [SerializeField] private GameObject sfxManager;
    [SerializeField] private float animationDuration = 1f;

    private void Start()
    {
        AnimateObject(pinataIcon, 2);
        AnimateObject(startButton.gameObject, 1, true);
        SetSfxManager();
    }

    private void SetSfxManager()
    {
        if (DontDestroyOnLoadManager.SfxManager == null)
        {
            DontDestroyOnLoad(sfxManager);
            DontDestroyOnLoadManager.SfxManager = sfxManager;
        }
        else
        {
            Destroy(sfxManager.gameObject);
        }
    }

    private void AnimateObject(GameObject objectToScale, int scale, bool isButton = false)
    {
        var finalScale = Vector3.one * scale;
        objectToScale.transform.localScale = Vector3.zero;
        objectToScale.transform.DOScale(finalScale, animationDuration).OnComplete(() =>
        {
            if (isButton)
            {
                startButton.interactable = true;
            }
        });
    }

    public void StartGame()
    {
        startButton.interactable = false;
        SceneManager.LoadScene("MainScene");
    }
}
