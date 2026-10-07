using UnityEngine;

public class MovimientoPersonajeRB : MonoBehaviour
{
    public float velocidad = 5.0f;
    
    private Rigidbody rb;
    private Vector3 inputMovimiento;

    void Start()
    {
        // Obtenemos la referencia al componente Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Capturamos las entradas del teclado (WASD / Flechas) en Update
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Normalizamos el vector para evitar que se mueva más rápido en diagonal
        inputMovimiento = new Vector3(h, 0.0f, v).normalized;
    }

    void FixedUpdate()
    {
        // Todo movimiento por físicas debe ejecutarse dentro de FixedUpdate
        MoverPersonaje();
    }

    private void MoverPersonaje()
    {
        // Calculamos el desplazamiento según la velocidad y Time.fixedDeltaTime
        Vector3 desplazamiento = inputMovimiento * velocidad * Time.fixedDeltaTime;

        // MovePosition traslada el Rigidbody de forma fluida respetando las colisiones
        rb.MovePosition(rb.position + desplazamiento);
    }
}