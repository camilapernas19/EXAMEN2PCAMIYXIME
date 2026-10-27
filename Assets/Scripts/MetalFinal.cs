
using UnityEngine;

public class MetaFinal : MonoBehaviour
{
    private Renderer renderizador;
    private Material materialMeta;
    private bool activada = false;

    void Start()
    {
        renderizador = GetComponent<Renderer>();
        materialMeta = renderizador.material;
    }

    void OnTriggerEnter(Collider otro)
    {
        if (!activada && otro.gameObject.name == "Domino5")
        {
            activada = true;

            materialMeta.color = Color.green;

            Debug.Log("¡META COMPLETADA!");
        }
    }
}
