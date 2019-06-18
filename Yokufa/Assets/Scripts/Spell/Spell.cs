using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private Vector3 spellSpawnPoint;

    [SerializeField]
    public float spellSpeed;

    [SerializeField]
    private float maxSpellDistance = 20;

    [SerializeField]
    private int damage = 10;

    public Material hitMaterial;

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
            //Debug.Log("Max distance: " + maxSpellDistance + " spawnpoint: " + spellSpawnPoint + " position: " + transform.position);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        Renderer rend = col.transform.GetComponent<Renderer>();
        Material materialOriginal = rend.material;
        rend.material = hitMaterial;
        StartCoroutine(Hit(rend, materialOriginal, col));
        PlayerController target = col.transform.GetComponent<PlayerController>();
        target.health -= damage;
        Debug.Log(target.health);
    }

    IEnumerator Hit(Renderer renderer, Material og, Collider target)
    {
        //Debug.Log("hit");
        yield return new WaitForSeconds(.2f);
        renderer.material = og;
        //Debug.Log("default");
        Destroy(this.gameObject);
    }
}
