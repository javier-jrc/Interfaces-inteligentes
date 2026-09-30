using UnityEngine;

public class ScriptCubo : MonoBehaviour
{
// Start is called once before the first execution of Update after the MonoBehaviour is created
    public int FramesEspera = 120;
    public int Frame_cnt = 0;
    private Vector3 vectorColor = new Vector3(0.0f, 1.0f, 0.0f);

    private Renderer rendererObjeto;

    void Start() {
        rendererObjeto = GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void CambiarColor() {
        int indiceAleatorio = Random.Range(0, 3);
        vectorColor[indiceAleatorio]= Random.Range(0.0f, 1.0f);   
        rendererObjeto.material.color = new Color(vectorColor[0], vectorColor[1], vectorColor[2]); 
        
    }
    void Update() {
        Frame_cnt++;
        if( Frame_cnt >= FramesEspera) {
            CambiarColor();
            Frame_cnt=0;     
        }
    }

}

