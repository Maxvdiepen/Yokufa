using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpellData", menuName = "Spell Data", order = 52)]
public class SpellData : ScriptableObject
{
    [SerializeField]
    private string name;

    [SerializeField]
    private int cooldown;

    [SerializeField]
    private float castTime;

    [SerializeField]
    private int range;

    [SerializeField]
    private int damage;

    [SerializeField]
    private string effect;

    public string Name
    {
        get { return name; }
    }

    public int Cooldown
    {
        get { return cooldown; }
    }

    public float CastTime
    {
        get { return castTime; }
    }

    public int Range
    {
        get { return range; }
    }

    public int Damage
    {
        get { return damage; }
    }

    public string Effect
    {
        get { return effect; }
    }
}
