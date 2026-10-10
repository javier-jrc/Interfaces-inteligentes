using UnityEngine;

public class ScriptEsfera2 : MonoBehaviour
{
    public float velocidad = 5.0f;

    void Update()
    {
        // Ejercicio 10
        MoverEsferaEjercicio10();
    }

    private void MoverEsferaEjercicio9()
    {
        float deltaX = 0.0f;
        float deltaZ = 0.0f;

        if (Input.GetKey(KeyCode.W)) deltaZ += 1.0f;
        if (Input.GetKey(KeyCode.S)) deltaZ -= 1.0f;
        if (Input.GetKey(KeyCode.D)) deltaX += 1.0f;
        if (Input.GetKey(KeyCode.A)) deltaX -= 1.0f;

        Vector3 direccion = new Vector3(deltaX, 0.0f, deltaZ);
        transform.Translate(direccion * velocidad);
    }

    // Ejercicio 10: Adaptación con Time.deltaTime
    private void MoverEsferaEjercicio10()
    {
        float deltaX = 0.0f;
        float deltaZ = 0.0f;

        if (Input.GetKey(KeyCode.W)) deltaZ += 1.0f;
        if (Input.GetKey(KeyCode.S)) deltaZ -= 1.0f;
        if (Input.GetKey(KeyCode.D)) deltaX += 1.0f;
        if (Input.GetKey(KeyCode.A)) deltaX -= 1.0f;

        Vector3 direccion = new Vector3(deltaX, 0.0f, deltaZ);

        // Multiplicamos por Time.deltaTime
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }
}