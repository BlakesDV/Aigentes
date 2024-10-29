using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using SotomaYorch.FiniteStateMachine;

namespace SotomaYorch.FiniteStateMachine
{
    #region Structs

    [System.Serializable]
    public struct RotationParameter
    {
        public float waitTime;

        public Transform rotationDirection;
        public float rotationTime;
    }

    #endregion

    public class FSM_Rotation : FiniteStateMachine
    {
        #region Knobs

        [SerializeField]
        public RotationParameter[] parameter;

        public Transform originPosition;
        public Transform destinyPosition;
        public float interporlationTime; //total time of the interpolation

        #endregion

        #region LocalVariables

        protected int currentParameterIndex;
        protected RotationParameter currentParameter;

        protected float interporlationCronometer; //acumulation of time, in order to interpolate


        private void Update()
        {
            /*
            if (Input.GetKeyDown(KeyCode.B))
            {
                interporlationCronometer = interporlationTime * 0.0f; //0%
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                interporlationCronometer = interporlationTime / 2.0f; // 50%
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                interporlationCronometer = interporlationTime / 1.0f; // 100%
            }
            */

            interporlationCronometer += Time.deltaTime;
            transform.position = Vector3.Lerp(
                    originPosition.transform.position,
                    destinyPosition.transform.position,
                    interporlationCronometer / interporlationTime
                );

            Debug.Log("FSM_Rotation - Update() - Interpolation percentage: " + interporlationCronometer / interporlationTime);
        }
        #endregion

        #region FiniteStateMachineMethods

        protected override void ExecutingIdleState()
        {
            base.ExecutingIdleState();
            currentParameter = parameter[currentParameterIndex];
        }


        protected override void ExecutingRotatingState()
        {
            base.ExecutingRotatingState();
        }

        #endregion
    }
}