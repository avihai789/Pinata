using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PinataView : MonoBehaviour
{
    [SerializeField] private Image _pinataImage;
    [SerializeField] private Sprite[] _pinataSprites;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _hitSounds;
    [SerializeField] private AudioClip _explodeSound;
    [SerializeField] Rigidbody2D _pinataRigidbody;
    
    private float pushForce = 10f;
    
    private int pinaSpriteIndex = 0;
    
    
    public event Action Click;

    public void SetPinataImage()
    {
        pinaSpriteIndex++;
        if (pinaSpriteIndex >= _pinataSprites.Length)
        {
            _pinataImage.gameObject.SetActive(false);
            PlayHitSound(_explodeSound);
            return;
        }
        _pinataImage.sprite = _pinataSprites[pinaSpriteIndex];
    }
    
    private void PlayHitSound(AudioClip hitSound = null)
    {
        _audioSource.clip = hitSound != null ? hitSound : _hitSounds[Random.Range(0, _hitSounds.Length)];
        _audioSource.Play();
    }
    
    public void OnClick()
    {
        PlayHitSound();
        PushPinata();
        Click?.Invoke();
    }
    
    private void PushPinata()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        _pinataRigidbody.AddForce(randomDirection * pushForce, ForceMode2D.Impulse);
    }
}
