using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvanzarMision2 : MonoBehaviour
{
    private bool isPlayerNear = false;

    public string doorID;

    // Referencia al MissionManager
    private MisionManagerMision1 missionManager;

    void Start()
    {
        missionManager = MisionManagerMision1.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador está cerca de la puerta y pulsa la tecla E, se avanza en la misión
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador se aleja de la puerta, no se puede avanzar en la misión
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void Update()
    {
        // Si el jugador está cerca de la puerta y pulsa la tecla E, se avanza a la siguiente misión
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {  
            if (missionManager.GetCurrentMissionIndex() == 9)
            {
                missionManager.CompleteMission(doorID,2);
                SceneManager.LoadScene("Mision2");
            }
        }
        
    }
}
