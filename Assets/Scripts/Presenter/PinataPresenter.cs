using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PinataView : MonoBehaviour
{
    [SerializeField] private Image _pinataImage;
    [SerializeField] private Sprite[] _pinataSprites;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _hitSounds;
    
    private int pinaSpriteIndex = 0;
    
    
    public event Action Click;

    public void SetPinataImage()
    {
        pinaSpriteIndex++;
        if (pinaSpriteIndex >= _pinataSprites.Length)
        {
            _pinataImage.gameObject.SetActive(false);
            return;
        }
        _pinataImage.sprite = _pinataSprites[pinaSpriteIndex];
    }
    
    private void PlayHitSound()
    {
        _audioSource.clip = _hitSounds[Random.Range(0, _hitSounds.Length)];
        _audioSource.Play();
    }
    
    public void OnClick()
    {
        PlayHitSound();
        Click?.Invoke();
    }
}
