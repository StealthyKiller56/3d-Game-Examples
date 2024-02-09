using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBall : MonoBehaviour
{

    public float Speed = 15f;
    private float _horizontalInput;
    private float _verticalInput;
    private Rigidbody _playerRigidbody;
    private Vector3 _startingPosition;
    private Vector3 _checkpointPosition;
    private bool _isAtCheckpoint = false;
    public int score = 0;

    public float jumpForce;
    public float gravityModifier;
    public bool IsOnGround = true;
    public float OutOfBounds = -10f;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

          if (Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }

         _horizontalInput = Input.GetAxis("Horizontal");
         _verticalInput = Input.GetAxis("Vertical");

        if (transform.position.y < OutOfBounds)
        {
            if(_isAtCheckpoint)
            {
               transform.position = _checkpointPosition;
            }
            else
            transform.position = _startingPosition;
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_horizontalInput, 0.0f, _verticalInput);

        _playerRigidbody.AddForce(movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            _isAtCheckpoint = true;
            _checkpointPosition = other.gameObject.transform.position;
        }
        if (other.gameObject.CompareTag("End Point"))
        {
             transform.position = _startingPosition;
        }
    }
}
