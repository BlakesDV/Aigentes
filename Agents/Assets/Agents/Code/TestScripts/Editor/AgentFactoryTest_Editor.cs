using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AgentFactoryTest))]
//AgentFactoryTest(_Runtime) VS AgentFactoryTest_Editor
public class AgentFactoryTest_Editor : Editor
{
    AgentFactoryTest script; //reference to the runtime script

    public override void OnInspectorGUI() //Update() of the inspector
    {
        //draws the variables from the original Mono Behaviour Script
        DrawDefaultInspector();

        script = (AgentFactoryTest)target;

        if (GUILayout.Button("Create Agents in the factory :D"))
        {
            script.DeleteAgents();
            script.CreateAgents();
        }
        else if (GUILayout.Button("Delete Agents from the factory :("))
        {
            script.DeleteAgents();
        }
    }


}
