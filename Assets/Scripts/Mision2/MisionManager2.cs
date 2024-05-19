using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MisionManagerMision2 : MonoBehaviour
{
    public static MisionManagerMision2 instance; // Singleton instance
    public TextMeshProUGUI missionText;
    public TextMeshProUGUI missionProgressText;
    public Canvas missionCanvas;

    public string[] npcIDs;
    // Misiones principales
    public string[] missions;
    // Misiones opcionales
    public string[] optionalMissions1;
    public string[] optionalMissions2;
    // NPCs asociados a misiones opcionales
    public string[] optionalNPCs1;
    public string[] optionalNPCs2; 
    // Misiones opcionales completadas
    private List<string> completedOptionalMissions1 = new List<string>();
    private List<string> completedOptionalMissions2 = new List<string>();

    private int opcional1 = 0;
    private int opcional2 = 0;

    private int currentMissionIndex = 0;

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

        missionCanvas.gameObject.SetActive(true); // Always keep the canvas active
        missionProgressText.text = "Puntuación: " +  variablesScript.GetPuntuacionGlobal();
        StartMission(); // Start the first mission
    }

    void StartMission()
    {
        // Si hay misiones por completar
        if (currentMissionIndex < missions.Length)
        {
            missionText.text = missions[currentMissionIndex];

            // Verificar si hay misiones opcionales por completar y se inician
            if (currentMissionIndex == 2 && completedOptionalMissions1.Count < optionalMissions1.Length)
            {
                StartOptionalMission(optionalMissions1, completedOptionalMissions1, optionalNPCs1);
            }

            if (currentMissionIndex == 4 && completedOptionalMissions2.Count < optionalMissions2.Length)
            {
                StartOptionalMission(optionalMissions2, completedOptionalMissions2, optionalNPCs2);
            }
        }
        else
        {
            Debug.Log("All missions completed!");
        }
    }

    void StartOptionalMission(string[] optionalMissions, List<string> completedMissions, string[] optionalNPCs)
    {
        foreach (string mission in optionalMissions)
        {
            // Si no se ha completado la misión opcional
            if (!completedMissions.Contains(mission))
            {
                // Cambiar el texto de la misión por el de la misión opcional actual
                if (currentMissionIndex == 2){
                    missionText.text = "-(Opcional)Habla con los empleados para obtener más información de la automatización("+opcional1+"/5)\n\n";
                    missionText.text += missions[currentMissionIndex];
                    break;
                }

                if (currentMissionIndex == 4){
                    missionText.text = "-(Opcional)Habla con los empleados para que opinan de tu decisión("+opcional2+"/5)\n\n";
                    missionText.text += missions[currentMissionIndex];
                    break;
                }
            }
        }
    }

    public void CompleteMission(string npcID, int puntuacion)
    {
        if (currentMissionIndex < missions.Length)
    {
        // Verifica si el NPC interactuado es uno de los NPCs asociados a misiones opcionales
        if (currentMissionIndex == 2 && ArrayContains(optionalNPCs1, npcID))
        {
            variablesScript.SetPuntuacionGlobal(variablesScript.GetPuntuacionGlobal()+puntuacion);
            variablesScript.SetPuntuacion2Mision(variablesScript.GetPuntuacion2Mision()+puntuacion);
            completedOptionalMissions1.Add(missions[currentMissionIndex]);
            optionalNPCs1 = RemoveFromArray(optionalNPCs1, npcID);
            opcional1++;
        }
        else if ((currentMissionIndex == 4 && ArrayContains(optionalNPCs2, npcID)))
            {
                variablesScript.SetPuntuacionGlobal(variablesScript.GetPuntuacionGlobal()+puntuacion);
                variablesScript.SetPuntuacion2Mision(variablesScript.GetPuntuacion2Mision()+puntuacion);
                completedOptionalMissions2.Add(missions[currentMissionIndex]);
                optionalNPCs2 = RemoveFromArray(optionalNPCs2, npcID);
                opcional2++;
            }
        else if (npcID == npcIDs[currentMissionIndex]) // Verifica si el NPC es para la misión principal
        {
            variablesScript.SetPuntuacionGlobal(variablesScript.GetPuntuacionGlobal()+puntuacion);

            if (currentMissionIndex == 2)
            {
                variablesScript.SetPuntuacionAutomatizacion(variablesScript.GetPuntuacionAutomatizacion()+puntuacion);
            } 
            else 
            {
                variablesScript.SetPuntuacion2Mision(variablesScript.GetPuntuacion2Mision()+puntuacion);
            }

            currentMissionIndex++;

        }

        missionProgressText.text = "Puntuación: " + variablesScript.GetPuntuacionGlobal();
        StartMission();
    }
    }

    bool ArrayContains(string[] array, string value)
    {
        foreach (string item in array)
        {
            if (item == value)
            {
                return true;
            }
        }
        return false;
    }

    public int GetCurrentMissionIndex()
    {
        return currentMissionIndex;
    }

    string[] RemoveFromArray(string[] array, string value)
    {
        List<string> tempList = new List<string>(array);
        tempList.Remove(value);
        return tempList.ToArray();
    }
}
