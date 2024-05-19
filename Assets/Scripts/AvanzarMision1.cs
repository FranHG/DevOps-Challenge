using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvanzarMision1 : MonoBehaviour
{
    // Variable para saber si el jugador está cerca del objeto
    private bool isPlayerNear = false;
     
    // ID de la puerta
    public string doorID;

    // Referencia al MissionManager
    private MissionManager missionManager;

    void Start()
    {
        missionManager = MissionManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Se comprueba si el jugador está cerca del objeto
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Se comprueba si el jugador se aleja del objeto
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void Update()
    {
        //Si el jugador está cerca y presiona la tecla E
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {  
            // Comprueba si la misión actual es la 9 para hacer su tratamiento específico
            if (missionManager.GetCurrentMissionIndex() == 9)
            { 
                missionManager.CompleteMission(doorID);

                // Cambia a otra escena cuando se presiona E
                SceneManager.LoadScene("Mision1");
            }
        }
        
    }
}
