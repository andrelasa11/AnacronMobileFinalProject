using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    [Header("Configuration")]
    public float speed;

    [Header("Dependencies")]
    public new Rigidbody2D rigidbody;
    [SerializeField] List<Shooter> shooters;
    

    //Private
    private Vector2 _movementInput;

    private void FixedUpdate()
    {
        rigidbody.velocity = _movementInput * speed;
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        _movementInput = value.ReadValue<Vector2>();
    }

    public void Shooting()
    {
        foreach (var shooter in shooters)
        {
            shooter.DoShoot();
        }        
    }


}
