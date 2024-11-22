using System;
using UnityEngine;

public class StickPresenter : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PolygonCollider2D polygonCollider;
    
    public float moveSpeed = 0.1f;
    private Vector3 _mousePosition;
    private static readonly int Hit = Animator.StringToHash("Hit");

    public event Action OnStickHit ;
    
    private void StickHit()
    {
        polygonCollider.enabled = true;
        animator.SetTrigger(Hit);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PinataView>() != null)
        {
            OnStickHit?.Invoke();
        }
        polygonCollider.enabled = false;
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
