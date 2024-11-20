using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PinataView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _pinataImage;
    [SerializeField] private Sprite[] _pinataSprites;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _hitSounds;
    [SerializeField] private AudioClip _explodeSound;
    [SerializeField] private Rigidbody2D _pinataRigidbody;
    [SerializeField] private GameObject pinataParticleSystem;
    [SerializeField] private GameObject[] brokenPinataParts;
    [SerializeField] private GameObject brokenPinataPartsParent;
    
    private float pushForce = 10f;
    
    private int pinataSpriteIndex = 0;
    
    private bool _isExploded = false;
    
    
    public event Action Click;

    public void SetPinataImage()
    {
        pinataSpriteIndex++;
        if (pinataSpriteIndex >= _pinataSprites.Length)
        {
            ExplodePinata();
            _pinataImage.sprite = null;
            _isExploded = true;
            return;
        }
        _pinataImage.sprite = _pinataSprites[pinataSpriteIndex];
    }

    private void ExplodePinata()
    {
        PlayHitSound(_explodeSound);
        brokenPinataPartsParent.SetActive(true);
        foreach (var part in brokenPinataParts)
        {
            var rb = part.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                var randomDirection = Random.insideUnitCircle.normalized;
                rb.AddForce(randomDirection * pushForce/2, ForceMode2D.Impulse);
            }
        }
    }

    private void OnMouseDown()
    {
        if (_isExploded) return;
        var ps = Instantiate(pinataParticleSystem, transform.position, Quaternion.identity);
        PlayHitSound();
        PushPinata();
        Click?.Invoke();
    }

    private void PlayHitSound(AudioClip hitSound = null)
    {
        _audioSource.clip = hitSound != null ? hitSound : _hitSounds[Random.Range(0, _hitSounds.Length)];
        _audioSource.Play();
    }
    
    private void PushPinata()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        _pinataRigidbody.AddForce(randomDirection * pushForce, ForceMode2D.Impulse);
    }
}
