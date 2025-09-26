using UnityEngine;
using TMPro;

public class UIExplicacionLaboratorio : MonoBehaviour
{
    public TextMeshProUGUI textoUI; // Referencia al texto en el Canvas

    /// <summary>
    /// Mostrar explicaci�n predefinida seg�n el nombre del objeto.
    /// </summary>
    public void MostrarExplicacionPorNombre(string objeto)
    {
        string mensaje = "";

        switch (objeto)
        {
            // ?? Explicaci�n general del laboratorio
            case "Laboratorio":
                mensaje = "Bienvenido al laboratorio virtual de los estados de la materia. " +
                          "Aqu� aprender�s c�mo el hielo s�lido puede transformarse en agua l�quida y despu�s en vapor. " +
                          "El objetivo es entender que la materia cambia de estado seg�n la temperatura, pero nunca desaparece.";
                break;

            // ?? Objetos principales del laboratorio
            case "Olla":
                mensaje = "Esta es la olla. En ella colocamos el hielo para calentarlo. " +
                          "La olla es el recipiente donde se producen los cambios de estado.";
                break;

            case "Hielo":
                mensaje = "Este cubo de hielo representa el agua en estado s�lido. " +
                          "Los s�lidos tienen forma propia y sus part�culas est�n muy juntas.";
                break;

            case "Estufa":
                mensaje = "La estufa genera calor. Cuando aplicamos calor al hielo, este comienza a transformarse en agua l�quida.";
                break;

            case "BotonEstufa":
                mensaje = "Este es el bot�n de la estufa. Al presionarlo, encendemos la fuente de calor para iniciar el experimento.";
                break;

            case "Agua":
                mensaje = "El agua l�quida no tiene forma propia. Se adapta al recipiente en el que se encuentra, en este caso, la olla.";
                break;

            // ?? Explicaci�n de los estados de la materia
            case "EstadosMateria":
                mensaje = "La materia puede estar en tres estados principales:\n" +
                          "- S�lido ??: forma y volumen fijos (ejemplo: hielo).\n" +
                          "- L�quido ??: volumen fijo, pero sin forma propia (ejemplo: agua).\n" +
                          "- Gaseoso ???: sin forma ni volumen fijo, ocupa todo el espacio (ejemplo: vapor).";
                break;

            default:
                mensaje = "Objeto no identificado.";
                break;
        }

        if (textoUI != null)
            textoUI.text = mensaje;
    }

    /// <summary>
    /// Mostrar directamente un texto educativo recibido desde ObjetoInteractivo.
    /// </summary>
    public void MostrarExplicacion(string mensaje)
    {
        if (textoUI != null)
            textoUI.text = mensaje;
    }
}