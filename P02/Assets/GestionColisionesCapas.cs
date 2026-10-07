using UnityEngine;

public class GestionColisionesCapas : MonoBehaviour
{
    // Colisión física sólida (Enemigos)
    private void OnCollisionEnter(Collision collision)
    {
        // Comprobamos la capa del objeto
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemigos"))
        {
            Debug.Log($"¡Colisión física con Enemigo!: {collision.gameObject.name}");
        }
    }

    // Detección por Trigger (Recolectables)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Recolectables"))
        {
            Debug.Log($"¡Objeto recolectado!: {other.gameObject.name}");
            
            // Opcional: destruir el recolectable al tocarlo
            Destroy(other.gameObject);
        }
    }
}