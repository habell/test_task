using Infrastructure.States;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            _game = new Game(this, gameObject);
            _game.StateMachine.Enter<BootstrapState>();
        }
    }
}