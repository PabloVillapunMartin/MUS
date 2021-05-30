using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 0.5f;
    public float maxSpeed = 5.0f;
    public Transform followTarget;

    Vector3 _vel;
    Rigidbody _rb;
    float rotationX = 0;
    float rotationY = 90;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _vel = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            _vel += followTarget.forward * playerSpeed;
        if (Input.GetKey(KeyCode.S))
            _vel += followTarget.forward * -playerSpeed;
        if (Input.GetKey(KeyCode.D))
            _vel += followTarget.right * playerSpeed;
        if (Input.GetKey(KeyCode.A))
            _vel += followTarget.right * -playerSpeed;

        _vel.y = 0;

        mouseMotion();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_vel);
        _rb.velocity = new Vector3(Mathf.Clamp(_rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(_rb.velocity.y, -maxSpeed, maxSpeed), Mathf.Clamp(_rb.velocity.z, -maxSpeed, maxSpeed));
    }

    private void mouseMotion()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * 90f;
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * 90f;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        rotationY += mouseX;

        followTarget.localEulerAngles = new Vector3(rotationX, rotationY, 0f);
    }
}
