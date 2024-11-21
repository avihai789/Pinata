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
        _pinataView.Click += _pinataLogic.PinataHit;
        _pinataView.Click += _stickPresenter.StickHit;
    }
    
    private void OnDestroy()
    {
        _pinataView.Click -= _pinataLogic.PinataHit;
        _pinataView.Click -= _stickPresenter.StickHit;
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
