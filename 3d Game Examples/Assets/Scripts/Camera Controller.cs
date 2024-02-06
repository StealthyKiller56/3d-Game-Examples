using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

public GameObject objectToFollow;

private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position + objectToFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectToFollow.transform.position + _offset;
    }
}
