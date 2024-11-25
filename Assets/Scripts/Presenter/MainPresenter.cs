using Logic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainPresenter : MonoBehaviour
{
    [SerializeField] private PinataPresenter pinataPresenter;
    [SerializeField] private StickPresenter stickPresenter;
    [SerializeField] private TextMeshProUGUI hitsCounterText;
    
    private PinataLogic _pinataLogic;
    
    private void Start()
    {
        _pinataLogic = new PinataLogic(this);
        stickPresenter.OnStickHit += StickHitPinata;
        _pinataLogic.OnPinataHit += UpdateHitsCounter;
        _pinataLogic.OnPinataStateChanged += PinataStateChanged;
    }

    private void StickHitPinata()
    {
        pinataPresenter.OnStickCollide();
        _pinataLogic.PinataHit();
    }

    private void OnDestroy()
    {
        stickPresenter.OnStickHit -= StickHitPinata;
        _pinataLogic.OnPinataHit -= UpdateHitsCounter;
        _pinataLogic.OnPinataStateChanged -= PinataStateChanged;
    }

    private void PinataStateChanged(int index)
    {
        pinataPresenter.SetPinataImage(index);
    }

    private void UpdateHitsCounter(int numOfHits)
    {
        hitsCounterText.text = $"Number of hits:{numOfHits}";
    }

    public void EndGame()
    {
        ScenesManager.LoadScene(ScenesManager.ScenesEnum.EndScene);
    }
}
