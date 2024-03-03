using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 10f; // Speed Fruit
    public GameObject Explosion;
    private Rigidbody thisRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // RigidBody
        thisRigidbody = GetComponent<Rigidbody>();

        // get Position
        float position = transform.position.x;

        // Error margin direction
        float errormargin = 0.5f;
        errormargin = position > 0 ? errormargin = -errormargin : errormargin;

        // Direction 
        Vector3 direction = new Vector3(errormargin, speed, 0);

        // Move Fruit
        thisRigidbody.AddForce(direction, ForceMode.Impulse);

        // Rotation
        float rotationspeed = 10f;
        thisRigidbody.AddTorque(Vector3.back * rotationspeed, ForceMode.Impulse);

    }

    void FixedUpdate()
    {
        // Limbo
        if (thisRigidbody.position.y < -2)
        {
            Destroy(this.gameObject);
        }

        // Game is Play
        if (!GameManager.Instance.isPlay)
        {
            // Disable gravity
            thisRigidbody.useGravity = false;

            // Mass
            thisRigidbody.mass = 0.01f;
            thisRigidbody.drag = 5f;
        }
    }

    public void Explode()
    {
        // Rotation
        Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);

        // Particle Explosion
        Instantiate(Explosion, transform.position, rotation);
    }

}
