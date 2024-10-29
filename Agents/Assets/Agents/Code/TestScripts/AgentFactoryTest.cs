using System.Collections;
using System.Collections.Generic;
using SotomaYorch.FiniteStateMachine.Agents;
using UnityEngine;

public class AgentFactoryTest : MonoBehaviour
{
    #region Knobs
    //wether we reference the structure of the script
    //we will assign Scriptable Object assets / instances
    [SerializeField] ScriptableObjectTest[] agentsToProduce;

    #endregion

    #region RuntimeVariables

    [SerializeField] protected List<GameObject> _listOfTheAgents;
    GameObject _goAgentInstance;

    #endregion

    void Start()
    {
        //It is suggested that we do not instantiate objects
        //in runtime
        //CreateAgents();
    }

    public void CreateAgents()
    {
        foreach (ScriptableObjectTest agent in agentsToProduce)
        {
            _goAgentInstance = GameObject.Instantiate(agent.prefabOfTheAgent);
            _goAgentInstance.transform.parent = this.transform;
            _goAgentInstance.transform.localPosition = agent.characterProperties.positionToSpawn;
            _goAgentInstance.GetComponent<MeshRenderer>().material = agent.material;

            _listOfTheAgents.Add(_goAgentInstance);
        }
    }

    public void DeleteAgents()
    {
        if ( _listOfTheAgents.Count > 0 )
        {
            for (int i = _listOfTheAgents.Count - 1; i >= 0; i--)
            {
                _goAgentInstance = _listOfTheAgents[i];
                _listOfTheAgents.Remove(_goAgentInstance);
                GameObject.DestroyImmediate(_goAgentInstance);
            }
        }
    }
}
