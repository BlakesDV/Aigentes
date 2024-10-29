using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Enums

public enum Stats
{
    NEUTRAL,
    PARALYZED,
    POISONED
}

public enum InventoryElementType
{
    APPLE,
    ARROW,
    GUN,
    KEY
}

#endregion

#region Structs

[System.Serializable]
public struct Inventory
{
    public InventoryElement[] elementsOfTheInventroy;
}

[System.Serializable]
public struct InventoryElement
{
    public InventoryElementType inventoryElementType;
    public int quantity;
}

[System.Serializable]
public struct CharacterProperties
{
    public int currentHealth;
    public string characterName;
    public Stats currentStat;
    public Vector3 positionToSpawn;
}

#endregion

//Interface in which qwe can create as many Scriptable Objects
//as the designers need to implement in the game
[CreateAssetMenu(menuName = "Sciptable Object Test/New SOT")]
public class ScriptableObjectTest : ScriptableObject
{
    [Header("Native variables")]
    //Native variables (int, bool, float, string,... )
    [SerializeField] public int currentHealth = 20;
    [SerializeField] public string characterName;
    [SerializeField] public Stats currentStat;
    //References to assets
    [Header("References to assets")]
    [SerializeField] public Material material;
    [SerializeField] public GameObject prefabOfTheAgent; //Prefab
    //Struct Management
    [Header("Struct Management")]
    [SerializeField] public Inventory inventory;
    [SerializeField] public CharacterProperties characterProperties;
}
