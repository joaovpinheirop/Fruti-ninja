using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitCut : MonoBehaviour
{
    public Rigidbody thisRigidbody;
    public GameManager gameManager = GameManager.Instance;

    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        // Limbo
        if (thisRigidbody.position.y < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
