using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBall : MonoBehaviour
{

    public float Speed = 15f;

    private float _horizontalInput;
    private float _verticalInput;

    private Rigidbody _playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
         _playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         _horizontalInput = Input.GetAxis("Horizontal");
         _verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_horizontalInput, 0.0f, _verticalInput);

        _playerRigidbody.AddForce(movement);
    }

}
