using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private string playerNumber;

    [SerializeField]
    private Transform spellSpawnPoint;

    [SerializeField]
    GameObject spellPrefab;

    [SerializeField]
    private float cooldown;

    private int projectileSpeed;

    private int timesShot;

    private void Start()
    {
        projectileSpeed = 19;
    }

    void Update()
    {
        HandleMovementInput();
        HandleRotationInput();
        HandleSpellInput();
    }

    void UpCounter()
    {
        if(projectileSpeed > 31)
        {
            Time.timeScale = 0;
        }
        projectileSpeed ++;
    }

    void HandleMovementInput ()
    {
        float _horizontal = Input.GetAxis("Horizontal_P" + playerNumber);
        float _vertical = Input.GetAxis("Vertical_P" + playerNumber);

        //Debug.Log(_horizontal + " " + _vertical);
        Vector3 _movement = new Vector3(_horizontal, 0, _vertical);
        transform.Translate(_movement * movementSpeed * Time.deltaTime, Space.World);
    }

    void HandleRotationInput ()
    {
        //Mouse control

        //RaycastHit _hit;
        //Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(_ray, out _hit))
        //{
        //    transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        //}

        //Joystick control
        float _aimHorizontal = Input.GetAxis("AimHorizontal_P" + playerNumber);
        float _aimVertical = Input.GetAxis("AimVertical_P" + playerNumber);

        if (_aimHorizontal > 0.1f || _aimHorizontal < -0.1f || _aimVertical > 0.1f || _aimVertical < -0.1f)
        {
            float heading = Mathf.Atan2(_aimHorizontal, _aimVertical);
            transform.rotation = Quaternion.Euler(0f, heading * Mathf.Rad2Deg, 0f);
        }
    }

    void HandleSpellInput ()
    {
        if (Input.GetButton("Fire1_P" + playerNumber))
        {
            Shoot();
            timesShot++;
            if(timesShot % 4 == 0)
            {
                UpCounter();
            }
            //Debug.Log("Shoot");
        }
    }




    private float lastTimeShot = 0;

    public void Shoot()
    {
        if (lastTimeShot + cooldown <= Time.time)
        {
            Instantiate(spellPrefab, spellSpawnPoint.position, spellSpawnPoint.rotation);
            lastTimeShot = Time.time;
        }
    }
}
