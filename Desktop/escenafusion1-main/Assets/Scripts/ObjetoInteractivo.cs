using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
    [TextArea]
    public string mensajeExplicacion;

    public GameObject prefabHielo; // para la nevera
    public ControlFusion olla; // para colocar hielo

    public void Interactuar()
    {
        Debug.Log("Interacción con " + gameObject.name);

        UIExplicacionLaboratorio ui = FindFirstObjectByType<UIExplicacionLaboratorio>();
        if (ui != null && !string.IsNullOrEmpty(mensajeExplicacion))
        {
            ui.MostrarExplicacion(mensajeExplicacion);
        }

        InventarioJugador jugador = FindFirstObjectByType<InventarioJugador>();

        // Nevera ? tomar hielo
        if (gameObject.name == "Nevera" && prefabHielo != null && jugador != null)
        {
            jugador.TomarHielo(prefabHielo);
        }

        // Olla ? colocar hielo
        if (gameObject.name == "Olla" && olla != null && jugador != null)
        {
            jugador.ColocarHieloEnOlla(olla);
        }

        // Botón estufa ? encender/apagar
        if (gameObject.name == "BotonEstufa")
        {
            ControlFusion control = FindFirstObjectByType<ControlFusion>();
            if (control != null)
                control.ToggleEstufa();
        }
    }
}
