using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    public void RestartGame()
{
    Time.timeScale = 1; // Asegurar que el tiempo no esté pausado
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recargar la escena actual

    // Asegurar que el cursor no quede bloqueado después de reiniciar
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
}

}
