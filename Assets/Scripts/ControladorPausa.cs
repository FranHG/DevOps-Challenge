using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    private bool juegoPausado = false;
    public GameObject menuPausaUI;
    public GameObject confirmacionUI;
    public Button continuarButton;
    public Button volverAlMenuPrincipalButton;
    public Button siButton;
    public Button noButton;
    public GameObject canvasOrdenador;

    void Start()
    {
        // Al inicio el menú de pausa y la confirmación están desactivados
        menuPausaUI.SetActive(false);
        confirmacionUI.SetActive(false);

        // Se asignan funciones a los botones
        continuarButton.onClick.AddListener(Reanudar);
        volverAlMenuPrincipalButton.onClick.AddListener(MostrarConfirmacion);
        siButton.onClick.AddListener(VolverAlMenuPrincipal);
        noButton.onClick.AddListener(OcultarConfirmacion);
    }

    void Update()
    {
        // Si se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si el juego está pausado, lo reanuda.
            if (juegoPausado)
                Reanudar();
            else //Si no, se pausa.
                Pausar();
        }
    }

    public void Reanudar()
    {
        // Ocultar el menú de pausa y la confirmación
        menuPausaUI.SetActive(false);
        confirmacionUI.SetActive(false);
        Time.timeScale = 1f; // Reanudar el tiempo
        juegoPausado = false;
        if (!canvasOrdenador.activeSelf){
            // Ocultar el cursor del ratón y bloquearlo
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Pausar()
    {
        // Mostrar el menú de pausa
        menuPausaUI.SetActive(true);
        confirmacionUI.SetActive(false); // Se oculta la confirmación al abrir el menú de pausa
        Time.timeScale = 0f; // Pausar el tiempo
        juegoPausado = true;

        // Se muestra el cursor del ratón
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void MostrarConfirmacion()
    {
        confirmacionUI.SetActive(true);
        menuPausaUI.SetActive(false); // Se oculta el menú de pausa al mostrar la confirmación
    }

    public void OcultarConfirmacion()
    {
        confirmacionUI.SetActive(false);
        menuPausaUI.SetActive(true); // Se vuelve a mostrar el menú de pausa al ocultar la confirmación
    }

    public void VolverAlMenuPrincipal()
    {
        // Volver al menú principal
        SceneManager.LoadScene("MenuPrincipal");
    }
}