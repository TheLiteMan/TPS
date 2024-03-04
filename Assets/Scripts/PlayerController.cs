using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    private float _fallVelocity = 0;
    private CharacterController _charecterController;
    private Vector3 _moveVector;

    // Start is called before the first frame update
    void Start()
    {
        _charecterController = GetComponent<CharacterController>();   
    }

    void Update()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _charecterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _charecterController.Move(_moveVector * Time.fixedDeltaTime * speed);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _charecterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        
        if (_charecterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }

}
