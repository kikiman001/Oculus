using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GAME : MonoBehaviour
{
    public Collider playerCollider;  // Asigna el collider del jugador al inspector
    public Collider enemyCollisionBox;
    public Collider endOfMazeCollider;
    public string sceneToLoad = "practica5";  // Cambia esto al nombre de tu escena principal

    void Update()
    {
        // Verifica si el jugador ha llegado al final del laberinto
        if (playerCollider.bounds.Intersects(endOfMazeCollider.bounds))
        {
            RestartGame();
        }
    }

    // Este método se llama cuando algo entra en el collider asociado a este objeto
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisionó tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // El jugador colisionó, reinicia el juego
            RestartGame();
        }
        
    }
     
    void RestartGame()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(sceneToLoad);
    }

}
