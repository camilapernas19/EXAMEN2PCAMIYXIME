
using UnityEngine;

public class ParticulasColision : MonoBehaviour
{
    public ParticleSystem particulas;
    private bool yaChoco = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!yaChoco && collision.gameObject.name == "EsferaPrincipal")
        {
            yaChoco = true;

            if (particulas != null)
            {
                particulas.transform.position = collision.GetContact(0).point;
                particulas.Play();
            }
        }
    }
}
