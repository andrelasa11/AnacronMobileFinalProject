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
    public Transform[] shootOrigins;

    [Header("Dependencies")]
    public new Rigidbody2D rigidbody;
    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private SpecialsController specialsController;
    
    //Private
    private Vector2 _movementInput;
    private bool isFiring;
    private PlayerActions _playerActions;
    private float nextFire;

    private void Awake()
    {
        _playerActions = new PlayerActions();
    }
        
    private void Update()
    {
        isFiring = _playerActions.PlayerControls.Shoot.ReadValue<float>() > 0;

        if (isFiring && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            if (numberOfCannons == 1)
            {
                Instantiate(shootPrefab, shootOrigins[1].position, shootOrigins[1].rotation);
            }

            if (numberOfCannons == 2)
            {
                Instantiate(shootPrefab, shootOrigins[0].position, shootOrigins[0].rotation);
                Instantiate(shootPrefab, shootOrigins[2].position, shootOrigins[2].rotation);
            }

            if (numberOfCannons == 3)
            {
                Instantiate(shootPrefab, shootOrigins[1].position, shootOrigins[1].rotation);
                Instantiate(shootPrefab, shootOrigins[3].position, shootOrigins[3].rotation);
                Instantiate(shootPrefab, shootOrigins[4].position, shootOrigins[4].rotation);
            }

            if (numberOfCannons == 4)
            {
                Instantiate(shootPrefab, shootOrigins[0].position, shootOrigins[0].rotation);
                Instantiate(shootPrefab, shootOrigins[2].position, shootOrigins[2].rotation);
                Instantiate(shootPrefab, shootOrigins[3].position, shootOrigins[3].rotation);
                Instantiate(shootPrefab, shootOrigins[4].position, shootOrigins[4].rotation);
            }

            if (numberOfCannons >= 5)
            {
                Instantiate(shootPrefab, shootOrigins[0].position, shootOrigins[0].rotation);
                Instantiate(shootPrefab, shootOrigins[1].position, shootOrigins[1].rotation);
                Instantiate(shootPrefab, shootOrigins[2].position, shootOrigins[2].rotation);
                Instantiate(shootPrefab, shootOrigins[3].position, shootOrigins[3].rotation);
                Instantiate(shootPrefab, shootOrigins[4].position, shootOrigins[4].rotation);
            }
                       
        }
                
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
}
