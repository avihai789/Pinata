using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPresenter : MonoBehaviour
{
    [SerializeField] private PinataView _pinataView;
    [SerializeField] private StickPresenter _stickPresenter;
    
    private PinataLogic _pinataLogic;
    
    private void Start()
    {
        _pinataLogic = new PinataLogic(this);
        _stickPresenter.OnStickHit += StickHitPinata;
    }

    private void StickHitPinata()
    {
        _pinataLogic.PinataHit();
        _pinataView.OnStickCollide();
    }

    private void OnDestroy()
    {
        _stickPresenter.OnStickHit -= StickHitPinata;
    }

    public void PinataStateChanged()
    {
        _pinataView.SetPinataImage();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("EndScene");
    }
}
