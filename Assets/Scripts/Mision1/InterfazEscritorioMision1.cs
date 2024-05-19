using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfazEscritorioMision1 : MonoBehaviour
{
    public Canvas canvasInterfaz;
    public float distanciaActivacion = 3f; // Distancia a la que se activará la interfaz
    private bool estaCerca = false;
    private bool interfazActivada = false;

    public Button botonCerrar;
    public Button botonSeleccion;
    public Button botonComunicacion;
    public Button botonMetricas;
    public Button volverSeleccion;
    public Button volverComunicacion;
    public Button volverMetricas;
    public Button confirmarSeleccion;
    public Button confirmarComunicacion;
    public Button confirmarSi;
    public Button confirmarNo;
    public Button confirmarSiCo;
    public Button confirmarNoCo;

    public Button botonEmpleado1;
    public Button botonEmpleado2;
    public Button botonEmpleado3;
    public Button botonEmpleado4;
    public Button botonEmpleado5;
    public Button botonEmpleado6;

    public Button botonVolverEmpleado1;
    public Button botonVolverEmpleado2;
    public Button botonVolverEmpleado3;
    public Button botonVolverEmpleado4;
    public Button botonVolverEmpleado5;
    public Button botonVolverEmpleado6;

    public Button botonComunicacion1;
    public Button botonComunicacion2;
    public Button botonComunicacion3;
    public Button botonComunicacion4;
    public Button botonComunicacion5;
    public Button botonComunicacion6;
    
    public Button botonVolverComunicacion1;
    public Button botonVolverComunicacion2;
    public Button botonVolverComunicacion3;
    public Button botonVolverComunicacion4;
    public Button botonVolverComunicacion5;
    public Button botonVolverComunicacion6;

    public Button botonMetricaSeleccion;
    public Button botonMetricaComunicacion;
    public Button botonMetricaAutomatizacion;
    public Button botonMetricaFeedback;

    public Button botonVolverMetricaSeleccion;
    public Button botonVolverMetricaComunicacion;
    public Button botonVolverMetricaAutomatizacion;
    public Button botonVolverMetricaFeedback;

    public GameObject menuSeleccion;
    public GameObject menuComunicacion;
    public GameObject menuMetricas;
    public GameObject avisoConfirmacion;
    public GameObject avisoConfirmacionCo;
    public GameObject infEmpleado1;
    public GameObject infEmpleado2;
    public GameObject infEmpleado3;
    public GameObject infEmpleado4;
    public GameObject infEmpleado5;
    public GameObject infEmpleado6;
    public GameObject infComunicacion1;
    public GameObject infComunicacion2;
    public GameObject infComunicacion3;
    public GameObject infComunicacion4;
    public GameObject infComunicacion5;
    public GameObject infComunicacion6;

    public GameObject grafico;
    public GameObject graficoPre;
    public GameObject grafico1;
    public GameObject grafico2;
    public GameObject grafico3;
    public GameObject grafico4;
    public GameObject grafico5;
    public GameObject grafico6;
    public GameObject grafico7;

    public GameObject graficoCo;
    public GameObject graficoPreCo;
    public GameObject grafico1Co;
    public GameObject grafico2Co;
    public GameObject grafico3Co;
    public GameObject grafico4Co;
    public GameObject grafico5Co;
    public GameObject grafico6Co;
    public GameObject grafico7Co;
    public GameObject grafico8Co;

    public GameObject graficoAu;
    public GameObject graficoFd;

    public GameObject menuMetricaSeleccion;
    public GameObject menuMetricaComunicacion;
    public GameObject menuMetricasAutomatizacion;
    public GameObject menuMetricaFeedback;

    public string computerID;

    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    public Toggle toggle4;
    public Toggle toggle5;
    public Toggle toggle6;
    public Toggle toggle7;
    public Toggle toggle8;
    public Toggle toggle9;
    public Toggle toggle10;
    public Toggle toggle11;
    public Toggle toggle12;

    public Toggle toggleCo1;
    public Toggle toggleCo2;
    public Toggle toggleCo3;
    public Toggle toggleCo4;
    public Toggle toggleCo5;
    public Toggle toggleCo6;

    // Listas para mantener el seguimiento de los toggles activos
    private List<Toggle> togglesGrupo1Activos = new List<Toggle>();
    private List<Toggle> togglesGrupo2Activos = new List<Toggle>();
    private List<Toggle> togglesGrupoComunicacionActivos = new List<Toggle>();

    // Bloquea temporalmente la adición de nuevos toggles mientras se procesa un cambio
    private bool isProcessingToggleChange = false;

    // Referencia al MissionManager
    private MisionManagerMision1 missionManager;
    private VariablesScript variablesScript;

    private void Start()
    {
        // Desactivar la interfaz al inicio
        canvasInterfaz.gameObject.SetActive(false);

        missionManager = MisionManagerMision1.instance;
        variablesScript = VariablesScript.instance;
        // Se asignan los métodos a los botones
        botonCerrar.onClick.AddListener(CerrarInterfaz);
        botonSeleccion.onClick.AddListener(onClickSeleccion);
        botonComunicacion.onClick.AddListener(onClickComunicacion);
        botonMetricas.onClick.AddListener(onClickMetricas);
        volverSeleccion.onClick.AddListener(OnClickVolverSeleccion);
        volverComunicacion.onClick.AddListener(OnClickVolverComunicacion);
        volverMetricas.onClick.AddListener(OnClickVolverMetricas);
        confirmarSeleccion.onClick.AddListener(onClickConfirmarSeleccion);
        confirmarComunicacion.onClick.AddListener(onClickConfirmarComunicacion);
        confirmarSi.onClick.AddListener(onClickConfirmarSi);
        confirmarNo.onClick.AddListener(onClickConfirmarNo);
        confirmarSiCo.onClick.AddListener(onClickConfirmarSiCo);
        confirmarNoCo.onClick.AddListener(onClickConfirmarNoCo);
        botonEmpleado1.onClick.AddListener(OnClickEmpleado1);
        botonEmpleado2.onClick.AddListener(OnClickEmpleado2);
        botonEmpleado3.onClick.AddListener(OnClickEmpleado3);
        botonEmpleado4.onClick.AddListener(OnClickEmpleado4);
        botonEmpleado5.onClick.AddListener(OnClickEmpleado5);
        botonEmpleado6.onClick.AddListener(OnClickEmpleado6);

        botonVolverEmpleado1.onClick.AddListener(OnClickVolverEmpleado1);
        botonVolverEmpleado2.onClick.AddListener(OnClickVolverEmpleado2);
        botonVolverEmpleado3.onClick.AddListener(OnClickVolverEmpleado3);
        botonVolverEmpleado4.onClick.AddListener(OnClickVolverEmpleado4);
        botonVolverEmpleado5.onClick.AddListener(OnClickVolverEmpleado5);
        botonVolverEmpleado6.onClick.AddListener(OnClickVolverEmpleado6);

        botonComunicacion1.onClick.AddListener(OnClickComunicacion1);
        botonComunicacion2.onClick.AddListener(OnClickComunicacion2);
        botonComunicacion3.onClick.AddListener(OnClickComunicacion3);
        botonComunicacion4.onClick.AddListener(OnClickComunicacion4);
        botonComunicacion5.onClick.AddListener(OnClickComunicacion5);
        botonComunicacion6.onClick.AddListener(OnClickComunicacion6);

        botonVolverComunicacion1.onClick.AddListener(OnClickVolverComunicacion1);
        botonVolverComunicacion2.onClick.AddListener(OnClickVolverComunicacion2);
        botonVolverComunicacion3.onClick.AddListener(OnClickVolverComunicacion3);
        botonVolverComunicacion4.onClick.AddListener(OnClickVolverComunicacion4);
        botonVolverComunicacion5.onClick.AddListener(OnClickVolverComunicacion5);
        botonVolverComunicacion6.onClick.AddListener(OnClickVolverComunicacion6);

        botonMetricaSeleccion.onClick.AddListener(OnClickMetricaSeleccion);
        botonMetricaComunicacion.onClick.AddListener(OnclickMetricaComunicacion);
        botonMetricaAutomatizacion.onClick.AddListener(OnclickMetricaAutomatizacion);
        botonMetricaFeedback.onClick.AddListener(OnclickMetricaFeedback);

        botonVolverMetricaSeleccion.onClick.AddListener(OnClickVolverMetricaSeleccion);
        botonVolverMetricaComunicacion.onClick.AddListener(OnClickVolverMetricaComunicacion);
        botonVolverMetricaAutomatizacion.onClick.AddListener(OnClickVolverMetricaAutomatizacion);
        botonVolverMetricaFeedback.onClick.AddListener(OnClickVolverMetricaFeedback);
        // Asigna el manejador de eventos a los toggles
        toggle1.onValueChanged.AddListener(OnToggle1Changed);
        toggle2.onValueChanged.AddListener(OnToggle2Changed);
        toggle3.onValueChanged.AddListener(OnToggle3Changed);
        toggle4.onValueChanged.AddListener(OnToggle4Changed);
        toggle5.onValueChanged.AddListener(OnToggle5Changed);
        toggle6.onValueChanged.AddListener(OnToggle6Changed);
        toggle7.onValueChanged.AddListener(OnToggle7Changed);
        toggle8.onValueChanged.AddListener(OnToggle8Changed);
        toggle9.onValueChanged.AddListener(OnToggle9Changed);
        toggle10.onValueChanged.AddListener(OnToggle10Changed);
        toggle11.onValueChanged.AddListener(OnToggle11Changed);
        toggle12.onValueChanged.AddListener(OnToggle12Changed);

        // Asigna el manejador de eventos a los toggles
        toggle1.onValueChanged.AddListener((value) => OnToggleChanged(toggle1, value, 1));
        toggle2.onValueChanged.AddListener((value) => OnToggleChanged(toggle2, value, 2));
        toggle3.onValueChanged.AddListener((value) => OnToggleChanged(toggle3, value, 1));
        toggle4.onValueChanged.AddListener((value) => OnToggleChanged(toggle4, value, 2));
        toggle5.onValueChanged.AddListener((value) => OnToggleChanged(toggle5, value, 1));
        toggle6.onValueChanged.AddListener((value) => OnToggleChanged(toggle6, value, 2));
        toggle7.onValueChanged.AddListener((value) => OnToggleChanged(toggle7, value, 1));
        toggle8.onValueChanged.AddListener((value) => OnToggleChanged(toggle8, value, 2));
        toggle9.onValueChanged.AddListener((value) => OnToggleChanged(toggle9, value, 1));
        toggle10.onValueChanged.AddListener((value) => OnToggleChanged(toggle10, value, 2));
        toggle11.onValueChanged.AddListener((value) => OnToggleChanged(toggle11, value, 1));
        toggle12.onValueChanged.AddListener((value) => OnToggleChanged(toggle12, value, 2));

        toggleCo1.onValueChanged.AddListener((value) => OnToggleCoChanged(toggleCo1, value));
        toggleCo2.onValueChanged.AddListener((value) => OnToggleCoChanged(toggleCo2, value));
        toggleCo3.onValueChanged.AddListener((value) => OnToggleCoChanged(toggleCo3, value));
        toggleCo4.onValueChanged.AddListener((value) => OnToggleCoChanged(toggleCo4, value));
        toggleCo5.onValueChanged.AddListener((value) => OnToggleCoChanged(toggleCo5, value));
        toggleCo6.onValueChanged.AddListener((value) => OnToggleCoChanged(toggleCo6, value));

        // Se inicializan los gráficos y menús
        menuSeleccion.SetActive(false);
        menuComunicacion.SetActive(false);
        menuMetricas.SetActive(false);
        avisoConfirmacion.SetActive(false);
        avisoConfirmacionCo.SetActive(false);
        infEmpleado1.SetActive(false);
        infEmpleado2.SetActive(false);
        infEmpleado3.SetActive(false);
        infEmpleado4.SetActive(false);
        infEmpleado5.SetActive(false);
        infEmpleado6.SetActive(false);
        infComunicacion1.SetActive(false);
        infComunicacion2.SetActive(false);
        infComunicacion3.SetActive(false);
        infComunicacion4.SetActive(false);
        infComunicacion5.SetActive(false);
        infComunicacion6.SetActive(false);
        menuMetricaSeleccion.SetActive(false);
        menuMetricaComunicacion.SetActive(false);
        menuMetricasAutomatizacion.SetActive(false);
        menuMetricaFeedback.SetActive(false);
        grafico.SetActive(false);
        graficoPre.SetActive(false);
        grafico1.SetActive(false);
        grafico2.SetActive(false);
        grafico3.SetActive(false);
        grafico4.SetActive(false);
        grafico5.SetActive(false);
        grafico6.SetActive(false);
        grafico7.SetActive(false);
        graficoCo.SetActive(false);
        graficoPreCo.SetActive(false);
        grafico1Co.SetActive(false);
        grafico2Co.SetActive(false);
        grafico3Co.SetActive(false);
        grafico4Co.SetActive(false);
        grafico5Co.SetActive(false);
        grafico6Co.SetActive(false);
        grafico7Co.SetActive(false);
        grafico8Co.SetActive(false);
        graficoAu.SetActive(false);
        graficoFd.SetActive(false);

        grafico = graficoPre;
        graficoCo = graficoPreCo;
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

            // Verifica si la misión actual es la correcta para activar los botones
            if (missionManager.GetCurrentMissionIndex() == 2){
                botonSeleccion.interactable = true;
                botonComunicacion.interactable = false;
            } else if (missionManager.GetCurrentMissionIndex() == 6){
                botonSeleccion.interactable = false;
                botonComunicacion.interactable = true;
            } else {
                botonSeleccion.interactable = false;
                botonComunicacion.interactable = false;
            }
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

            // Bloquear el cursor nuevamente al salir de la interfaz
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void onClickSeleccion() {
        menuSeleccion.SetActive(true);
        volverSeleccion.interactable = true;
        botonMetricas.gameObject.SetActive(false); 
        botonComunicacion.gameObject.SetActive(false);
    }

    void onClickComunicacion() {
        menuComunicacion.SetActive(true);
        volverComunicacion.interactable = true;
        botonMetricas.gameObject.SetActive(false);
    }

    void onClickMetricas() {
        menuMetricas.SetActive(true);
        volverMetricas.interactable = true;
    }

    void OnClickMetricaSeleccion() {
        menuMetricaSeleccion.SetActive(true);
        botonVolverMetricaSeleccion.interactable = true;
        menuMetricas.SetActive(false);
        // Dependiendo de la misión actual, se muestra un gráfico u otro
        if (missionManager.GetCurrentMissionIndex() < 3) {
            grafico.SetActive(true);
        } else {
            int puntuacion = variablesScript.GetPuntuacionSeleccion();
            switch (puntuacion)
            {
                case 0:
                    grafico = grafico7;
                    break;
                case 5:
                    grafico = grafico6;
                    break;
                case 10:
                    grafico = grafico5;
                    break;
                case 15:
                    grafico = grafico4;
                    break;
                case 20:
                    grafico = grafico3;
                    break;
                case 25:
                    grafico = grafico2;
                    break;
                case 30:
                    grafico = grafico1;
                    break;
            }
            grafico.SetActive(true);
        }
    }

    void OnclickMetricaComunicacion() {
        menuMetricaComunicacion.SetActive(true);
        botonVolverMetricaComunicacion.interactable = true;
        menuMetricas.SetActive(false);
        // Dependiendo de la misión actual, se muestra un gráfico u otro
        if (missionManager.GetCurrentMissionIndex() < 7) {
            graficoCo.SetActive(true);
        } else {
            int puntuacion = variablesScript.GetPuntuacionComunicacion();
            switch (puntuacion)
            {
                case 0:
                    graficoCo = grafico1Co;
                    variablesScript.SetGraficoComunicacion(1);
                    break;
                case 10:
                    if (toggleCo2.isOn) {
                        graficoCo = grafico2Co;
                        variablesScript.SetGraficoComunicacion(2);
                    } else if (toggleCo4.isOn){
                        graficoCo = grafico3Co;
                        variablesScript.SetGraficoComunicacion(3);
                    } else {
                        graficoCo = grafico4Co;
                        variablesScript.SetGraficoComunicacion(4);
                    }
                    break;
                case 20:
                    if (toggleCo2.isOn && toggleCo4.isOn){
                        graficoCo = grafico5Co;
                        variablesScript.SetGraficoComunicacion(5);
                    }else if (toggleCo2.isOn && toggleCo5.isOn) {
                        graficoCo = grafico6Co;
                        variablesScript.SetGraficoComunicacion(6);
                    } else if (toggleCo4.isOn && toggleCo5.isOn) {
                        graficoCo = grafico7Co;
                        variablesScript.SetGraficoComunicacion(7);
                    }
                    break;
                case 30:
                    graficoCo = grafico8Co;
                    variablesScript.SetGraficoComunicacion(8);
                    break;
            }
            graficoCo.SetActive(true);
        }
    }

    void OnclickMetricaAutomatizacion() {
        menuMetricasAutomatizacion.SetActive(true);
        botonVolverMetricaAutomatizacion.interactable = true;
        menuMetricas.SetActive(false);
        graficoAu.SetActive(true);
    }

    void OnclickMetricaFeedback() {
        menuMetricaFeedback.SetActive(true);
        botonVolverMetricaFeedback.interactable = true;
        menuMetricas.SetActive(false);
        graficoFd.SetActive(true);
    }

    void OnClickVolverSeleccion() {
        menuSeleccion.SetActive(false);
        volverSeleccion.interactable = false;
        botonComunicacion.gameObject.SetActive(true);
        botonMetricas.gameObject.SetActive(true); 
    }

    void OnClickVolverComunicacion() {
        menuComunicacion.SetActive(false);
        volverComunicacion.interactable = false;
        botonMetricas.gameObject.SetActive(true);
    }

    void OnClickVolverMetricas() {
        menuMetricas.SetActive(false);
        if (missionManager.GetCurrentMissionIndex() == 4) {
                missionManager.CompleteMission(computerID,2);
        } else if (missionManager.GetCurrentMissionIndex() == 8) {
                missionManager.CompleteMission(computerID,2);
        }
    }

    void OnClickVolverMetricaSeleccion() {
        menuMetricaSeleccion.SetActive(false);
        grafico.SetActive(false);
        botonVolverMetricaSeleccion.interactable = false;
        menuMetricas.SetActive(true);
    }

    void OnClickVolverMetricaComunicacion() {
        menuMetricaComunicacion.SetActive(false);
        graficoCo.SetActive(false);
        botonVolverMetricaComunicacion.interactable = false;
        menuMetricas.SetActive(true);
    }

    void OnClickVolverMetricaAutomatizacion() {
        menuMetricasAutomatizacion.SetActive(false);
        graficoAu.SetActive(false);
        botonVolverMetricaAutomatizacion.interactable = false;
        menuMetricas.SetActive(true);
    }

    void OnClickVolverMetricaFeedback() {
        menuMetricaFeedback.SetActive(false);
        graficoFd.SetActive(false);
        botonVolverMetricaFeedback.interactable = false;
        menuMetricas.SetActive(true);
    }

    void onClickConfirmarSeleccion() {
        avisoConfirmacion.SetActive(true);
        volverSeleccion.interactable = false;
        confirmarSeleccion.interactable = false;
    }

    void onClickConfirmarComunicacion() {
        avisoConfirmacionCo.SetActive(true);
        volverComunicacion.interactable = false;
        confirmarComunicacion.interactable = false;
    }

    void onClickConfirmarSi() {
        menuSeleccion.SetActive(false);
        avisoConfirmacion.SetActive(false);
        volverSeleccion.interactable = false;
        botonSeleccion.interactable = false;
        int puntos = puntosSeleccion();
        missionManager.CompleteMission(computerID,puntos);
        botonComunicacion.gameObject.SetActive(true);
        botonMetricas.gameObject.SetActive(true);
    }

    void onClickConfirmarNo() {
        avisoConfirmacion.SetActive(false);
        volverSeleccion.interactable = true;
        confirmarSeleccion.interactable = true;
    }

    void onClickConfirmarSiCo() {
        menuComunicacion.SetActive(false);
        avisoConfirmacionCo.SetActive(false);
        volverComunicacion.interactable = false;
        botonComunicacion.interactable = false;
        int puntos = puntosComunicacion();
        botonMetricas.gameObject.SetActive(true);
        missionManager.CompleteMission(computerID,puntos);
    }

    void onClickConfirmarNoCo() {
        avisoConfirmacionCo.SetActive(false);
        volverComunicacion.interactable = true;
        confirmarComunicacion.interactable = true;
    }

    void OnClickEmpleado1() {
        infEmpleado1.SetActive(true);
    }

     void OnClickEmpleado2() {
        infEmpleado2.SetActive(true);
    }

     void OnClickEmpleado3() {
        infEmpleado3.SetActive(true);
    }

     void OnClickEmpleado4() {
        infEmpleado4.SetActive(true);
    }

     void OnClickEmpleado5() {
        infEmpleado5.SetActive(true);
    }

     void OnClickEmpleado6() {
        infEmpleado6.SetActive(true);
    }

    void OnClickVolverEmpleado1() {
        infEmpleado1.SetActive(false);
    }

    void OnClickVolverEmpleado2() {
        infEmpleado2.SetActive(false);
    }

    void OnClickVolverEmpleado3() {
        infEmpleado3.SetActive(false);
    }

    void OnClickVolverEmpleado4() {
        infEmpleado4.SetActive(false);
    }

    void OnClickVolverEmpleado5() {
        infEmpleado5.SetActive(false);
    }

    void OnClickVolverEmpleado6() {
        infEmpleado6.SetActive(false);
    }

    void OnClickComunicacion1() {
        infComunicacion1.SetActive(true);
    }

    void OnClickComunicacion2() {
        infComunicacion2.SetActive(true);
    }

    void OnClickComunicacion3() {
        infComunicacion3.SetActive(true);
    }

    void OnClickComunicacion4() {
        infComunicacion4.SetActive(true);
    }

    void OnClickComunicacion5() {
        infComunicacion5.SetActive(true);
    }

    void OnClickComunicacion6() {
        infComunicacion6.SetActive(true);
    }

    void OnClickVolverComunicacion1() {
        infComunicacion1.SetActive(false);
    }

    void OnClickVolverComunicacion2() {
        infComunicacion2.SetActive(false);
    }

    void OnClickVolverComunicacion3() {
        infComunicacion3.SetActive(false);
    }

    void OnClickVolverComunicacion4() {
        infComunicacion4.SetActive(false);
    }

    void OnClickVolverComunicacion5() {
        infComunicacion5.SetActive(false);
    }

    void OnClickVolverComunicacion6() {
        infComunicacion6.SetActive(false);
    }

    void OnToggle1Changed(bool newValue)
    {
        if (newValue)
        {
            // Si el Toggle 1 se activa, desactiva el Toggle 2
            toggle2.isOn = false;

        }
    }

    void OnToggle2Changed(bool newValue)
    {
        if (newValue)
        {
            // Si el Toggle 2 se activa, desactiva el Toggle 1
            toggle1.isOn = false;

        }
    }

    void OnToggle3Changed(bool newValue)
    {
        if (newValue)
        {
            // Si el Toggle 1 se activa, desactiva el Toggle 2
            toggle4.isOn = false;

        }
    }

    void OnToggle4Changed(bool newValue)
    {
        if (newValue)
        {
            // Si el Toggle 2 se activa, desactiva el Toggle 1
            toggle3.isOn = false;

        }
    }

    void OnToggle5Changed(bool newValue)
    {
        if (newValue)
        {
            // Si el Toggle 1 se activa, desactiva el Toggle 2
            toggle6.isOn = false;

        }
    }

    void OnToggle6Changed(bool newValue)
    {
        if (newValue)
        {
            // Si el Toggle 2 se activa, desactiva el Toggle 1
            toggle5.isOn = false;

        }
    }

    void OnToggle7Changed(bool newValue)
    {
        if (newValue)
        {
            // Si el Toggle 1 se activa, desactiva el Toggle 2
            toggle8.isOn = false;

        }
    }

    void OnToggle8Changed(bool newValue)
    {
        if (newValue)
        {
            // Si el Toggle 2 se activa, desactiva el Toggle 1
            toggle7.isOn = false;

        }
    }

    void OnToggle9Changed(bool newValue)
    {
        if (newValue)
        {
            // Si el Toggle 1 se activa, desactiva el Toggle 2
            toggle10.isOn = false;

        }
    }

    void OnToggle10Changed(bool newValue)
    {
        if (newValue)
        {
            // Si el Toggle 2 se activa, desactiva el Toggle 1
            toggle9.isOn = false;

        }
    }

    void OnToggle11Changed(bool newValue)
    {
        if (newValue)
        {
            // Si el Toggle 1 se activa, desactiva el Toggle 2
            toggle12.isOn = false;

        }
    }

    void OnToggle12Changed(bool newValue)
    {
        if (newValue)
        {
            // Si el Toggle 2 se activa, desactiva el Toggle 1
            toggle11.isOn = false;

        }
    }

    // La función para manejar los cambios en los toggles
    private void OnToggleChanged(Toggle changedToggle, bool newValue, int grupo)
    {
            if (isProcessingToggleChange) return;

        isProcessingToggleChange = true;
        // Determina qué lista de toggles activos se debe usar
        List<Toggle> grupoActivo = grupo == 1 ? togglesGrupo1Activos : togglesGrupo2Activos;
        List<Toggle> grupoActivoOpuesto = grupo == 1 ? togglesGrupo2Activos : togglesGrupo1Activos;
        Toggle toggleOpuesto = ObtenerToggleOpuesto(changedToggle);
        // Maneja los cambios en los toggles
        if (newValue)
        {
            // Si el toggle opuesto está activo, se desactiva y se ajusta en su grupo correspondiente
            if (toggleOpuesto != null && toggleOpuesto.isOn)
            {
                toggleOpuesto.isOn = false;
                grupoActivoOpuesto.Remove(toggleOpuesto);
            }

            // Asegura de no exceder el límite de 3 toggles activos
            if (grupoActivo.Count >= 3)
            {
                var toggleParaDesactivar = grupoActivo[0];
                toggleParaDesactivar.isOn = false;
                grupoActivo.RemoveAt(0);
            }

            // Agrega el nuevo toggle activo si aún no está en la lista
            if (!grupoActivo.Contains(changedToggle))
            {
                grupoActivo.Add(changedToggle);
            }
        }
        else
        {
            // Si el toggle es desactivado, simplemente se elimina de su lista correspondiente
            grupoActivo.Remove(changedToggle);
        }

        isProcessingToggleChange = false;
    }

    private Toggle ObtenerToggleOpuesto(Toggle toggle)
    {
        // Devuelve el toggle opuesto en función del nombre del toggle
        switch (toggle.name)
        {
            case "toggle1": return toggle2;
            case "toggle2": return toggle1;
            case "toggle3": return toggle4;
            case "toggle4": return toggle3;
            case "toggle5": return toggle6;
            case "toggle6": return toggle5;
            case "toggle7": return toggle8;
            case "toggle8": return toggle7;
            case "toggle9": return toggle10;
            case "toggle10": return toggle9;
            case "toggle11": return toggle12;
            case "toggle12": return toggle11;
            default: return null;
        }
    }
    // La función para calcular los puntos de selección
    private int puntosSeleccion() {
        int puntos = 0;
        if (toggle1.isOn){
            puntos += 5;
        }
        if (toggle3.isOn){
            puntos += 5;
        }
        if (toggle6.isOn){
            puntos += 5;
        }
        if (toggle8.isOn){
            puntos += 5;
        }
        if (toggle9.isOn){
            puntos += 5;
        }
        if (toggle12.isOn){
            puntos += 5;
        }
        return puntos;
    }

    private void OnToggleCoChanged(Toggle changedToggle, bool newValue)
    {
        if (isProcessingToggleChange) return;

        isProcessingToggleChange = true;

        if (newValue)
        {
            // Asegura de no exceder el límite de 2 toggles activos en el grupo de comunicación
            if (togglesGrupoComunicacionActivos.Count >= 3)
            {
                var toggleParaDesactivar = togglesGrupoComunicacionActivos[0];
                toggleParaDesactivar.isOn = false;
                togglesGrupoComunicacionActivos.RemoveAt(0);
            }

            // Agrega el nuevo toggle activo si aún no está en la lista
            if (!togglesGrupoComunicacionActivos.Contains(changedToggle))
            {
                togglesGrupoComunicacionActivos.Add(changedToggle);
            }
        }
        else
        {
            // Si el toggle es desactivado, simplemente se elimina de su lista correspondiente
            togglesGrupoComunicacionActivos.Remove(changedToggle);
        }

        isProcessingToggleChange = false;
    }

    // La función para calcular los puntos de comunicación
    private int puntosComunicacion() {
        int puntos = 0;
        if (toggleCo2.isOn){
            puntos += 10;
        }
        if (toggleCo4.isOn){
            puntos +=10;
        }
        if (toggleCo5.isOn){
            puntos +=10;
        }
        return puntos;
    }
}
