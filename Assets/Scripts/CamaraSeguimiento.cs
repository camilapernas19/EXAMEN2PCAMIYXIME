
using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    public Transform objetivo;

    public Vector3 distancia = new Vector3(0, 5, -12);

    public float suavidad = 3f;

    void LateUpdate()
    {
        if (objetivo != null)
        {
            Vector3 posicionDeseada = objetivo.position + distancia;

            transform.position = Vector3.Lerp(
                transform.position,
                posicionDeseada,
                suavidad * Time.deltaTime
            );

            transform.LookAt(objetivo.position);
        }
    }
}
