using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;

    private float _fallVelocity = 0;
    private CharacterController _charecterController;

    // Start is called before the first frame update
    void Start()
    {
        _charecterController = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _charecterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);     
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _charecterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }
}
