using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    public int health;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    public string playerNumber;

    [SerializeField]
    private Transform spellSpawnPoint;

    [SerializeField]
    GameObject spellPrefab;

    [SerializeField]
    private float cooldown;

    private int projectileSpeed;

    private int timesShot;


    //for test purposes
    private int ammo;
     
    public Text counter;

    public Text reloaded;

    private void Start()
    {
        playerData.ProjectileSpeed = 19;
        ammo = 4;
        counter.text = "Ammo: 4  Speed: " + playerData.ProjectileSpeed;
        reloaded.color = Color.green;
        reloaded.text = "Reloaded";
    }

    void Update()
    {
        HandleMovementInput();
        HandleRotationInput();
        HandleSpellInput();
        HandleUI();
    }

    void HandleUI ()
    {
        counter.text = "Ammo: " + ammo + "  Speed: " + playerData.ProjectileSpeed;
        if (lastTimeShot + cooldown <= Time.time)
        {
            reloaded.color = Color.green;
            reloaded.text = "Reloaded";
        }
    }

    void UpCounter()
    {
        if(playerData.ProjectileSpeed > 31)
        {
            Time.timeScale = 0;
        }
        playerData.ProjectileSpeed ++;
        ammo = 4;
        //Debug.Log(playerData.ProjectileSpeed);
    }

    void HandleMovementInput ()
    {
        float _horizontal = Input.GetAxis("Horizontal_P" + playerNumber);
        float _vertical = Input.GetAxis("Vertical_P" + playerNumber);

        if (_horizontal > 0.1f || _horizontal < -0.1f || _vertical > 0.1f || _vertical < -0.1f)
        {
            //Debug.Log("Player" + playerNumber + " " + _horizontal + " " + _vertical);
            Vector3 _movement = new Vector3(_horizontal, 0, _vertical);
            transform.Translate(_movement * movementSpeed * Time.deltaTime, Space.World);
        }
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
            //Debug.Log("Shoot");
        }
    }




    private float lastTimeShot = 0;

    public void Shoot()
    {
        if (lastTimeShot + cooldown <= Time.time)
        {
            GameObject spellToBeFired = GameObject.Instantiate(spellPrefab, spellSpawnPoint.position, spellSpawnPoint.rotation);
            spellToBeFired.GetComponent<Spell>().spellSpeed = playerData.ProjectileSpeed;
            lastTimeShot = Time.time;
            timesShot++;
            ammo--;
            reloaded.color = Color.red;
            reloaded.text = "Reloading";
            if (timesShot % 4 == 0)
            {
                UpCounter();
            }
        }
    }
}
