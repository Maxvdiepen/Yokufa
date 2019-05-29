using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField]
    private Transform spellSpawnPoint;

    [SerializeField]
    GameObject spellPrefab;

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
            Instantiate(spellPrefab, spellSpawnPoint.position, spellSpawnPoint.rotation);
            lastTimeShot = Time.time;
        }
    }
}
