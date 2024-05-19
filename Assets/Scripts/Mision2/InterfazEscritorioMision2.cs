using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfazEscritorioMision2 : MonoBehaviour
{
    public Canvas canvasInterfaz;
    public float distanciaActivacion = 3f; // Distancia a la que se activará la interfaz
    private bool estaCerca = false;
    private bool interfazActivada = false;

    public Button botonCerrar;
    public Button botonAutomatizacion;
    public Button botonMetricas;
    public Button volverAutomatizacion;
    public Button volverMetricas;
    public Button confirmarAutomatizacion;
    public Button confirmarSi;
    public Button confirmarNo;

    public Button Fase1;
    public Button Fase2;
    public Button Fase3;
    public Button Fase4;
    public Button Fase5;
    public Button Fase6;
    public Button Fase7;
    public Button Fase8;

    public Button botonVolverFase1;
    public Button botonVolverFase2;
    public Button botonVolverFase3;
    public Button botonVolverFase4;
    public Button botonVolverFase5;
    public Button botonVolverFase6;
    public Button botonVolverFase7;
    public Button botonVolverFase8;

    public Button botonMetricaSeleccion;
    public Button botonMetricaComunicacion;
    public Button botonMetricaAutomatizacion;
    public Button botonMetricaFeedback;

    public Button botonVolverMetricaSeleccion;
    public Button botonVolverMetricaComunicacion;
    public Button botonVolverMetricaAutomatizacion;
    public Button botonVolverMetricaFeedback;

    public GameObject menuAutomatizacion;
    public GameObject menuMetricas;
    public GameObject avisoConfirmacion;
    public GameObject infFase1;
    public GameObject infFase2;
    public GameObject infFase3;
    public GameObject infFase4;
    public GameObject infFase5;
    public GameObject infFase6;
    public GameObject infFase7;
    public GameObject infFase8;

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
    public GameObject graficoPreAu;
    public GameObject grafico1Au;
    public GameObject grafico2Au;
    public GameObject grafico3Au;
    public GameObject grafico4Au;
    public GameObject grafico5Au;
    public GameObject grafico6Au;
    public GameObject grafico7Au;
    public GameObject grafico8Au;
    public GameObject grafico9Au;
    public GameObject grafico10Au;
    public GameObject grafico11Au;
    public GameObject grafico12Au;
    public GameObject grafico13Au;
    public GameObject grafico14Au;
    public GameObject grafico15Au;
    public GameObject grafico16Au;

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

    private List<Toggle> togglesActivos = new List<Toggle>();

    // Bloquea temporalmente la adición de nuevos toggles mientras se procesa un cambio
    private bool isProcessingToggleChange = false;

    // Referencia al MissionManager
    private MisionManagerMision2 missionManager;
    private VariablesScript variablesScript;

    private void Start()
    {
        // Desactiva la interfaz al inicio
        canvasInterfaz.gameObject.SetActive(false);

        missionManager = MisionManagerMision2.instance;
        variablesScript = VariablesScript.instance;
        // Asignar los métodos a los botones
        botonCerrar.onClick.AddListener(CerrarInterfaz);
        botonAutomatizacion.onClick.AddListener(onClickAutomatizacion);
        botonMetricas.onClick.AddListener(onClickMetricas);
        volverAutomatizacion.onClick.AddListener(onClickVolverAutomatizacion);
        volverMetricas.onClick.AddListener(OnClickVolverMetricas);
        confirmarAutomatizacion.onClick.AddListener(onClickConfirmarAutomatizacion);
        confirmarSi.onClick.AddListener(onClickConfirmarSi);
        confirmarNo.onClick.AddListener(onClickConfirmarNo);

        Fase1.onClick.AddListener(onClickFase1);
        Fase2.onClick.AddListener(onClickFase2);
        Fase3.onClick.AddListener(onClickFase3);
        Fase4.onClick.AddListener(onClickFase4);
        Fase5.onClick.AddListener(onClickFase5);
        Fase6.onClick.AddListener(onClickFase6);
        Fase7.onClick.AddListener(onClickFase7);
        Fase8.onClick.AddListener(onClickFase8);

        botonVolverFase1.onClick.AddListener(onClickVolverFase1);
        botonVolverFase2.onClick.AddListener(onClickVolverFase2);
        botonVolverFase3.onClick.AddListener(onClickVolverFase3);
        botonVolverFase4.onClick.AddListener(onClickVolverFase4);
        botonVolverFase5.onClick.AddListener(onClickVolverFase5);
        botonVolverFase6.onClick.AddListener(onClickVolverFase6);
        botonVolverFase7.onClick.AddListener(onClickVolverFase7);
        botonVolverFase8.onClick.AddListener(onClickVolverFase8);

        botonMetricaSeleccion.onClick.AddListener(OnClickMetricaSeleccion);
        botonMetricaComunicacion.onClick.AddListener(OnclickMetricaComunicacion);
        botonMetricaAutomatizacion.onClick.AddListener(OnclickMetricaAutomatizacion);
        botonMetricaFeedback.onClick.AddListener(OnclickMetricaFeedback);

        botonVolverMetricaSeleccion.onClick.AddListener(OnClickVolverMetricaSeleccion);
        botonVolverMetricaComunicacion.onClick.AddListener(OnClickVolverMetricaComunicacion);
        botonVolverMetricaAutomatizacion.onClick.AddListener(OnClickVolverMetricaAutomatizacion);
        botonVolverMetricaFeedback.onClick.AddListener(OnClickVolverMetricaFeedback);
        // Asignar los métodos a los toggles
        toggle1.onValueChanged.AddListener((value) => OnToggleChanged(toggle1, value));
        toggle2.onValueChanged.AddListener((value) => OnToggleChanged(toggle2, value));
        toggle3.onValueChanged.AddListener((value) => OnToggleChanged(toggle3, value));
        toggle4.onValueChanged.AddListener((value) => OnToggleChanged(toggle4, value));
        toggle5.onValueChanged.AddListener((value) => OnToggleChanged(toggle5, value));
        toggle6.onValueChanged.AddListener((value) => OnToggleChanged(toggle6, value));
        toggle7.onValueChanged.AddListener((value) => OnToggleChanged(toggle7, value));
        toggle8.onValueChanged.AddListener((value) => OnToggleChanged(toggle8, value));
        // Desactivar todos los elementos de la interfaz inicialmente
        menuAutomatizacion.SetActive(false);
        menuMetricas.SetActive(false);
        avisoConfirmacion.SetActive(false);
        infFase1.SetActive(false);
        infFase2.SetActive(false);
        infFase3.SetActive(false);
        infFase4.SetActive(false);
        infFase5.SetActive(false);
        infFase6.SetActive(false);
        infFase7.SetActive(false);
        infFase8.SetActive(false);
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
        graficoPreAu.SetActive(false);
        grafico1Au.SetActive(false);
        grafico2Au.SetActive(false);
        grafico3Au.SetActive(false);
        grafico4Au.SetActive(false);
        grafico5Au.SetActive(false);
        grafico6Au.SetActive(false);
        grafico7Au.SetActive(false);
        grafico8Au.SetActive(false);
        grafico9Au.SetActive(false);
        grafico10Au.SetActive(false);
        grafico11Au.SetActive(false);
        grafico12Au.SetActive(false);
        grafico13Au.SetActive(false);
        grafico14Au.SetActive(false);
        grafico15Au.SetActive(false);
        grafico16Au.SetActive(false);
        graficoFd.SetActive(false);

        grafico = graficoPre;
        graficoCo = graficoPreCo;
        graficoAu = graficoPreAu;
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
            
            if (missionManager.GetCurrentMissionIndex() == 2){
                botonAutomatizacion.interactable = true;
            } else {
                botonAutomatizacion.interactable = false;
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

            // Bloquea el cursor nuevamente al salir de la interfaz
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void onClickAutomatizacion() {
        menuAutomatizacion.SetActive(true);
        volverAutomatizacion.interactable = true;
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
        int puntuacion = variablesScript.GetPuntuacionSeleccion();
        // Dependiendo de la puntuación, se activa un gráfico u otro
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
    

    void OnclickMetricaComunicacion() {
        menuMetricaComunicacion.SetActive(true);
        botonVolverMetricaComunicacion.interactable = true;
        menuMetricas.SetActive(false);
        int ngrafico = variablesScript.GetGraficoComunicacion();
        // Dependiendo del gráfico seleccionado, se activa un gráfico u otro
        switch (ngrafico)
        {
            case 1:
                graficoCo = grafico1Co;
                break;
            case 2:
                graficoCo = grafico2Co;
                break;
            case 3:
                graficoCo = grafico3Co;
                break;
            case 4:
                graficoCo = grafico4Co;
                break;
            case 5:
                graficoCo = grafico5Co;
                break;
            case 6:
                graficoCo = grafico6Co;
                break;
            case 7:
                graficoCo = grafico7Co;
                break;
            case 8:
                graficoCo = grafico8Co;
                break;   
            }
            graficoCo.SetActive(true);
    }

    void OnclickMetricaAutomatizacion() {
        menuMetricasAutomatizacion.SetActive(true);
        botonVolverMetricaAutomatizacion.interactable = true;
        menuMetricas.SetActive(false);
        int puntuacion = variablesScript.GetPuntuacionAutomatizacion();
        // Dependiendo de la puntuación, se activa un gráfico u otro
        if (missionManager.GetCurrentMissionIndex() < 3) {
            graficoAu.SetActive(true);
        } else {
            switch(puntuacion) 
            {
                case 0:
                    graficoAu = grafico1Au;
                    variablesScript.SetGraficoAutomatizacion(1);
                    break;
                case 5:
                    if (toggle3.isOn){
                        graficoAu = grafico2Au;
                        variablesScript.SetGraficoAutomatizacion(2);
                    } else if (toggle4.isOn) {
                        graficoAu = grafico3Au;
                        variablesScript.SetGraficoAutomatizacion(3);
                    } else if (toggle5.isOn) {
                        graficoAu = grafico4Au;
                        variablesScript.SetGraficoAutomatizacion(4);
                    } else /*toggle7*/{
                        graficoAu = grafico5Au;
                        variablesScript.SetGraficoAutomatizacion(5);
                    }
                    break;
                case 10:
                    if(toggle3.isOn && toggle4.isOn){
                        graficoAu = grafico6Au;
                        variablesScript.SetGraficoAutomatizacion(6);
                    } else if (toggle3.isOn && toggle5.isOn){
                        graficoAu = grafico7Au;
                        variablesScript.SetGraficoAutomatizacion(7);
                    } else if (toggle3.isOn && toggle7.isOn){
                        graficoAu = grafico8Au;
                        variablesScript.SetGraficoAutomatizacion(8);
                    } else if (toggle4.isOn && toggle5.isOn) {
                        graficoAu = grafico9Au;
                        variablesScript.SetGraficoAutomatizacion(9);
                    } else if (toggle4.isOn && toggle7.isOn) {
                        graficoAu = grafico10Au;
                        variablesScript.SetGraficoAutomatizacion(10);
                    } else if (toggle5.isOn && toggle7.isOn) {
                        graficoAu = grafico11Au;
                        variablesScript.SetGraficoAutomatizacion(11);
                    }
                    break;
                case 20:
                    if(toggle3.isOn && toggle4.isOn && toggle5.isOn){
                        graficoAu = grafico12Au;
                        variablesScript.SetGraficoAutomatizacion(12);
                    } else if(toggle3.isOn && toggle4.isOn && toggle7.isOn) {
                        graficoAu = grafico13Au;
                        variablesScript.SetGraficoAutomatizacion(13);
                    } else if(toggle3.isOn && toggle5.isOn && toggle7.isOn) {
                        graficoAu = grafico14Au;
                        variablesScript.SetGraficoAutomatizacion(14);
                    } else if(toggle4.isOn && toggle5.isOn && toggle7.isOn) {
                        graficoAu = grafico14Au;
                        variablesScript.SetGraficoAutomatizacion(15);
                    }
                    break;
                case 35:
                    graficoAu = grafico16Au;
                    break;
            }
            graficoAu.SetActive(true);
        }
    }

    void OnclickMetricaFeedback() {
        menuMetricaFeedback.SetActive(true);
        botonVolverMetricaFeedback.interactable = true;
        menuMetricas.SetActive(false);
        graficoFd.SetActive(true);
    }

    void onClickVolverAutomatizacion() {
        menuAutomatizacion.SetActive(false);
        volverAutomatizacion.interactable = false;
        botonMetricas.gameObject.SetActive(true);
    }

    void OnClickVolverMetricas() {
        menuMetricas.SetActive(false);
            if (missionManager.GetCurrentMissionIndex() == 4) {
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

    void onClickConfirmarAutomatizacion() {
        avisoConfirmacion.SetActive(true);
        volverAutomatizacion.interactable = false;
        confirmarAutomatizacion.interactable = false;
    }

    void onClickConfirmarSi() {
        menuAutomatizacion.SetActive(false);
        avisoConfirmacion.SetActive(false);
        volverAutomatizacion.interactable = false;
        botonAutomatizacion.interactable = false;
        int puntos = puntosAutomatizacion();
        missionManager.CompleteMission(computerID,puntos);
        botonMetricas.gameObject.SetActive(true);
    }

    void onClickConfirmarNo() {
        avisoConfirmacion.SetActive(false);
        volverAutomatizacion.interactable = true;
        confirmarAutomatizacion.interactable = true;
    }

    void onClickFase1() {
        infFase1.SetActive(true);
    }

    void onClickFase2() {
        infFase2.SetActive(true);
    }

    void onClickFase3() {
        infFase3.SetActive(true);
    }

    void onClickFase4() {
        infFase4.SetActive(true);
    }

    void onClickFase5() {
        infFase5.SetActive(true);
    }

    void onClickFase6() {
        infFase6.SetActive(true);
    }

    void onClickFase7() {
        infFase7.SetActive(true);
    }

    void onClickFase8() {
        infFase8.SetActive(true);
    }

    void onClickVolverFase1() {
        infFase1.SetActive(false);
    }

    void onClickVolverFase2() {
        infFase2.SetActive(false);
    }

    void onClickVolverFase3() {
        infFase3.SetActive(false);
    }

    void onClickVolverFase4() {
        infFase4.SetActive(false);
    }

    void onClickVolverFase5() {
        infFase5.SetActive(false);
    }

    void onClickVolverFase6() {
        infFase6.SetActive(false);
    }

    void onClickVolverFase7() {
        infFase7.SetActive(false);
    }

    void onClickVolverFase8() {
        infFase8.SetActive(false);
    }

    private int puntosAutomatizacion() {
        int n=0;
        // Contar cuántos toggles están activos
        if (toggle3.isOn){
            n += 1;
        }
        if (toggle4.isOn){
            n += 1;
        }
        if (toggle5.isOn){
            n += 1;
        }
        if (toggle7.isOn){
            n += 1;
        }
        int puntos = 0;
        // Asignar puntos según el número de toggles activos
        switch (n)
        {
            case 1:
                puntos = 5;
                break;
            case 2:
                puntos = 10;
                break;
            case 3:
                puntos = 20;
                break;
            case 4:
                puntos = 35;
                break;
            default:
                puntos = 0;
                break;
        }
        return puntos;
    }

    private void OnToggleChanged(Toggle changedToggle, bool newValue)
    {
        if (isProcessingToggleChange) return;

        isProcessingToggleChange = true;

        if (newValue)
        {
            // Asegura de no exceder el límite de 4 toggles activos en el grupo
            if (togglesActivos.Count >= 4)
            {
                var toggleParaDesactivar = togglesActivos[0];
                toggleParaDesactivar.isOn = false;
                togglesActivos.RemoveAt(0);
            }

            // Agrega el nuevo toggle activo si aún no está en la lista
            if (!togglesActivos.Contains(changedToggle))
            {
                togglesActivos.Add(changedToggle);
            }
        }
        else
        {
            // Si el toggle es desactivado, simplemente remuévelo de su lista correspondiente
            togglesActivos.Remove(changedToggle);
        }

        isProcessingToggleChange = false;
    }

}
