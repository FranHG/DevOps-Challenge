using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DecisionFinal : MonoBehaviour
{
     public Canvas dialogueCanvas;
     public Button volverMenu;

     public TextMeshProUGUI textoNota;
     public TextMeshProUGUI textoPuntosTotales;
     public TextMeshProUGUI textoIntr;
     public TextMeshProUGUI textoMision1;
     public TextMeshProUGUI textoSeleccion;
     public TextMeshProUGUI textoComunicacion;
     public TextMeshProUGUI textoMision2;
     public TextMeshProUGUI textoAutomatizacion;
     public TextMeshProUGUI textoMision3;
     public TextMeshProUGUI textoFeedback;

     private VariablesScript variablesScript;

    void Start() {
        variablesScript = VariablesScript.instance;
        // Se muestra el cursor y se desbloquea
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        int puntuacionTotal= 255;
    
        volverMenu.onClick.AddListener(OnClickVolverMenu);
        // Se actualizan los textos con la puntuación obtenida en cada misión
        textoPuntosTotales.text = variablesScript.GetPuntuacionGlobal() + "/" + puntuacionTotal;
        textoIntr.text = variablesScript.GetPuntuacionIntro() + "/20";
        textoMision1.text = variablesScript.GetPuntuacion1Mision() + "/46";
        textoSeleccion.text = variablesScript.GetPuntuacionSeleccion() + "/30";
        textoComunicacion.text = variablesScript.GetPuntuacionComunicacion() + "/30";
        textoMision2.text = variablesScript.GetPuntuacion2Mision() + "/30";
        textoAutomatizacion.text = variablesScript.GetPuntuacionAutomatizacion() + "/35";
        textoMision3.text = variablesScript.GetPuntuacion3Mision() + "/34";
        textoFeedback.text = variablesScript.GetPuntuacionFeedback() + "/30";

        double porcentaje = (double)variablesScript.GetPuntuacionGlobal() / puntuacionTotal * 100;
        // Se muestra un mensaje diferente en función de la puntuación obtenida
        if (porcentaje >= 76){
            textoNota.text = "Enhorabuena";
        }else if (porcentaje >= 51) {
            textoNota.text = "Bien hecho";
        }else if (porcentaje >= 26) {
            textoNota.text = "Debes mejorar";
        }else {
            textoNota.text = "Necesitas un curso de formación";
        }

    }

    void OnClickVolverMenu() {
        SceneManager.LoadScene("MenuPrincipal"); 
    }
}
