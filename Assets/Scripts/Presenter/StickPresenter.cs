using System;
using UnityEngine;

public class StickPresenter : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PolygonCollider2D polygonCollider;
    [SerializeField] private PinataPresenter pinataPresenter;
    [SerializeField] private Camera mainCamera;
    
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
        if (collision.gameObject == pinataPresenter.gameObject)
        {
            OnStickHit?.Invoke();
        }
        polygonCollider.enabled = false;
    }

    private void Update () {
        _mousePosition = Input.mousePosition;
        _mousePosition = mainCamera.ScreenToWorldPoint(_mousePosition);
        transform.position = Vector2.Lerp(transform.position, _mousePosition, moveSpeed);

        if (Input.GetMouseButtonDown(0))
        {
            StickHit();
        }
    }
}
