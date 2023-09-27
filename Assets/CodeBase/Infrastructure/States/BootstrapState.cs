using System;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        public BootstrapState(IGameStateMachine gameStateMachine)
        {
            Debug.Log("Boostrap State Entered");
        }

        public void Enter()
        {
        }
        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}