using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject menuCanvas; // Arrastra aquí el Canvas del menú en el Inspector
    private bool isPaused = false;
    // private PlayerStats playerStats; // Referencia al script del jugador

    void Start()
    {
        menuCanvas.SetActive(false); // Asegurarse de que el menú está oculto al inicio
        //playerStats = FindObjectOfType<PlayerStats>(); // Encuentra el script del jugador
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        isPaused = !isPaused;
        menuCanvas.SetActive(isPaused);
        
        if (isPaused)
        {
            Time.timeScale = 0f; // Pausar el juego
            Cursor.lockState = CursorLockMode.None; // Liberar el cursor
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el juego
            Cursor.lockState = CursorLockMode.Locked; // Ocultar el cursor
            Cursor.visible = false;
        }
    }

    /*public void ToggleImmortality()
    {
        if (playerStats != null)
        {
            playerStats.isImmortal = !playerStats.isImmortal;
            Debug.Log("Inmortalidad: " + (playerStats.isImmortal ? "Activada" : "Desactivada"));
        }
    }*/
}
