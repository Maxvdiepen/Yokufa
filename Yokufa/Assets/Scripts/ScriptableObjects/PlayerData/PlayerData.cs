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
    private string playerNumber;

    [SerializeField]
    private SpellData spell1;

    [SerializeField]
    private SpellData spell2;

    [SerializeField]
    private SpellData spell3;

    [SerializeField]
    private SpellData spell4;

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

    public SpellData Spell1
    {
        get { return spell1; }
    }

    public SpellData Spell2
    {
        get { return spell2; }
    }

    public SpellData Spell3
    {
        get { return spell3; }
    }

    public SpellData Spell4
    {
        get { return spell4; }
    }
}
