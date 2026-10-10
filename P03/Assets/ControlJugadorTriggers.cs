using UnityEngine;

public class ControlJugadorTriggers : MonoBehaviour
{
    [Header("Configuración de Luz")]
    public Light luzEscena; // Arrastra tu Directional Light desde la Hierarchy (Opcional)

    [Header("Estado del Jugador")]
    public float dano = 0.0f;
    public float velocidadDano = 10.0f; // Daño por segundo dentro de la zona

    private Color colorOriginal;
    private Renderer jugadorRenderer;

    void Start()
    {
        jugadorRenderer = GetComponent<Renderer>();
        if (jugadorRenderer != null)
        {
            colorOriginal = jugadorRenderer.material.color;
        }
    }

    // Evento al ENTRAR en un Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZonaLuz"))
        {
            Debug.Log("Entrando en la Zona de Luz.");
            if (jugadorRenderer != null)
                jugadorRenderer.material.color = Color.cyan;

            if (luzEscena != null)
                luzEscena.color = Color.yellow;
        }
    }

    // Evento al SALIR de un Trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ZonaLuz"))
        {
            Debug.Log("Saliendo de la Zona de Luz.");
            if (jugadorRenderer != null)
                jugadorRenderer.material.color = colorOriginal;

            if (luzEscena != null)
                luzEscena.color = Color.white;
        }
    }

    // Evento mientras se PERMANECE dentro del Trigger
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ZonaDano"))
        {
            dano += velocidadDano * Time.deltaTime;
            Debug.Log($"¡Recibiendo daño! Daño acumulado: {dano:F1}");
        }
    }
}