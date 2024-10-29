using SotomaYorch.FiniteStateMachine.Agents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SotomaYorch.FiniteStateMachine
{
    public class ControllerInputHandler : MonoBehaviour
    {

        #region RuntimeVariables

        protected PlayerInput _playerInput;
        protected int _playerIndex;

        protected PlayersAvatar[] _allAvatars;
        protected PlayersAvatar _avatar; //playerIndex

        #endregion

        void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            //the player index for the first player is 0 (like the first element of an array)
            _playerIndex = _playerInput.playerIndex;

            //FindObjectsOfType searches all the game objects in the hierachy
            //which have this type of component attached
            _allAvatars = GameObject.FindObjectsOfType<PlayersAvatar>(true);
            foreach (PlayersAvatar avatar in _allAvatars)
            {
                //Cast of a variable from a type to another one
                //(int)avatar.playerIndex
                //PlayerIndexes -> int
                if ((int)avatar.playerIndex == _playerIndex)
                {
                    //therefore, we have the proper avatar to operate
                    //with this controller
                    avatar.gameObject.SetActive(true);
                    _avatar = avatar;
                    transform.parent = avatar.transform;
                    transform.localPosition = Vector3.zero;
                    transform.localRotation = Quaternion.identity;
                    transform.localScale = Vector3.one;
                }
            }
        }

        #region PublicMethods

        public void OnMOVE(InputAction.CallbackContext value)
        {
            if (_avatar != null)
            {
                _avatar.OnMOVE(value);
            }
        }

        #endregion
    }
}