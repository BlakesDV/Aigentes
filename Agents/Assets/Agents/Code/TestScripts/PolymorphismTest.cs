using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SotomaYorch.FiniteStateMachine.Agents;

public class PolymorphismTest : MonoBehaviour
{
    public enum FruitType
    {
        APPLE = 100,
        BANANNA = 200,
        PEACH = 300
    }

    public Agent[] agents;

    protected float randomValue;
    protected int percentageValue;

    protected FruitType myFruit;
    protected int numberOfThisFruit;
    protected int finalScore;

    // Start is called before the first frame update
    void Start()
    {
        randomValue = UnityEngine.Random.value * 100.0f;
        percentageValue = (int)randomValue;

        myFruit = FruitType.BANANNA;
        numberOfThisFruit = 10;
        finalScore = numberOfThisFruit * (int)myFruit;

        foreach (Agent agent in agents)
        {
            //agent.HeritanceExampleMethod();
            //agent.AvatarTestMethod();
            if (agent as PlayersAvatar)
            {
                PlayersAvatar avatar = 
                    (PlayersAvatar)agent;
                //avatar.AvatarTestMethod();
                //I will treat it as an avatar
            }
            else if (agent as EnemyNPC)
            {
                //I will treat it as an enemy
                EnemyNPC enemy = agent.gameObject.GetComponent<EnemyNPC>();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
