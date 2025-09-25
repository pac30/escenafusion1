using UnityEngine;
using TMPro;

public class ControlFusion : MonoBehaviour
{
    public GameObject hielo;
    public GameObject agua;
    public Light luzEstufa;
    public TextMeshProUGUI textoUI;

    private bool estufaEncendida = false;
    private float temperatura = 0f;

    // Guardamos la escala y posición inicial del agua
    private Vector3 escalaInicialAgua;
    private Vector3 posicionInicialAgua;

    void Start()
    {
        if (agua != null)
        {
            // Guardamos sus valores iniciales para reiniciarlos cuando aparezca
            escalaInicialAgua = agua.transform.localScale;
            posicionInicialAgua = agua.transform.position;

            // Al inicio el agua está desactivada
            agua.SetActive(false);
        }
    }

    void Update()
    {
        if (estufaEncendida)
        {
            // 🔥 Aumentar temperatura
            temperatura += Time.deltaTime * 20f;

            if (textoUI != null)
                textoUI.text = "Temperatura: " + (int)temperatura + " °C";

            // 🧊 Derretir el hielo poco a poco
            if (hielo != null && hielo.activeSelf)
            {
                hielo.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f) * Time.deltaTime;

                if (hielo.transform.localScale.x <= 0.05f)
                {
                    hielo.SetActive(false);

                    if (agua != null)
                    {
                        agua.SetActive(true);

                        // Reiniciar agua desde su escala mínima
                        agua.transform.localScale = new Vector3(escalaInicialAgua.x, 0.01f, escalaInicialAgua.z);
                        agua.transform.position = posicionInicialAgua;
                    }
                }
            }

            // 💧 Si el agua está activa → hacer que suba
            if (agua != null && agua.activeSelf)
            {
                Vector3 escala = agua.transform.localScale;

                if (escala.y < escalaInicialAgua.y) // hasta la altura original
                {
                    escala.y += Time.deltaTime * 0.05f;
                    agua.transform.localScale = escala;

                    // Ajustar la posición en Y para que suba desde el fondo
                    Vector3 posicion = agua.transform.position;
                    posicion.y += Time.deltaTime * 0.025f;
                    agua.transform.position = posicion;

                    Debug.Log("El agua está activa, subiendo...");
                }
            }
        }
    }

    // 🔘 Encender / apagar la estufa
    public void ToggleEstufa()
    {
        estufaEncendida = !estufaEncendida;

        if (luzEstufa != null)
            luzEstufa.enabled = estufaEncendida;

        Debug.Log("La estufa ha cambiado de estado: " + (estufaEncendida ? "Encendida" : "Apagada"));
    }
}
