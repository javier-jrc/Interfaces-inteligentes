using UnityEngine;

public class ScriptDesplazamiento : MonoBehaviour
{
    // Variable pública para configurar la variación (deltaX, deltaY, deltaZ) en el Inspector
    public Vector3 desplazamiento;

    // Guardamos la posición inicial en la escena
    private Vector3 posicionOriginal;

    void Start()
    {
        // Guardamos la posición original del objeto al arrancar el juego
        posicionOriginal = transform.position;
    }

    void Update()
    {
        // Detectamos si se pulsa la barra espaciadora a través del eje por defecto "Jump"
        if (Input.GetAxis("Jump") > 0)
        {
            // Movemos el objeto sumando el desplazamiento a su posición original
            transform.position = posicionOriginal + desplazamiento;
        }
    }
}