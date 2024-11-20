using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pinataIcon;
    [SerializeField] private GameObject _StartButton;
    [SerializeField] private float animationDuration = 1f;

    void Start()
    {
        StartCoroutine(AnimatePinataIcon(_pinataIcon, 2));
        StartCoroutine(AnimatePinataIcon(_StartButton, 1));
    }

    private IEnumerator AnimatePinataIcon(GameObject objectToScale, int scale)
    {
        Vector3 initialScale = Vector3.zero;
        Vector3 finalScale = Vector3.one * scale;
        float elapsedTime = 0f;

        objectToScale.transform.localScale = initialScale;

        while (elapsedTime < animationDuration)
        {
            objectToScale.transform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToScale.transform.localScale = finalScale;
    }

    public void StartGame()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
    }
}
