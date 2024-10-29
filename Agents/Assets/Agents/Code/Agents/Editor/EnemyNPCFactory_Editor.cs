using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SotomaYorch.FiniteStateMachine
{
    [CustomEditor(typeof(EnemyNPCFactory))]
    public class EnemyNPCFactory_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EnemyNPCFactory script = (EnemyNPCFactory)target;
            if (GUILayout.Button("Generate Enemy NPCs"))
            {
                script.CreateEnemies();
            }
            if (GUILayout.Button("Eliminate all Enemy NPCs"))
            {
                script.DeleteEnemies();
            }
        }
    }
}