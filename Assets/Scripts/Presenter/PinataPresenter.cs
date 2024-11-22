using UnityEngine;
using Random = UnityEngine.Random;

public class PinataView : MonoBehaviour
{
    [SerializeField] private AudioClip[] hitSounds;
    [SerializeField] private AudioClip explodeSound;
    [SerializeField] private Sprite[] pinataSprites;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Collider2D pinataCollider;
    [SerializeField] private SpriteRenderer pinataImage;
    [SerializeField] private Rigidbody2D pinataRigidbody;
    [SerializeField] private GameObject[] brokenPinataParts;
    [SerializeField] private GameObject pinataParticleSystem;
    [SerializeField] private GameObject brokenPinataPartsParent;

    private const float PushForce = 10f;

    public void SetPinataImage(int index)
    {
        if (index >= pinataSprites.Length)
        {
            ExplodePinata();
            pinataImage.sprite = null;
            pinataCollider.enabled = false;
            return;
        }
        pinataImage.sprite = pinataSprites[index];
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
                rb.AddForce(randomDirection * PushForce/2, ForceMode2D.Impulse);
            }
        }
    }

    public void OnStickCollide()
    {
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
        pinataRigidbody.AddForce(randomDirection * PushForce, ForceMode2D.Impulse);
    }
}
