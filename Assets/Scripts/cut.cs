using UnityEngine;

public class cut : MonoBehaviour
{
    void Update()
    {
        Vector3 posicaoMouse = Input.mousePosition;
        posicaoMouse.z = 10; // Distância da câmera ao plano XY

        Vector3 posicaoAlvo = Camera.main.ScreenToWorldPoint(posicaoMouse);
        posicaoAlvo.z = 0;

        transform.position = Vector3.Lerp(transform.position, posicaoAlvo, 20f * Time.deltaTime);
    }
}
