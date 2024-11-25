using System;
using Cysharp.Threading.Tasks;

public class PinataLogic
{
    private int _numberOfHits;
    private PinataState _pinataState;

    public event Action<int> OnPinataHit;
    public event Action<int> OnPinataStateChanged;

    public event Action OnEndGame;


    private enum PinataState
    {
        NewPinata,
        HalfBrokenPinata,
        AlmostBrokenPinata,
        BrokenPinata
    }

    public PinataLogic(MainPresenter mainPresenter)
    {
        _pinataState = PinataState.NewPinata;
    }

    public void PinataHit()
    {
        _numberOfHits++;
        OnPinataHit?.Invoke(_numberOfHits);
        CheckHits();
    }

    private void CheckHits()
    {
        switch (_numberOfHits)
        {
            case 3:
                ChangeState(PinataState.HalfBrokenPinata);
                break;
            case 6:
                ChangeState(PinataState.AlmostBrokenPinata);
                break;
            case 10:
                ChangeState(PinataState.BrokenPinata);
                EndGame();
                break;
        }
    }

    private void EndGame()
    {
        OpenTimer(3).Forget();
    }

    private async UniTaskVoid OpenTimer(int seconds)
    {
        await UniTask.Delay(seconds * 1000);
        OnEndGame?.Invoke();
    }

    private void ChangeState(PinataState pinataState)
    {
        _pinataState = pinataState;
        OnPinataStateChanged?.Invoke((int)_pinataState);
    }
}