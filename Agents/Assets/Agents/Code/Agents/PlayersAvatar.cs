using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SotomaYorch.FiniteStateMachine.Agents
{
    #region Enums

    public enum PlayerIndexes
    {
        ONE = 0,
        TWO = 1,
        THREE = 2,
        FOUR = 3
    }

    #endregion

    public class PlayersAvatar : Agent
    {
        #region Knobs

        public PlayerIndexes playerIndex;
        public float movementSpeed = 2.0f;

        #endregion

        #region RuntimeVariables

        protected Vector3 _movementInput;

        #endregion

        #region UnityMethods

        private void Start()
        {
            InitializeAgent();
        }

        private void FixedUpdate()
        {
            
        }

        #endregion

        #region LocalMethods

        protected override void InitializeAgent()
        {
            base.InitializeAgent();
            //TODO: Configuration of the elements of the avatar
            _movementInput = Vector3.zero;
            _fsm.SetSpeedMovement = movementSpeed;
        }

        #endregion

        #region PublicMethods()

        public void OnMOVE(InputAction.CallbackContext value)
        {
            //Input.OnKeyButton(KeyCode.A)
            if (value.performed)
            {
                //WASD, left Thumbstick
                _fsm.StateMechanic(Actions.WALK);
                _movementInput = new Vector3(
                    value.ReadValue<Vector2>().x,
                    0.0f,
                    value.ReadValue<Vector2>().y
                    );
                _fsm.SetMovementInput = _movementInput;
                transform.forward = _movementInput;
            }
            //Input.OnKeyButtonUp(KeyCode.A)
            else if (value.canceled)
            {
                _fsm.StateMechanic(Actions.STOP);
                _movementInput = Vector3.zero;
                _fsm.SetMovementInput = _movementInput;
            }
        }

        #endregion
    }
}