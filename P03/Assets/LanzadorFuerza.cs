using UnityEngine;

public class LanzadorFuerza : MonoBehaviour
{
    [Header("Configuración de Fuerza")]
    public Vector3 fuerzaLanzamiento = new Vector3(0.0f, 0.5f, 15.0f);
    public ForceMode modoFuerza = ForceMode.Impulse;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Al pulsar la tecla X disparamos el impulso
        if (Input.GetKeyDown(KeyCode.X))
        {
            LanzarObjeto();
        }
    }

    private void LanzarObjeto()
    {
        if (rb != null)
        {
            rb.AddForce(fuerzaLanzamiento, modoFuerza);
        }
    }
}