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

    public Material hitMaterial;

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
        Renderer rend = col.transform.GetComponent<Renderer>();
        Material materialOriginal = rend.material;
        rend.material = hitMaterial;
        StartCoroutine(Hit(rend, materialOriginal, col));
    }

    IEnumerator Hit(Renderer renderer, Material og, Collider target)
    {
        //Debug.Log("hit");
        yield return new WaitForSeconds(.2f);
        renderer.material = og;
        //Debug.Log("default");
        Destroy(this.gameObject);
        Destroy(target.gameObject);
        Time.timeScale = 0;
    }
}
