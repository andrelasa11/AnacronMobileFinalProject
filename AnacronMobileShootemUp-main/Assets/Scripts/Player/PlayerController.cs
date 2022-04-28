using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    [Header("Configuration")]
    public float speed;
    public float fireRate;
    public int numberOfCannons;
    public int maxLaserPoints;
    public Transform[] shootOrigins;

    [Header("Dependencies")]
    public new Rigidbody2D rigidbody;
    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private GameObject laserShootPrefab;
    [SerializeField] private SpecialsController specialsController;
    [SerializeField] private GameManagerConfig gmConfig;
    
    //Private
    private Vector2 _movementInput;
    private bool isFiring = true;
    private PlayerActions _playerActions;
    private int currentLaserPoints;
    private float nextLaserFire;
    
    private void Awake()
    {
        _playerActions = new PlayerActions();
    }

    private void Start()
    {
        fireRate = gmConfig.fireRate;
        numberOfCannons = gmConfig.numberOfCannons;
        speed = gmConfig.speed;
        maxLaserPoints = gmConfig.maxLaserPoints;

        currentLaserPoints = maxLaserPoints;

        StartCoroutine(ShootForever());
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = _movementInput * speed;
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        _movementInput = value.ReadValue<Vector2>();
    }

    public void OnPlayerDie()
    {
        GameController.Instance.OnPlayerDie();
    }

    public void UnlockSpecial(PickupConfig pickupConfig)
    {
        Debug.LogFormat("UnlockSpecial pickup type {0}", pickupConfig.type);
        specialsController.UnlockSpecial(pickupConfig);
    }

    private void OnEnable()
    {
        _playerActions.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Disable();
    }

    public void LaserShoot()
    {
        if(currentLaserPoints > 0 && Time.time > nextLaserFire)
        {
            nextLaserFire = Time.time + fireRate;
            Instantiate(laserShootPrefab, shootOrigins[1].position, shootOrigins[1].rotation);
            currentLaserPoints--;
        }
    }

    public void DisableOrEnableIsFiring()
    {
        if(isFiring)
        {
            isFiring = false;
            StopAllCoroutines();
        }else
        {
            isFiring = true;
            StartCoroutine(ShootForever());
        }
    }

    private IEnumerator ShootForever()
    {
        while (isFiring)
        {
            if (numberOfCannons == 1)
            {
                yield return new WaitForSeconds(fireRate);
                Instantiate(shootPrefab, shootOrigins[1].position, shootOrigins[1].rotation);                
            }

            if (numberOfCannons == 2)
            {
                yield return new WaitForSeconds(fireRate);
                Instantiate(shootPrefab, shootOrigins[0].position, shootOrigins[0].rotation);
                Instantiate(shootPrefab, shootOrigins[2].position, shootOrigins[2].rotation);                
            }

            if (numberOfCannons == 3)
            {
                yield return new WaitForSeconds(fireRate);
                Instantiate(shootPrefab, shootOrigins[1].position, shootOrigins[1].rotation);
                Instantiate(shootPrefab, shootOrigins[3].position, shootOrigins[3].rotation);
                Instantiate(shootPrefab, shootOrigins[4].position, shootOrigins[4].rotation);
            }

            if (numberOfCannons == 4)
            {
                yield return new WaitForSeconds(fireRate);
                Instantiate(shootPrefab, shootOrigins[0].position, shootOrigins[0].rotation);
                Instantiate(shootPrefab, shootOrigins[2].position, shootOrigins[2].rotation);
                Instantiate(shootPrefab, shootOrigins[3].position, shootOrigins[3].rotation);
                Instantiate(shootPrefab, shootOrigins[4].position, shootOrigins[4].rotation);
            }

            if (numberOfCannons >= 5)
            {
                yield return new WaitForSeconds(fireRate);
                Instantiate(shootPrefab, shootOrigins[0].position, shootOrigins[0].rotation);
                Instantiate(shootPrefab, shootOrigins[1].position, shootOrigins[1].rotation);
                Instantiate(shootPrefab, shootOrigins[2].position, shootOrigins[2].rotation);
                Instantiate(shootPrefab, shootOrigins[3].position, shootOrigins[3].rotation);
                Instantiate(shootPrefab, shootOrigins[4].position, shootOrigins[4].rotation);
            }
        }
    }


}
