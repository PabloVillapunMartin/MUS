using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 0.5f;
    public float maxSpeed = 5.0f;

    Vector3 _vel;
    Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _vel = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            _vel += transform.forward * playerSpeed;
        if (Input.GetKey(KeyCode.S))
            _vel += transform.forward * -playerSpeed;
        if (Input.GetKey(KeyCode.D))
            _vel += transform.right * playerSpeed;
        if (Input.GetKey(KeyCode.A))
            _vel += transform.right * -playerSpeed;
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_vel);
        _rb.velocity = new Vector3(Mathf.Clamp(_rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(_rb.velocity.y, -maxSpeed, maxSpeed), Mathf.Clamp(_rb.velocity.z, -maxSpeed, maxSpeed));
    }
}
