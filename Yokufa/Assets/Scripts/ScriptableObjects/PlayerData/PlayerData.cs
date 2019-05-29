using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SwordData", menuName = "Sword Data", order = 51)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int health;

    [SerializeField]
    private int movementSpeed;

    [SerializeField]
    private string playerNumber;

    public int Health
    {
        get { return health; }
    }

    public int MovementSpeed
    {
        get { return movementSpeed; }
    }

    public string PlayerNumber
    {
        get { return playerNumber; }
    }
}
