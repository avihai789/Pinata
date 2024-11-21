using UnityEngine;

public class StickPresenter : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int Hit = Animator.StringToHash("Hit");

    public void StickHit()
    {
        _animator.SetTrigger(Hit);
    }
    
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
	
    private void Update () {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
}
