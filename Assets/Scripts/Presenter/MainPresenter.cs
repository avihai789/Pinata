using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPresenter : MonoBehaviour
{
    [SerializeField] private PinataView _pinataView;
    [SerializeField] private StickPresenter _stickPresenter;
    [SerializeField] private Camera _camera;
    [SerializeField] private Canvas _canvas;
    
    private PinataLogic _pinataLogic;
    
    private void Start()
    {
        _canvas.worldCamera = Camera.main;
        Destroy(_camera.gameObject);
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
        SceneManager.LoadScene("EndScene", LoadSceneMode.Additive);
    }
}
