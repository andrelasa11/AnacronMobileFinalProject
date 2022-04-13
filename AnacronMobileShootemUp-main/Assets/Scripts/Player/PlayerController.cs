using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    [Header("Configuration")]
    public float speed;
    public float fireRate;

    [Header("Dependencies")]
    public new Rigidbody2D rigidbody;
    [SerializeField] List<Shooter> shooters;
    

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
            foreach (var shooter in shooters)
            {
                shooter.DoShoot();
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

    private void OnEnable()
    {
        _playerActions.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Disable();
    }
}
