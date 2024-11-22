using Cysharp.Threading.Tasks;

public class PinataLogic
{
    private int _numberOfHits;
    private PinataState _pinataState;
    private readonly MainPresenter _mainPresenter;

    private enum PinataState
    {
        NewPinata,
        HalfBrokenPinata,
        AlmostBrokenPinata,
        BrokenPinata
    }
    
    public PinataLogic(MainPresenter mainPresenter)
    {
        this._mainPresenter = mainPresenter;
        _pinataState = PinataState.NewPinata;
    }
    
    public void PinataHit()
    {
        _numberOfHits++;
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
                ResetGame();
                break;
        }
    }

    private void ResetGame()
    {
        _numberOfHits = 0;
        ChangeState(PinataState.NewPinata);
        OpenTimer(5).Forget();
    }

    private async UniTaskVoid OpenTimer(int seconds)
    {
        await UniTask.Delay(seconds * 1000);
        _mainPresenter.RestartGame();
    }

    private void ChangeState(PinataState pinataState)
    {
        _pinataState = pinataState;
        _mainPresenter.PinataStateChanged();
    }
}
