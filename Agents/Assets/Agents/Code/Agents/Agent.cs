using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotomaYorch.FiniteStateMachine.Agents
{
    [RequireComponent(typeof(FiniteStateMachine))]
    public class Agent : MonoBehaviour
    {
        #region References

        protected FiniteStateMachine _fsm;

        #endregion

        #region UnityMethods

        private void Start()
        {
            InitializeAgent();
        }

        #endregion

        #region LocalMethods

        protected virtual void InitializeAgent()
        {
            _fsm = GetComponent<FiniteStateMachine>();
        }

        #endregion

        #region PublicMethods



        #endregion
    }
}