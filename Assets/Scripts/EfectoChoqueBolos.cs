
using UnityEngine;

public class EfectoChoqueBolos : MonoBehaviour
{
    public ParticleSystem estrellas;
    public AudioSource sonidoStrike;

    private bool yaChoco = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (yaChoco) return;

        if (collision.gameObject.CompareTag("PelotaAzul"))
        {
            yaChoco = true;

            if (estrellas != null)
            {
                estrellas.transform.position =
                    collision.GetContact(0).point;

                estrellas.Clear();
                estrellas.Emit(30);
            }

            if (sonidoStrike != null)
            {
                sonidoStrike.Play();
            }
        }
    }
}
