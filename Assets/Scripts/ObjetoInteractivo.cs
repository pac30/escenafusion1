using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
    // ?? Texto explicativo que aparecer� en pantalla cuando el jugador interact�e con este objeto
    [TextArea]
    public string mensajeExplicacion;

    public void Interactuar()
    {
        Debug.Log("Interacci�n con " + gameObject.name);

        // ?? Buscar el UIManager y mostrar el mensaje educativo en pantalla
        UIExplicacionLaboratorio ui = FindFirstObjectByType<UIExplicacionLaboratorio>();
        if (ui != null && !string.IsNullOrEmpty(mensajeExplicacion))
        {
            ui.MostrarExplicacion(mensajeExplicacion);
        }

        // ?? L�gica especial para ciertos objetos
        if (gameObject.name == "BotonEstufa")
        {
            // Encender o apagar la estufa
            ControlFusion control = FindFirstObjectByType<ControlFusion>();
            if (control != null)
                control.ToggleEstufa();
        }
    }
}