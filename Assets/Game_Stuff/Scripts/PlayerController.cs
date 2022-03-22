using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontal = 0;
    private float vertical = 0;

    private Vector3 vec;
    public float speed = 2;

    public float minX, maxX;
    public float minZ, maxZ;

    public float rotationMagnitude = 5;

    private float  nextFireTime = 0;
    public float waitingDuration = 1;

    public GameObject bullet;
    private uint bulletCounter = 0;

    public Transform bulletStartPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        vec = new Vector3(horizontal, 0, vertical) * speed;

        rb.velocity = vec;

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, minX, maxX), 0, Mathf.Clamp(rb.position.z, minZ, maxZ));

        rb.rotation = Quaternion.Euler(0, 0, -rb.velocity.x * rotationMagnitude);
    }

    private void Update() {
        if(Input.GetButton("Fire1") && Time.time > nextFireTime) {
            nextFireTime = Time.time + waitingDuration;
            bullet.name = "bullet_" + bulletCounter;

            Instantiate(bullet, bulletStartPoint.position, Quaternion.Euler(-transform.eulerAngles));
            bulletCounter++;
        }

        

    }

    
}
