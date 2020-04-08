using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingCamp.Shared.Enums;

namespace TrainingCamp.Client.SessionState
{
    public class AddState : StateBase
    {
        public override void SetState(CurrentState currentState)
        {
            switch (currentState)
            {
                case CurrentState.Start:
                    IsPending = false;
                    break;
                case CurrentState.Active:
                    IsPending = false;
                    break;
                case CurrentState.Pending:
                    IsPending = true;
                    break;
                case CurrentState.Complete:
                    IsPending = false;
                    break;
                case CurrentState.Error:
                    DisplayDialog = true;
                    IsPending = false;
                    break;
                case CurrentState.Success:
                    IsPending = false;
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
