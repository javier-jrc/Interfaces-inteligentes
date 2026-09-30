using UnityEngine;

public class ScriptEsfera : MonoBehaviour
{
    // 1. Vectores de entrada (se pueden modificar desde el Inspector)
    public Vector3 vector1 = new Vector3(0.0f, 1.0f, 0.0f);
    public Vector3 vector2 = new Vector3(1.0f, 0.0f, 0.0f);

    //pos de la esfera
    public Vector3 pos;

    // 2. Variables para mostrar los resultados en el Inspector
    public float magnitudVector1;
    public float magnitudVector2;
    public float anguloEntreVectores;
    public float distanciaEntreVectores;
    public string mensajeAltura;
    public int cnt = 0;
    void Update() {
        cnt++; //contador para los frames
        // a. Magnitud de cada uno
        pos = GetComponent<Transform>().position;
        magnitudVector1 = vector1.magnitude;
        magnitudVector2 = vector2.magnitude;

        // b. El ángulo que forman entre sí
        anguloEntreVectores = Vector3.Angle(vector1, vector2);

        // c. La distancia entre ambos
        distanciaEntreVectores = Vector3.Distance(vector1, vector2);

        // d. Determinar cuál está a mayor altura (comparando la componente Y)
        if (vector1.y > vector2.y) {
            mensajeAltura = "El Vector 1 está a mayor altura.";
        }
        else if (vector2.y > vector1.y) {
            mensajeAltura = "El Vector 2 está a mayor altura.";
        }
        else {
            mensajeAltura = "Ambos vectores están a la misma altura.";
        }
        

        //distancia entre el cilindro y el cubo
        GameObject CUBO = GameObject.FindWithTag("Cube");
        GameObject CILINDRO = GameObject.FindWithTag("Cylinder");
        
        float distancia_cubo_cilindro = Vector3.Distance(CUBO.transform.position, CILINDRO.transform.position);




        // Muestra los resultados en la ventana de Consola
        if(cnt>=1200){
            Debug.Log($"Mag1: {magnitudVector1} | Mag2: {magnitudVector2} | Ángulo: {anguloEntreVectores}° | Distancia: {distanciaEntreVectores} | {mensajeAltura}");
            Debug.Log($"Posición Esfera: {pos} ");
            Debug.Log($"Distancia entre el cubo y el cilindro: {distancia_cubo_cilindro} ");
            cnt=0;
        }
    }
}