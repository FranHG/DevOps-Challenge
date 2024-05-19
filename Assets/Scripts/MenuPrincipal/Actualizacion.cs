using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actualizacion : MonoBehaviour
{

    private VariablesScript variablesScript;

    void Start()
    {
        // Se inicializan las variables globales de nuevo para cada partida
        variablesScript = VariablesScript.instance;
        variablesScript.SetPuntuacionGlobal(0);
        variablesScript.SetPuntuacionIntro(0);
        variablesScript.SetPuntuacion1Mision(0);
        variablesScript.SetPuntuacionSeleccion(0);
        variablesScript.SetPuntuacionComunicacion(0);
        variablesScript.SetPuntuacion2Mision(0);
        variablesScript.SetPuntuacionAutomatizacion(0);
        variablesScript.SetPuntuacionFeedback(0);
        variablesScript.SetPuntuacion3Mision(0);
    }

}
