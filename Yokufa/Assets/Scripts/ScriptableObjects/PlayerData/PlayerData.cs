using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "Player Data", order = 51)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int health;

    [SerializeField]
    private int movementSpeed;

    [SerializeField]
    private int projectileSpeed;

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

    public int ProjectileSpeed
    {
        get { return projectileSpeed; } set { projectileSpeed = value; }
    }

    public string PlayerNumber
    {
        get { return playerNumber; }
    }
}
