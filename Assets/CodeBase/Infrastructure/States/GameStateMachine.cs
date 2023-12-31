using System;
using System.Collections.Generic;
using CodeBase.Services;
using CodeBase.Services.Factories;

namespace CodeBase.Infrastructure.States
{
  /// <summary>
  /// Game State Machine is responsible for handling states of the game
  /// It gives a controllable flow of the game
  /// </summary>
  public class GameStateMachine : IGameStateMachine
  {
    private readonly AllServices _services;
    private Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    public GameStateMachine(AllServices services)
    {
      _services = services;
      _states = new Dictionary<Type, IExitableState>
      {
        [typeof(BootstrapState)] = new BootstrapState(this, _services),
        [typeof(LoadLevelState)] = new LoadLevelState(this, _services.Single<IGameFactory>(), _services.Single<IStaticDataService>()),
        [typeof(GameLoopState)] = new GameLoopState(this),
      };
    }

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      _activeState?.Exit();
      
      TState state = GetState<TState>();
      _activeState = state;
      
      return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState => 
      _states[typeof(TState)] as TState;
  }
}

