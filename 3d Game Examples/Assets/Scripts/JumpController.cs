using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{

    public float Speed = 5f;
    public float RotationSpeed = 45f;
    private float _horizontalInput;
    private float _verticalInput;
    public float jumpForce;
    public float gravityModifier;
    public bool IsOnGround = true;
    private Rigidbody _playerRb;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }

        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Speed * _verticalInput * Time.deltaTime);

        transform.Rotate(Vector3.up, RotationSpeed * _horizontalInput * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
    }
}