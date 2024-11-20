using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPresenter : MonoBehaviour
{
    [SerializeField] private PinataView _pinataView;
    
    private PinataLogic _pinataLogic;
    
    private void Start()
    {
        _pinataLogic = new PinataLogic(this);
        _pinataView.Click += _pinataLogic.PinataHit;
    }
    
    private void OnDestroy()
    {
        _pinataView.Click -= _pinataLogic.PinataHit;
    }

    public void PinataStateChanged()
    {
        _pinataView.SetPinataImage();
    }
}
