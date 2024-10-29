using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SotomaYorch.FiniteStateMachine;
using SotomaYorch.FiniteStateMachine.Agents;
using Unity.VisualScripting;
using TMPro;

namespace SotomaYorch.AvoidDetection
{
    #region Enums

    public enum GameStates
    {
        START,
        GAME,
        PAUSE,
        VICTORY,
        DRAW,
        GAME_OVER
    }

    public enum ActionGameMechanic
    {
        TO_START,
        TO_GAME,
        TO_PAUSE,
        TO_VICTORY,
        TO_DRAW,
        TO_GAME_OVER
    }

    #endregion

    public class LevelReferee : MonoBehaviour
    {
        #region References

        [SerializeField] protected TextMeshProUGUI _textMeshPro;

        #endregion

        #region RuntimeVariables

        [SerializeField] protected GameStates _gameState;
        protected PlayersAvatar _avatarForGameOver;

        #endregion

        #region UnityMethods

        void Start()
        {
            IntializeLevelReferee();
        }

        void FixedUpdate()
        {
            switch (_gameState)
            {
                case GameStates.START:
                    ExecutingStartStateMethod();
                    break;
                case GameStates.GAME:
                    ExecutingGameStateMethod();
                    break;
                case GameStates.PAUSE:
                    //ExecutingPauseStateMethod();
                    break;
                case GameStates.VICTORY:
                    //ExecutingVictoryStateMethod();
                    break;
                case GameStates.DRAW:
                    //ExecutingDrawStateMethod();
                    break;
                case GameStates.GAME_OVER:
                    //ExecutingGameOverStateMethod();
                    break;
            }
        }

        #endregion

        #region LocalMethods

        protected virtual void IntializeLevelReferee()
        {
            StateMechanic(ActionGameMechanic.TO_START);
        }

        #endregion
    
        #region PublicMethods

        //Transition Matrix from a / various state(s) to another new state
        public virtual void StateMechanic(ActionGameMechanic value)
        {
            switch (value)
            {
                case ActionGameMechanic.TO_START:
                    _gameState = GameStates.START;
                    InitializeStartStateMethod();
                    break;
                case ActionGameMechanic.TO_GAME:
                    if (_gameState == GameStates.START || _gameState == GameStates.PAUSE)
                    {
                        _gameState = GameStates.GAME;
                        InitializeGameStateMethod();
                    }
                    break;
                case ActionGameMechanic.TO_PAUSE:
                    if (_gameState == GameStates.GAME)
                    {
                        _gameState = GameStates.PAUSE;
                        //InitializePauseStateMethod();
                    }
                    break;
                case ActionGameMechanic.TO_VICTORY:
                    if (_gameState == GameStates.GAME)
                    {
                        _gameState = GameStates.VICTORY;
                        //InitializeVictoryStateMethod();
                    }
                    break;
                case ActionGameMechanic.TO_DRAW:
                    if (_gameState == GameStates.GAME)
                    {
                        _gameState = GameStates.DRAW;
                       //InitializeDrawStateMethod();
                    }
                    break;
                case ActionGameMechanic.TO_GAME_OVER:
                    if (_gameState == GameStates.GAME)
                    {
                        _gameState = GameStates.GAME_OVER;
                        //InitializeGameOverStateMethod();
                    }
                    break;
            }
        }

        //any EnemyNPC of the game, will report the sighting of an avatar:
        //A) OnCollisionEnter: Capsule of the Enemy NPC
        //B) OnTriggerEnter: Cone Vision
        public void AvatarSightedEvent(PlayersAvatar value)
        {
            StateMechanic(ActionGameMechanic.TO_GAME_OVER);
            _avatarForGameOver = value;
            //TODO: pending the following events
            //Detener el input del avatar
            //Cambiar el color del avatar para retroalimentar el avistamiento
            //Dejar pasar tres segundos
            //Teletransportar al avatar al punto de inicio
            //Regresar el color del avatar, para indicar que puede seguir jugando
            //Regresar el input al avatar
        }

        #endregion

        #region LevelRefereeStateMethods

        #region StartState

        protected void InitializeStartStateMethod()
        {
            //TODO: fill in the code
            _textMeshPro.text = "Ready, Set, GO!";
        }

        protected void ExecutingStartStateMethod()
        {
            //TODO: fill in the code
        } 

        protected void FinalizeStartStateMethod()
        {
            //TODO: fill in the code
            _textMeshPro.text = "";
        }

        #endregion GameState

        protected void InitializeGameStateMethod()
        {
            //TODO: fill in the code
        }

        protected void ExecutingGameStateMethod()
        {
            //TODO: fill in the code
        } 

        protected void FinalizeGameStateMethod()
        {
            //TODO: fill in the code
        }

        //TODO: Pending game states

        #region 

        #endregion

        #endregion

    }

}
