
using UnityEngine;

public class CamaraCinematica : MonoBehaviour
{
    public Transform pelotaAmarilla;
    public Transform[] dominos;
    public Transform pelotaAzul;
    public Transform bolos;

    public float tiempoPelotaAmarilla = 2f;
    public float tiempoPorDomino = 0.6f;
    public float tiempoPelotaAzul = 2f;

    public float distancia = 12f;
    public float altura = 7f;
    public float suavidad = 5f;

    private float tiempo;

    void LateUpdate()
    {
        tiempo += Time.deltaTime;

        Transform objetivo = pelotaAmarilla;

        float inicioDominos = tiempoPelotaAmarilla;
        float finDominos =
            inicioDominos + dominos.Length * tiempoPorDomino;

        if (tiempo >= inicioDominos &&
            tiempo < finDominos &&
            dominos.Length > 0)
        {
            int indice = Mathf.FloorToInt(
                (tiempo - inicioDominos) / tiempoPorDomino
            );

            indice = Mathf.Clamp(
                indice, 0, dominos.Length - 1
            );

            objetivo = dominos[indice];
        }
        else if (tiempo >= finDominos &&
                 tiempo < finDominos + tiempoPelotaAzul)
        {
            objetivo = pelotaAzul;
        }
        else if (tiempo >= finDominos + tiempoPelotaAzul)
        {
            objetivo = bolos;
        }

        if (objetivo == null) return;

        Vector3 posicionDeseada =
            objetivo.position +
            new Vector3(0, altura, -distancia);

        transform.position = Vector3.Lerp(
            transform.position,
            posicionDeseada,
            Time.deltaTime * suavidad
        );

        Vector3 direccion =
            objetivo.position - transform.position;

        if (direccion.sqrMagnitude > 0.001f)
        {
            Quaternion rotacion =
                Quaternion.LookRotation(direccion);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rotacion,
                Time.deltaTime * suavidad
            );
        }
    }
}

