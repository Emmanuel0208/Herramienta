using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public GameObject canvasWin;
    public GameObject canvasLose;
    public Text instructionText; // Referencia al texto de instrucciones en el Canvas

    private string requestedShape;
    private string[] shapes = { "Cube", "Sphere", "Capsule" };

    private void Start()
    {
        canvasWin.SetActive(false);
        canvasLose.SetActive(false);
        RequestRandomShape();
    }

    private void RequestRandomShape()
    {
        // Selecciona una figura aleatoria
        requestedShape = shapes[Random.Range(0, shapes.Length)];

        // Muestra la instrucci�n en el texto de UI
        instructionText.text = "Por favor, crea un: " + requestedShape;

        Debug.Log("Requested shape: " + requestedShape); // Mensaje en consola para depuraci�n
    }

    public void CheckShape(GameObject createdObject)
    {
        // Compara la figura solicitada con la creada por el jugador
        if (createdObject.name.Contains(requestedShape))
        {
            ShowCanvas(true); // Ganaste
        }
        else
        {
            ShowCanvas(false); // Perdiste
        }
    }

    private void ShowCanvas(bool isWin)
    {
        if (isWin)
        {
            canvasWin.SetActive(true);
        }
        else
        {
            canvasLose.SetActive(true);
        }

        // Reinicia el juego despu�s de un peque�o retraso
        Invoke("RestartGame", 3f);
    }

    private void RestartGame()
    {
        canvasWin.SetActive(false);
        canvasLose.SetActive(false);
        RequestRandomShape(); // Solicita una nueva figura
    }
}
