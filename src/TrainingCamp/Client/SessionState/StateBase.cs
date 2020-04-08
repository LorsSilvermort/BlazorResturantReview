using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingCamp.Shared.Enums;
using TrainingCamp.Shared.Model;

namespace TrainingCamp.Client.SessionState
{
    public abstract class StateBase
    {
        public bool IsPending { get; set; }
        public bool DisplayDialog { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

        public event EventHandler StateChanged;
        public virtual void SetState(CurrentState currentState)
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
                    IsPending = false;
                    break;
                case CurrentState.Success:
                    IsPending = false;
                    break;
            }

        }
        public void StateHasChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
