using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPool : MonoBehaviour
{
    [SerializeField]
    private float poolSize;

    [SerializeField]
    private GameObject spellPrefab;

    private List<Spell> spellsInPool;

    public static SpellPool Instance;

    private void Awake()
    {
        Instance = GetComponent<SpellPool>();
    }

    void Start()
    {
        InitializePool();
    }

    public Spell Instantiate(Vector3 position, Quaternion rotation)
    {
        Spell _spell = spellsInPool[0];
        _spell.transform.position = position;
        _spell.transform.rotation = rotation;
        spellsInPool.Remove(_spell);
        return _spell;
    }

    public void ReturnToPool(Spell _spell)
    {
        _spell.transform.position = transform.position;
        spellsInPool.Add(_spell);
    }

    void InitializePool()
    {
        spellsInPool = new List<Spell>();
        for(int i = 0; i < poolSize; i++)
        {
            GameObject _spell = Instantiate(spellPrefab, transform.position, transform.rotation);
            spellsInPool.Add(_spell.GetComponent<Spell>());
        }
    }
}
