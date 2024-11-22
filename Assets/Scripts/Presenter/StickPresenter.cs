using System;
using UnityEngine;
using UnityEngine.Serialization;

public class StickPresenter : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PolygonCollider2D collider2D;
    private static readonly int Hit = Animator.StringToHash("Hit");
    private Vector3 _mousePosition;
    public float moveSpeed = 0.1f;

    public event Action OnStickHit ;
    
    private void StickHit()
    {
        collider2D.enabled = true;
        animator.SetTrigger(Hit);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PinataView>() != null)
        {
            OnStickHit?.Invoke();
        }
        collider2D.enabled = false;
    }

    private void Update () {
        _mousePosition = Input.mousePosition;
        _mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
        transform.position = Vector2.Lerp(transform.position, _mousePosition, moveSpeed);

        if (Input.GetMouseButtonDown(0))
        {
            StickHit();
        }
    }
}
