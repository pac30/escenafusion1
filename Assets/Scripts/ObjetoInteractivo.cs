using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
    // ?? Texto explicativo que aparecerá en pantalla cuando el jugador interactúe con este objeto
    [TextArea]
    public string mensajeExplicacion;

    public void Interactuar()
    {
        Debug.Log("Interacción con " + gameObject.name);

        // ?? Buscar el UIManager y mostrar el mensaje educativo en pantalla
        UIExplicacionLaboratorio ui = FindFirstObjectByType<UIExplicacionLaboratorio>();
        if (ui != null && !string.IsNullOrEmpty(mensajeExplicacion))
        {
            ui.MostrarExplicacion(mensajeExplicacion);
        }

        // ?? Lógica especial para ciertos objetos
        if (gameObject.name == "BotonEstufa")
        {
            // Encender o apagar la estufa
            ControlFusion control = FindFirstObjectByType<ControlFusion>();
            if (control != null)
                control.ToggleEstufa();
        }
    }
}