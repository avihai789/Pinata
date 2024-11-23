using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPresenter : MonoBehaviour
{
    [SerializeField] private PinataView pinataView;
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
        pinataView.OnStickCollide();
        _pinataLogic.PinataHit();
    }

    private void OnDestroy()
    {
        stickPresenter.OnStickHit -= StickHitPinata;
    }

    private void PinataStateChanged(int index)
    {
        pinataView.SetPinataImage(index);
    }
    
    public void UpdateHitsCounter(int numOfHits)
    {
        hitsCounterText.text = "Number of hits:" + numOfHits;
    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }
}
