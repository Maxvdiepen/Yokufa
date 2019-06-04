using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTestProjectile : MonoBehaviour
{
    private Vector3 projectileSpawnPoint;

    public int projectileSpeed;

    [SerializeField]
    private float maxProjectileDistance = 15;

    private GameObject source;

    private GameObject player;

    private Renderer rend;

    void Awake()
    {
        projectileSpawnPoint = transform.position;
        source = GameObject.Find("Cannon");
        SpeedTestCannon cannonScript = source.GetComponent<SpeedTestCannon>();
        if (cannonScript!= null)
        {
            projectileSpeed = cannonScript.currentSpeed;
            //Debug.Log("Projectile speed is " + projectileSpeed);
        }
    }

    void Update()
    {
        MoveProjectile(projectileSpeed);
    }


    void MoveProjectile(int ProjectileSpeed)
    {
        if (Vector3.Distance(projectileSpawnPoint, transform.position ) > maxProjectileDistance)
        {
            Destroy(this.gameObject);
        }

        else
        {
            transform.Translate(Vector3.forward * ProjectileSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        Destroy(this.gameObject);
        player = GameObject.Find("Player");
        Renderer rend = player.GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.red);
        StartCoroutine(Hit());
    }

    IEnumerator Hit()
    {
        //Debug.Log("Red");
        yield return new WaitForSeconds(.2f);
        rend.material.SetColor("_Color", Color.black);
        Debug.Log("Black");
    }
}
