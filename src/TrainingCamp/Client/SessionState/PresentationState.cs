
using TrainingCamp.Shared.Enums;

namespace TrainingCamp.Client.SessionState
{
    public class PresentationState : StateBase
    {
        public override void SetState(CurrentState currentState)
        {
            switch (currentState)
            {
                case CurrentState.Start:
                    IsPending = false;
                    DisplayDialog = false;
                    base.StateHasChanged();
                    break;
                case CurrentState.Active:
                    IsPending = false;
                    break;
                case CurrentState.Pending:
                    IsPending = true;
                    base.StateHasChanged();
                    break;
                case CurrentState.Complete:
                    IsPending = false;
                    break;
                case CurrentState.Error:
                    DisplayDialog = true;
                    IsPending = false;
                    base.StateHasChanged();
                    break;
                case CurrentState.Success:
                    IsPending = false;
                    base.StateHasChanged();
                    break;
            }
        }
        public void SetDefaultMessage()
        {
            Message = "Något har gått fel";
            Title = "Varning";
        }
    }
}
