using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private Vector3 spellSpawnPoint;

    [SerializeField]
    private float spellSpeed;

    [SerializeField]
    private float maxSpellDistance;

    private bool shouldMove = false;

    void Start()
    {
        spellSpawnPoint = transform.position;
    }

    void Update()
    {
        if(shouldMove)
        {
            MoveSpell();
        }
    }

    public void Move()
    {
        shouldMove = true;  
    }

    void MoveSpell()
    {
        if (Vector3.Distance(spellSpawnPoint, transform.position ) > maxSpellDistance)
        {
            SpellPool.Instance.ReturnToPool(this);
            shouldMove = false;
        }

        else
        {
            transform.Translate(Vector3.forward * spellSpeed * Time.deltaTime);
        }
    }
}
