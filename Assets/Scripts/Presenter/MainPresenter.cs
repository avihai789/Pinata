using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPresenter : MonoBehaviour
{
    [SerializeField] private PinataView pinataView;
    [SerializeField] private StickPresenter stickPresenter;
    
    private PinataLogic _pinataLogic;
    
    private void Start()
    {
        _pinataLogic = new PinataLogic(this);
        stickPresenter.OnStickHit += StickHitPinata;
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

    public void PinataStateChanged(int index)
    {
        pinataView.SetPinataImage(index);
    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }
}
