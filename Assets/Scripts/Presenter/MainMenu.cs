using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pinataIcon;
    [SerializeField] private GameObject _StartButton;
    [SerializeField] private float animationDuration = 1f;

    void Start()
    {
        AnimateOpening(_pinataIcon, 2);
        AnimateOpening(_StartButton, 1);
    }

    private void AnimateOpening(GameObject objectToScale, int scale)
    {
        var finalScale = Vector3.one * scale;
        objectToScale.transform.localScale = Vector3.zero;
        objectToScale.transform.DOScale(finalScale, animationDuration);
    }

    public void StartGame()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
    }
}
