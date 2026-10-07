using UnityEngine;

public class ScriptCubo2 : MonoBehaviour
{
    // Ejercicio 6
    public float velocidadLogs = 5.0f;

    // Ejercicio 8
    public Vector3 moveDirection = new Vector3(1.0f, 0.0f, 0.0f);
    public float speedEx8 = 2.0f;
    public Space espacioMovimiento = Space.Self;

    // Ejercicios 9 al 13
    public float speed = 5.0f;
    public float rotationSpeed = 5.0f; // Ejercicio 13: Velocidad de giro suave

    // Referencia a la Esfera (Ejercicios 11, 12 y 13)
    private Transform esferaTransform;

    void Start()
    {
        // Buscamos la esfera por su etiqueta
        GameObject esferaObj = GameObject.FindWithTag("Sphere");
        if (esferaObj != null)
        {
            esferaTransform = esferaObj.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró ningún GameObject con la etiqueta 'Sphere'.");
        }
    }

    void Update()
    {
        // Ejercicio 6
        ProcesarTeclasDireccion();

        // Ejercicio 7
        ComprobarDisparo();

        // Ejercicio 12 (Comentado para usar el 13)
        // MoverCuboEjercicio12();

        // Ejercicio 13: Giro suave hacia la esfera y avance continuo
        MoverCuboEjercicio13();
    }

    // --- MÉTODOS DE EJERCICIOS ANTERIORES ---

    private void ProcesarTeclasDireccion()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float resultado = velocidadLogs * v * h;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            Debug.Log($"Flecha Arriba | Resultado: {resultado}");
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            Debug.Log($"Flecha Abajo | Resultado: {resultado}");
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            Debug.Log($"Flecha Izquierda | Resultado: {resultado}");
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            Debug.Log($"Flecha Derecha | Resultado: {resultado}");
    }

    private void ComprobarDisparo()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparo();
        }
    }

    private void Disparo()
    {
        Debug.Log("¡Disparo! Se ha pulsado la tecla H mapeada a Fire1.");
    }

    private void MoverCuboEjercicio8()
    {
        transform.Translate(moveDirection * speedEx8 * Time.deltaTime, espacioMovimiento);
    }

    private void MoverCuboEjercicio9()
    {
        float deltaX = 0.0f;
        float deltaZ = 0.0f;

        if (Input.GetKey(KeyCode.UpArrow))    deltaZ += 1.0f;
        if (Input.GetKey(KeyCode.DownArrow))  deltaZ -= 1.0f;
        if (Input.GetKey(KeyCode.RightArrow)) deltaX += 1.0f;
        if (Input.GetKey(KeyCode.LeftArrow))  deltaX -= 1.0f;

        Vector3 direccion = new Vector3(deltaX, 0.0f, deltaZ);
        transform.Translate(direccion * speed);
    }

    private void MoverCuboEjercicio10()
    {
        float deltaX = 0.0f;
        float deltaZ = 0.0f;

        if (Input.GetKey(KeyCode.UpArrow))    deltaZ += 1.0f;
        if (Input.GetKey(KeyCode.DownArrow))  deltaZ -= 1.0f;
        if (Input.GetKey(KeyCode.RightArrow)) deltaX += 1.0f;
        if (Input.GetKey(KeyCode.LeftArrow))  deltaX -= 1.0f;

        Vector3 direccion = new Vector3(deltaX, 0.0f, deltaZ);
        transform.Translate(direccion * speed * Time.deltaTime);
    }

    private void MoverCuboEjercicio11()
    {
        if (esferaTransform == null) return;

        Vector3 direccion = esferaTransform.position - transform.position;
        direccion.y = 0.0f;

        transform.Translate(direccion.normalized * speed * Time.deltaTime, Space.World);
    }

    private void MoverCuboEjercicio12()
    {
        if (esferaTransform == null) return;

        Vector3 objetivoMismaAltura = new Vector3(esferaTransform.position.x, transform.position.y, esferaTransform.position.z);
        transform.LookAt(objetivoMismaAltura);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Ejercicio 13: Giro progresivo (Slerp) y persecución fluida
    private void MoverCuboEjercicio13()
    {
        if (esferaTransform == null) return;

        // 1. Calculamos la dirección del objetivo en el plano horizontal
        Vector3 direccion = esferaTransform.position - transform.position;
        direccion.y = 0.0f;

        if (direccion != Vector3.zero)
        {
            // 2. Calculamos la rotación deseada hacia esa dirección
            Quaternion rotacionDeseada = Quaternion.LookRotation(direccion);

            // 3. Suavizamos la rotación actual hacia la deseada
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, rotationSpeed * Time.deltaTime);
        }

        // 4. Avanzamos hacia adelante en su espacio local
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}