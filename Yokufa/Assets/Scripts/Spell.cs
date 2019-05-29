using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private Vector3 spellSpawnPoint;

    [SerializeField]
    private float spellSpeed;

    [SerializeField]
    private float maxSpellDistance = 10;
    
    void Start()
    {
        spellSpawnPoint = transform.position;
    }

    void Update()
    {
        MoveSpell();
       
    }


    void MoveSpell()
    {
        if (Vector3.Distance(spellSpawnPoint, transform.position ) > maxSpellDistance)
        {
            Destroy(this.gameObject);
        }

        else
        {
            transform.Translate(Vector3.forward * spellSpeed * Time.deltaTime);
        }
    }
}
