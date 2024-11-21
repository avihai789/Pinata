using UnityEngine;

public class StickPresenter : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int Hit = Animator.StringToHash("Hit");

    public void StickHit()
    {
        _animator.SetTrigger(Hit);
    }
}
