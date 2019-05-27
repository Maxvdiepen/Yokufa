using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField]
    private Transform spellSpawnPoint;
    
    [SerializeField]
    private float cooldown;

    public static PlayerHand Instance;

    private float lastTimeShot = 0;

    void Awake()
    {
        Instance = GetComponent<PlayerHand>();
    }

    public void Shoot()
    {
        if(lastTimeShot + cooldown <= Time.time)
        {
            Spell _spell = SpellPool.Instance.Instantiate(spellSpawnPoint.position, spellSpawnPoint.rotation);
            _spell.Move();
            lastTimeShot = Time.time;
        }
    }
}
