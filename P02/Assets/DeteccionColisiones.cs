using UnityEngine;

public class DeteccionColisiones : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 1. Imprimimos por consola el nombre del objeto con el que hemos colisionado
        Debug.Log($"Colisión detectada con el objeto: {collision.gameObject.name}");

        // 2. Intentamos obtener el componente Renderer del objeto colisionado
        Renderer rendererObjeto = collision.gameObject.GetComponent<Renderer>();

        if (rendererObjeto != null)
        {
            // 3. Cambiamos su color a un color aleatorio al colisionar
            rendererObjeto.material.color = Random.ColorHSV();
        }
    }
}