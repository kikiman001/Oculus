using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{

	
    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Si estás en la última escena, puedes cargar la primera escena 
            SceneManager.LoadScene(0); // Esto carga la escena.
        }
    }

    public void LoadPreviousScene()
    {
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;

        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            // Si estás en la primera escena y quieres ir a la última.
            int lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
            SceneManager.LoadScene(lastSceneIndex);
        }
    }
}
