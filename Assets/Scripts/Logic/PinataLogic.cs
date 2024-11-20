
// Purpose: Contains the logic for the Pinata object.


public class PinataLogic
{
    private int _numberOfHits = 0;
    private PinataState _pinataState;
    private readonly MainPresenter _mainPresenter;

    enum PinataState
    {
        NewPinata,
        HalfBrokenPinata,
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
            case 5:
                ChangeState(PinataState.HalfBrokenPinata);
                break;
            case 10:
                ChangeState(PinataState.BrokenPinata);
                Explode();
                break;
        }
    }

    private void ChangeState(PinataState pinataState)
    {
        _pinataState = pinataState;
        _mainPresenter.PinataStateChanged();
    }

    private void Explode()
    {
        throw new System.NotImplementedException();
    }
}
