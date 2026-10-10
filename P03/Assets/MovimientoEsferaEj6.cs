using UnityEngine;

public class MovimientoEsferaEj6 : MonoBehaviour
{
    [Header("Referencias de la escena")]
    public Transform cilindroObjetivo;
    public Transform cuboObstaculo;
    public Material materialNuevoCubo;

    [Header("Parámetros")]
    public float velocidad = 3.0f;
    public float distanciaContacto = 1.0f; // Distancia mínima para detectar el contacto

    private Renderer cuboRenderer;
    private bool materialCambiado = false;

    void Start()
    {
        if (cuboObstaculo != null)
        {
            cuboRenderer = cuboObstaculo.GetComponent<Renderer>();
        }
    }

    void Update()
    {
        // 1. Movemos la esfera hacia la posición del cilindro objetivo
        if (cilindroObjetivo != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, 
                cilindroObjetivo.position, 
                velocidad * Time.deltaTime
            );
        }

        // 2. Comprobamos la distancia hasta el cubo obstáculo
        if (!materialCambiado && cuboObstaculo != null)
        {
            float distancia = Vector3.Distance(transform.position, cuboObstaculo.position);

            if (distancia <= distanciaContacto)
            {
                CambiarMaterialCubo();
            }
        }
    }

    private void CambiarMaterialCubo()
    {
        materialCambiado = true;
        if (cuboRenderer != null && materialNuevoCubo != null)
        {
            cuboRenderer.material = materialNuevoCubo;
            Debug.Log("¡La esfera ha alcanzado el cubo obstáculo! Material cambiado exitosamente.");
        }
    }
}