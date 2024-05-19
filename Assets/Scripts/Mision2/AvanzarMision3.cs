using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvanzarMision3 : MonoBehaviour
{
    private bool isPlayerNear = false;

    public string doorID;

    // Referencia al MissionManager
    private MisionManagerMision2 missionManager;

    void Start()
    {
        missionManager = MisionManagerMision2.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador está cerca de la puerta y pulsa la tecla E
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador se aleja de la puerta
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void Update()
    {
        // Si el jugador está cerca de la puerta y pulsa la tecla E
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        { 
            // Se avanza a la siguiente misión 
            if (missionManager.GetCurrentMissionIndex() == 5)
            {
                missionManager.CompleteMission(doorID,2);
                SceneManager.LoadScene("Mision3");
            }
        }
        
    }
}
