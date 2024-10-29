using System.Collections;
using System.Collections.Generic;
using SotomaYorch.AvoidDetection;
using SotomaYorch.FiniteStateMachine.Agents;
using UnityEngine;

namespace SotomaYorch.FiniteStateMachine
{
    public class EnemyNPCFactory : MonoBehaviour
    {
        #region Knobs

        [SerializeField] public EnemyInteractiveScript_ScriptableObject[] enemiesToProduce;
        [SerializeField] public LevelReferee levelReferee;

        #endregion

        #region RuntimeVariables

        [SerializeField] protected List<GameObject> _listOfTheEnemies;
        protected GameObject _goEnemyInstance;
        protected int _numberOfSlices;
        protected float _currentAngle;
        protected GameObject _goConeSlice;
        protected Vector3 _v3ConeScale;

        #endregion

        #region RuntimeMethods

        public void CreateEnemies()
        {
            foreach (EnemyInteractiveScript_ScriptableObject enemy in enemiesToProduce)
            {
                //Create the enemy with the prefab and spawn parameters
                _goEnemyInstance = GameObject.Instantiate(enemy.prefabOfTheEnemy);
                _goEnemyInstance.transform.parent = this.transform;
                _goEnemyInstance.transform.localPosition = enemy.positionToSpawn;
                _goEnemyInstance.transform.localRotation = Quaternion.Euler(enemy.rotationToSpawn);
                _goEnemyInstance.GetComponent<EnemyNPC>().soPatrolScript = enemy;
                _goEnemyInstance.GetComponent<EnemyNPC>().SetLevelReferee = levelReferee;

                //Create the Vision Cone
                //A) Create the fan of multiple Vision Cones
                _numberOfSlices = enemy.coneVisionAngle / 10;
                _currentAngle = - (_numberOfSlices * 10 / 2);
                for (int i = 0; i < _numberOfSlices; i++)
                {
                    _goConeSlice = GameObject.Instantiate(enemy.prefabOfASliceOfTheCone);
                    _goConeSlice.transform.parent = _goEnemyInstance.transform.GetChild(1); //Pivot for slice cones
                    _goConeSlice.transform.localPosition = Vector3.zero;
                    _goConeSlice.transform.localRotation = Quaternion.Euler(Vector3.up * _currentAngle);
                    _v3ConeScale = new Vector3(
                        enemy.coneVisionDistance,
                        1.0f,
                        enemy.coneVisionDistance
                        );
                    _goConeSlice.transform.localScale = _v3ConeScale;
                    _currentAngle += 10.0f;

                    //Interface / conecction between the slice and the enemyNPC
                    _goConeSlice.GetComponent<SliceTriggerDetection>().SetEnemyNPCReference = 
                        _goEnemyInstance.GetComponent<EnemyNPC>();
                }

                //Add the enemy to the list instances
                _listOfTheEnemies.Add(_goEnemyInstance);
            }
        }

        public void DeleteEnemies()
        {
            if (_listOfTheEnemies.Count > 0)
            {
                for (int i = _listOfTheEnemies.Count - 1; i >= 0; i--)
                {
                    _goEnemyInstance = _listOfTheEnemies[i];
                    _listOfTheEnemies.Remove(_goEnemyInstance);
                    GameObject.DestroyImmediate(_goEnemyInstance);
                }
            }
        }

        #endregion
    }
}