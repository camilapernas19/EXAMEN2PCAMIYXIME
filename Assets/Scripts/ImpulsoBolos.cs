
using UnityEngine;

public class ImpulsoBolos : MonoBehaviour
{
    public float fuerzaExtra = 3f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PelotaAzul"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direccion =
                    collision.GetContact(0).normal * -1f;

                rb.AddForce(direccion * fuerzaExtra,
                    ForceMode.Impulse);
            }
        }
    }
}

