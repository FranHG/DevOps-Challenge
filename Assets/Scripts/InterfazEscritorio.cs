using UnityEngine;
using UnityEngine.UI;

public class InterfazEscritorio : MonoBehaviour
{
    public Canvas canvasInterfaz;
    public float distanciaActivacion = 3f; // Distancia a la que se activará la interfaz
    private bool estaCerca = false;
    private bool interfazActivada = false;

    public Button botonCerrar;

    public string computerID;

    // Referencia al MissionManager
    private MissionManager missionManager;

    private void Start()
    {
        // Se desactiva la interfaz al inicio
        canvasInterfaz.gameObject.SetActive(false);

        missionManager = MissionManager.instance;

        // Asigna la función CerrarInterfaz al clic del botón
        if (botonCerrar != null)
        {
            botonCerrar.onClick.AddListener(CerrarInterfaz);
        }
    }

    private void Update()
    {
        // Verifica si el personaje está cerca y si se presionó la tecla 'E'
        if (estaCerca && Input.GetKeyDown(KeyCode.E))
        {
            // Alterna la visibilidad de la interfaz al presionar la tecla 'E'
            interfazActivada = !interfazActivada;
            canvasInterfaz.gameObject.SetActive(interfazActivada);

            // Bloquea o desbloquea el cursor según si la interfaz está activada o no
            Cursor.lockState = interfazActivada ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = interfazActivada;
        }
    }

    private void CerrarInterfaz()
    {
        // Oculta la interfaz al hacer clic en el botón de cerrar
        interfazActivada = false;
        canvasInterfaz.gameObject.SetActive(false);

        // Bloquea el cursor nuevamente al salir de la interfaz
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        missionManager.CompleteMission(computerID);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el personaje está cerca
        if (other.CompareTag("Player"))
        {
            // El personaje está cerca
            estaCerca = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el personaje se alejó
        if (other.CompareTag("Player"))
        {
            // El personaje se alejó, desactivar la interfaz
            estaCerca = false;
            interfazActivada = false;
            canvasInterfaz.gameObject.SetActive(false);

            // Bloquea el cursor nuevamente al salir de la interfaz
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
