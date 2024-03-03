using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutFruit : MonoBehaviour
{
    public ParticleSystem particle;
    // Get GameManager

    void FixedUpdate()
    {
        GameManager gameManager = GameManager.Instance;
        // Get input Mouse left
        bool mouseLeft = Input.GetMouseButton(0);

        if (!mouseLeft)
        {
            particle.Stop();
            return;
        }

        // Press mouse left
        if (mouseLeft)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            particle.Play();
            // Destry Object colider Raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Colision Fruit
                if (hit.collider.CompareTag("Fruit"))
                {
                    float point = hit.collider.gameObject.GetComponent<Fruit>().value;
                    Destroy(hit.collider.gameObject);
                    gameManager.SetScore((int)point);
                    Debug.Log("======== Score: " + gameManager.score + "=======");
                    hit.collider.gameObject.GetComponent<Fruit>().cutBanana();
                }

                // Colision Bomb
                if (hit.collider.CompareTag("Bomb"))
                {
                    if (gameManager.score > gameManager.recordScore)
                    {
                        PlayerPrefs.SetInt("Score", gameManager.score);
                        PlayerPrefs.Save();
                    }
                    gameManager.EndGame();
                    hit.collider.GetComponent<Bomb>().Explode();
                }
            }
        }
    }
}
