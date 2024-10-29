using System.Collections;
using System.Collections.Generic;
using SotomaYorch.FiniteStateMachine.Agents;
using UnityEngine;

namespace SotomaYorch.FiniteStateMachine
{
    public class SliceTriggerDetection : MonoBehaviour
    {
        #region References

        [SerializeField] protected EnemyNPC enemyNPC;

        #endregion

        #region UnityEvents

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                //Sighted an avatar
                //TODO: Check with a raycast a clear line of sight to the avatar
                if (true)
                {
                    enemyNPC.AvatarSightedEvent(other.gameObject.GetComponent<PlayersAvatar>());
                }
            }
        }

        #endregion

        #region GettersAndSetters

        public EnemyNPC SetEnemyNPCReference
        {
            set { enemyNPC = value; }
        }

        #endregion
    }
}