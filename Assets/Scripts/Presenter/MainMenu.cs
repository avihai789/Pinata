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
        AnimateOpening(pinataIcon, 2);
        AnimateOpening(startButton.gameObject, 1);
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

    private void AnimateOpening(GameObject objectToScale, int scale)
    {
        var finalScale = Vector3.one * scale;
        objectToScale.transform.localScale = Vector3.zero;
        objectToScale.transform.DOScale(finalScale, animationDuration).OnComplete(() =>
        {
            startButton.interactable = true;
        });
    }

    public void StartGame()
    {
        startButton.interactable = false;
        SceneManager.LoadScene("MainScene");
    }
}
