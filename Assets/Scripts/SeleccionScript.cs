using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionScript : MonoBehaviour
{
    public GameObject personaje1;
    public GameObject personaje2;

    private VariablesScript variablesScript;

    void Start()
    {
        // Se obtiene el tipo de jugador seleccionado
        variablesScript = VariablesScript.instance;
        int personaje = variablesScript.GetTipoJugador();
        // Se activa el personaje seleccionado por el usuario en el menú de selección
        if (personaje == 1){
            personaje1.SetActive(true);
            personaje2.SetActive(false);
        } else {
            personaje1.SetActive(false);
            personaje2.SetActive(true);
        }
    }
}
