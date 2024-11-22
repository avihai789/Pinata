using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using Random = UnityEngine.Random;

public class PinataView : MonoBehaviour
{
    [SerializeField] private AudioClip[] hitSounds;
    [SerializeField] private AudioClip explodeSound;
    [SerializeField] private Sprite[] pinataSprites;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SpriteRenderer pinataImage;
    [SerializeField] private Rigidbody2D pinataRigidbody;
    [SerializeField] private GameObject[] brokenPinataParts;
    [SerializeField] private GameObject pinataParticleSystem;
    [SerializeField] private GameObject brokenPinataPartsParent;
    
    private readonly float _pushForce = 30f;
    
    private int _pinataSpriteIndex = 0;
    
    private bool _isExploded = false;

    public void SetPinataImage()
    {
        _pinataSpriteIndex++;
        if (_pinataSpriteIndex >= pinataSprites.Length)
        {
            ExplodePinata();
            pinataImage.sprite = null;
            _isExploded = true;
            return;
        }
        pinataImage.sprite = pinataSprites[_pinataSpriteIndex];
    }

    private void ExplodePinata()
    {
        PlayHitSound(explodeSound);
        brokenPinataPartsParent.SetActive(true);
        foreach (var part in brokenPinataParts)
        {
            var rb = part.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                var randomDirection = Random.insideUnitCircle.normalized;
                rb.AddForce(randomDirection * _pushForce/2, ForceMode2D.Impulse);
            }
        }
    }

    public void OnStickCollide()
    {
        if (_isExploded) return;
        var ps = Instantiate(pinataParticleSystem, transform.position, Quaternion.identity);
        PlayHitSound();
        PushPinata();
    }

    private void PlayHitSound(AudioClip hitSound = null)
    {
        audioSource.clip = hitSound != null ? hitSound : hitSounds[Random.Range(0, hitSounds.Length)];
        audioSource.Play();
    }
    
    private void PushPinata()
    {
        var randomDirection = Random.insideUnitCircle.normalized;
        pinataRigidbody.AddForce(randomDirection * _pushForce, ForceMode2D.Impulse);
    }
}
