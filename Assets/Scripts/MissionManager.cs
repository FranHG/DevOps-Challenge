using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;
    public TextMeshProUGUI missionText;
    public TextMeshProUGUI missionProgressText;
    public Canvas missionCanvas;

    public string[] npcIDs;
    public string[] missions;
    private int currentMissionIndex = -1;

    private VariablesScript variablesScript;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        variablesScript = VariablesScript.instance;

        missionCanvas.gameObject.SetActive(true);
        missionProgressText.text = "Puntuación: " +  variablesScript.GetPuntuacionGlobal();
        StartMission();
    }

    void StartMission()
    {
        currentMissionIndex++;
        // Se comprueba si hay más misiones
        if (currentMissionIndex < missions.Length)
        {
            missionText.text = missions[currentMissionIndex];
        }
        else
        {
            Debug.Log("All missions completed!");
        }
    }

    public void CompleteMission(string npcID)
    {
        // Se comprueba si hay más misiones y si el ID del NPC coincide con el de la misión actual
        if (currentMissionIndex < missions.Length)
        {
            if (npcID == npcIDs[currentMissionIndex])
            {
                // Se incrementa la puntuación global y la puntuación de la introducción
                variablesScript.SetPuntuacionGlobal(variablesScript.GetPuntuacionGlobal()+2);
                variablesScript.SetPuntuacionIntro(variablesScript.GetPuntuacionIntro()+2);

                if (currentMissionIndex == missions.Length-1)
                {
                    missionText.text = string.Empty; //Ya no hay misiones
                }
                // Se actualiza el texto de la puntuación y se inicia la siguiente misión
                missionProgressText.text = "Puntuación: " + variablesScript.GetPuntuacionGlobal();
                StartMission();
            }
        }
    }
    
    // Método para obtener el índice de la misión actual
    public int GetCurrentMissionIndex()
    {
        return currentMissionIndex;
    }
}
               