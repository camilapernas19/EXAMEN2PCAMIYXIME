
using UnityEngine;

public class InicioMusica : MonoBehaviour
{
    public AudioSource musica;
    public float segundoInicio = 65f;

    void Start()
    {
        if (musica != null && musica.clip != null)
        {
            musica.time = Mathf.Clamp(
                segundoInicio,
                0f,
                musica.clip.length - 0.01f
            );

            musica.Play();
        }
    }
}
