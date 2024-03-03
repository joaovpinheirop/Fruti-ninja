using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour
{
    public float speed = 10f; // Speed Fruit
    private Rigidbody thisRigidbody;
    public float value = 0;
    private GameManager gameManager = GameManager.Instance;
    public GameObject Banana;

    // Start is called before the first frame update
    void Start()
    {
        float position = transform.position.x;

        // RigidBody
        thisRigidbody = GetComponent<Rigidbody>();

        // Direction 
        float errormargin = 0.5f;
        if (position > 0)
        {
            errormargin = -errormargin;
        }
        Vector3 direction = new Vector3(errormargin, speed, 0);

        // Move Fruit
        thisRigidbody.AddForce(direction, ForceMode.Impulse);
        float rotationspeed = 4f;
        thisRigidbody.AddTorque(Vector3.right * rotationspeed, ForceMode.Impulse);
    }
    void Update()
    {

        if (gameManager.life == 0)
        {
            SceneManager.LoadScene(gameManager.nameScene);
        }
    }

    void FixedUpdate()
    {
        // Limbo
        if (thisRigidbody.position.y < 0)
        {
            Destroy(this.gameObject);
            gameManager.life--;
            Debug.Log("Life: " + gameManager.life);
        }

        if (!GameManager.Instance.isPlay)
        {
            thisRigidbody.useGravity = false;
            thisRigidbody.mass = 0.01f;
            thisRigidbody.drag = 5f;
        }
    }

    public void cutBanana()
    {
        Instantiate(Banana, transform.position, transform.rotation);
    }
}
