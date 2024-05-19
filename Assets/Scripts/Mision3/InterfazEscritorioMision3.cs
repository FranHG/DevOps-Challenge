using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfazEscritorioMision3 : MonoBehaviour
{
    public Canvas canvasInterfaz;
    public float distanciaActivacion = 3f; // Distancia a la que se activará la interfaz
    private bool estaCerca = false;
    private bool interfazActivada = false;

    public Button botonCerrar;
    public Button botonFeedback;
    public Button botonMetricas;
    public Button volverFeedback;
    public Button volverMetricas;
    public Button confirmarFeedback;
    public Button confirmarSi;
    public Button confirmarNo;

    public Button Feedback1;
    public Button Feedback2;
    public Button Feedback3;
    public Button Feedback4;
    public Button Feedback5;
    public Button Feedback6;
    public Button Feedback7;
    public Button Feedback8;
    public Button Feedback9;

    public Button botonVolverFeedback1;
    public Button botonVolverFeedback2;
    public Button botonVolverFeedback3;
    public Button botonVolverFeedback4;
    public Button botonVolverFeedback5;
    public Button botonVolverFeedback6;
    public Button botonVolverFeedback7;
    public Button botonVolverFeedback8;
    public Button botonVolverFeedback9;

    public Button botonMetricaSeleccion;
    public Button botonMetricaComunicacion;
    public Button botonMetricaAutomatizacion;
    public Button botonMetricaFeedback;

    public Button botonVolverMetricaSeleccion;
    public Button botonVolverMetricaComunicacion;
    public Button botonVolverMetricaAutomatizacion;
    public Button botonVolverMetricaFeedback;

    public GameObject menuFeedback;
    public GameObject menuMetricas;
    public GameObject avisoConfirmacion;
    public GameObject infFeedback1;
    public GameObject infFeedback2;
    public GameObject infFeedback3;
    public GameObject infFeedback4;
    public GameObject infFeedback5;
    public GameObject infFeedback6;
    public GameObject infFeedback7;
    public GameObject infFeedback8;
    public GameObject infFeedback9;

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
    public GameObject graficoPreFd;
    public GameObject grafico1Fd;
    public GameObject grafico2Fd;
    public GameObject grafico3Fd;
    public GameObject grafico4Fd;
    public GameObject grafico5Fd;
    public GameObject grafico6Fd;
    public GameObject grafico7Fd;
    public GameObject grafico8Fd;

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

    private List<Toggle> togglesActivos = new List<Toggle>();

    // Bloquea temporalmente la adición de nuevos toggles mientras se procesa un cambio
    private bool isProcessingToggleChange = false;

    // Referencia al MissionManager
    private MisionManagerMision3 missionManager;
    private VariablesScript variablesScript;

    private void Start()
    {
        // Desactiva la interfaz al inicio
        canvasInterfaz.gameObject.SetActive(false);

        missionManager = MisionManagerMision3.instance;
        variablesScript = VariablesScript.instance;
    
        botonCerrar.onClick.AddListener(CerrarInterfaz);
        botonFeedback.onClick.AddListener(onClickFeedback);
        botonMetricas.onClick.AddListener(onClickMetricas);
        volverFeedback.onClick.AddListener(onClickvolverFeedback);
        volverMetricas.onClick.AddListener(OnClickVolverMetricas);
        confirmarFeedback.onClick.AddListener(onClickconfirmarFeedback);
        confirmarSi.onClick.AddListener(onClickConfirmarSi);
        confirmarNo.onClick.AddListener(onClickConfirmarNo);

        Feedback1.onClick.AddListener(onClickFeedback1);
        Feedback2.onClick.AddListener(onClickFeedback2);
        Feedback3.onClick.AddListener(onClickFeedback3);
        Feedback4.onClick.AddListener(onClickFeedback4);
        Feedback5.onClick.AddListener(onClickFeedback5);
        Feedback6.onClick.AddListener(onClickFeedback6);
        Feedback7.onClick.AddListener(onClickFeedback7);
        Feedback8.onClick.AddListener(onClickFeedback8);
        Feedback9.onClick.AddListener(onClickFeedback9);
        
        botonVolverFeedback1.onClick.AddListener(onClickVolverFeedback1);
        botonVolverFeedback2.onClick.AddListener(onClickVolverFeedback2);
        botonVolverFeedback3.onClick.AddListener(onClickVolverFeedback3);
        botonVolverFeedback4.onClick.AddListener(onClickVolverFeedback4);
        botonVolverFeedback5.onClick.AddListener(onClickVolverFeedback5);
        botonVolverFeedback6.onClick.AddListener(onClickVolverFeedback6);
        botonVolverFeedback7.onClick.AddListener(onClickVolverFeedback7);
        botonVolverFeedback8.onClick.AddListener(onClickVolverFeedback8);
        botonVolverFeedback9.onClick.AddListener(onClickVolverFeedback9);

        botonMetricaSeleccion.onClick.AddListener(OnClickMetricaSeleccion);
        botonMetricaComunicacion.onClick.AddListener(OnclickMetricaComunicacion);
        botonMetricaAutomatizacion.onClick.AddListener(OnclickMetricaAutomatizacion);
        botonMetricaFeedback.onClick.AddListener(OnclickMetricaFeedback);

        botonVolverMetricaSeleccion.onClick.AddListener(OnClickVolverMetricaSeleccion);
        botonVolverMetricaComunicacion.onClick.AddListener(OnClickVolverMetricaComunicacion);
        botonVolverMetricaAutomatizacion.onClick.AddListener(OnClickVolverMetricaAutomatizacion);
        botonVolverMetricaFeedback.onClick.AddListener(OnClickVolverMetricaFeedback);
        // Asignar los eventos de cambio de estado a los toggles
        toggle1.onValueChanged.AddListener((value) => OnToggleChanged(toggle1, value));
        toggle2.onValueChanged.AddListener((value) => OnToggleChanged(toggle2, value));
        toggle3.onValueChanged.AddListener((value) => OnToggleChanged(toggle3, value));
        toggle4.onValueChanged.AddListener((value) => OnToggleChanged(toggle4, value));
        toggle5.onValueChanged.AddListener((value) => OnToggleChanged(toggle5, value));
        toggle6.onValueChanged.AddListener((value) => OnToggleChanged(toggle6, value));
        toggle7.onValueChanged.AddListener((value) => OnToggleChanged(toggle7, value));
        toggle8.onValueChanged.AddListener((value) => OnToggleChanged(toggle8, value));
        toggle9.onValueChanged.AddListener((value) => OnToggleChanged(toggle9, value));
        // Las interfaces estan desactivadas al inicio
        menuFeedback.SetActive(false);
        menuMetricas.SetActive(false);
        avisoConfirmacion.SetActive(false);
        infFeedback1.SetActive(false);
        infFeedback2.SetActive(false);
        infFeedback3.SetActive(false);
        infFeedback4.SetActive(false);
        infFeedback5.SetActive(false);
        infFeedback6.SetActive(false);
        infFeedback7.SetActive(false);
        infFeedback8.SetActive(false);
        infFeedback9.SetActive(false);
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
        graficoPreFd.SetActive(false);
        grafico1Fd.SetActive(false);
        grafico2Fd.SetActive(false);
        grafico3Fd.SetActive(false);
        grafico4Fd.SetActive(false);
        grafico5Fd.SetActive(false);
        grafico6Fd.SetActive(false);
        grafico7Fd.SetActive(false);
        grafico8Fd.SetActive(false);

        grafico = graficoPre;
        graficoCo = graficoPreCo;
        graficoAu = graficoPreAu;
        graficoFd = graficoPreFd;
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
            // Se activan los toggles dependiendo de la misión actual
            if (missionManager.GetCurrentMissionIndex() == 4){
                toggle1.gameObject.SetActive(true);
                toggle2.gameObject.SetActive(true);
                toggle3.gameObject.SetActive(true);
                toggle4.gameObject.SetActive(true);
                toggle5.gameObject.SetActive(true);
                toggle6.gameObject.SetActive(true);
                toggle7.gameObject.SetActive(true);
                toggle8.gameObject.SetActive(true);
                toggle9.gameObject.SetActive(true);
            } else {
                toggle1.gameObject.SetActive(false);
                toggle2.gameObject.SetActive(false);
                toggle3.gameObject.SetActive(false);
                toggle4.gameObject.SetActive(false);
                toggle5.gameObject.SetActive(false);
                toggle6.gameObject.SetActive(false);
                toggle7.gameObject.SetActive(false);
                toggle8.gameObject.SetActive(false);
                toggle9.gameObject.SetActive(false);
            }
            // Se desactiva el botón de confirmar feedback si no se ha completado la misión 4
            if(missionManager.GetCurrentMissionIndex() != 4){
                confirmarFeedback.interactable = false;
            }else{
                confirmarFeedback.interactable = true;
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

    void onClickFeedback() {
        menuFeedback.SetActive(true);
        volverFeedback.interactable = true;
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
        // Dependiendo de la puntuación obtenida se muestra un gráfico u otro
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
        // Dependiendo del gráfico seleccionado se muestra uno u otro
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
        int ngrafico = variablesScript.GetGraficoAutomatizacion();
        // Dependiendo del gráfico seleccionado se muestra uno u otro
        switch (ngrafico)
        {
            case 1:
                graficoAu = grafico1Au;
                break;
            case 2:
                graficoAu = grafico2Au;
                break;
            case 3:
                graficoAu = grafico3Au;
                break;
            case 4:
                graficoAu = grafico4Au;
                break;
            case 5:
                graficoAu = grafico5Au;
                break;
            case 6:
                graficoAu = grafico6Au;
                break;
            case 7:
                graficoAu = grafico7Au;
                break;
            case 8:
                graficoAu = grafico8Au;
                break; 
            case 9:
                graficoAu = grafico9Au;
                break; 
            case 10:
                graficoAu = grafico10Au;
                break; 
            case 11:
                graficoAu = grafico11Au;
                break; 
            case 12:
                graficoAu = grafico12Au;
                break; 
            case 13:
                graficoAu = grafico13Au;
                break; 
            case 14:
                graficoAu = grafico14Au;
                break; 
            case 15:
                graficoAu = grafico15Au;
                break; 
            case 16:
                graficoAu = grafico16Au;
                break;    
            }
            graficoAu.SetActive(true);
    }

    void OnclickMetricaFeedback() {
        menuMetricaFeedback.SetActive(true);
        botonVolverMetricaFeedback.interactable = true;
        menuMetricas.SetActive(false);
        int puntuacion = variablesScript.GetPuntuacionFeedback();
        // Dependiendo de la puntuación y los toggles activos se muestra un gráfico u otro
        if (missionManager.GetCurrentMissionIndex() < 5) {
            graficoFd.SetActive(true);
        } else {
            switch(puntuacion)
            {
                case 0:
                    graficoFd = grafico1Fd;
                    variablesScript.SetGraficoFeedback(1);
                    break;
                case 5:
                    if (toggle1.isOn){
                        graficoFd = grafico2Fd;
                        variablesScript.SetGraficoFeedback(2);
                    } else if(toggle4.isOn) {
                        graficoFd = grafico3Fd;
                        variablesScript.SetGraficoFeedback(3);
                    } else /*toggle9*/ {
                        graficoFd = grafico4Fd;
                        variablesScript.SetGraficoFeedback(4);
                    }
                    break;
                case 15:
                    if(toggle1.isOn && toggle4.isOn) {
                        graficoFd = grafico5Fd;
                        variablesScript.SetGraficoFeedback(5);
                    } else if(toggle1.isOn && toggle9.isOn) {
                        graficoFd = grafico6Fd;
                        variablesScript.SetGraficoFeedback(6);
                    } else if(toggle4.isOn && toggle9.isOn) {
                        graficoFd = grafico7Fd;
                        variablesScript.SetGraficoFeedback(7);
                    }
                    break;
                case 30:
                    graficoFd = grafico8Fd;
                    variablesScript.SetGraficoFeedback(8);
                    break;
            }
            graficoFd.SetActive(true);
        }
    }

    void onClickvolverFeedback() {
        menuFeedback.SetActive(false);
        volverFeedback.interactable = false;
        botonMetricas.gameObject.SetActive(true);
        if (missionManager.GetCurrentMissionIndex() == 2) {
                missionManager.CompleteMission(computerID,2);
            }
    }

    void OnClickVolverMetricas() {
        menuMetricas.SetActive(false);
        if (missionManager.GetCurrentMissionIndex() == 6) {
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

    void onClickconfirmarFeedback() {
        avisoConfirmacion.SetActive(true);
        volverFeedback.interactable = false;
        confirmarFeedback.interactable = false;
    }

    void onClickConfirmarSi() {
        menuFeedback.SetActive(false);
        avisoConfirmacion.SetActive(false);
        volverFeedback.interactable = false;
        botonFeedback.interactable = false;
        int puntos = puntosFeedback();
        missionManager.CompleteMission(computerID,puntos);
        botonMetricas.gameObject.SetActive(true);
    }

    void onClickConfirmarNo() {
        avisoConfirmacion.SetActive(false);
        volverFeedback.interactable = true;
        confirmarFeedback.interactable = true;
    }

    void onClickFeedback1() {
        infFeedback1.SetActive(true);
    }

    void onClickFeedback2() {
        infFeedback2.SetActive(true);
    }

    void onClickFeedback3() {
        infFeedback3.SetActive(true);
    }

    void onClickFeedback4() {
        infFeedback4.SetActive(true);
    }

    void onClickFeedback5() {
        infFeedback5.SetActive(true);
    }

    void onClickFeedback6() {
        infFeedback6.SetActive(true);
    }

    void onClickFeedback7() {
        infFeedback7.SetActive(true);
    }

    void onClickFeedback8() {
        infFeedback8.SetActive(true);
    }

    void onClickFeedback9() {
        infFeedback9.SetActive(true);
    }

    void onClickVolverFeedback1() {
        infFeedback1.SetActive(false);
    }

    void onClickVolverFeedback2() {
        infFeedback2.SetActive(false);
    }

    void onClickVolverFeedback3() {
        infFeedback3.SetActive(false);
    }

    void onClickVolverFeedback4() {
        infFeedback4.SetActive(false);
    }

    void onClickVolverFeedback5() {
        infFeedback5.SetActive(false);
    }

    void onClickVolverFeedback6() {
        infFeedback6.SetActive(false);
    }

    void onClickVolverFeedback7() {
        infFeedback7.SetActive(false);
    }

    void onClickVolverFeedback8() {
        infFeedback8.SetActive(false);
    }

    void onClickVolverFeedback9() {
        infFeedback9.SetActive(false);
    }

    private int puntosFeedback() {
        int n=0;
        // Dependiendo de los toggles activos se asigna una puntuación
        if (toggle1.isOn){
            n += 1;
        }
        if (toggle4.isOn){
            n += 1;
        }
        if (toggle9.isOn){
            n += 1;
        }
        int puntos = 0;
        switch (n)
        {
            case 1:
                puntos = 5;
                break;
            case 2:
                puntos = 15;
                break;
            case 3:
                puntos = 30;
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
            // Asegura de no exceder el límite de 3 toggles activos en el grupo
            if (togglesActivos.Count >= 3)
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
