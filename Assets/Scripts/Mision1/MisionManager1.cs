using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MisionManagerMision1 : MonoBehaviour
{
    public static MisionManagerMision1 instance; // Singleton instance
    public TextMeshProUGUI missionText;
    public TextMeshProUGUI missionProgressText;
    public Canvas missionCanvas;

    public string[] npcIDs;
    // Misiones principales
    public string[] missions;
    // Misiones opcionales
    public string[] optionalMissions1; 
    public string[] optionalMissions2; 
    public string[] optionalMissions3;
    // NPCs asociados a misiones opcionales
    public string[] optionalNPCs1; 
    public string[] optionalNPCs2; 
    public string[] optionalNPCs3; 
    // Misiones opcionales completadas
    private List<string> completedOptionalMissions1 = new List<string>();
    private List<string> completedOptionalMissions2 = new List<string>();
    private List<string> completedOptionalMissions3 = new List<string>();

    private int opcional1 = 0;
    private int opcional2 = 0;
    private int opcional3 = 0;

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

        missionCanvas.gameObject.SetActive(true);
        missionProgressText.text = "Puntuación: " +  variablesScript.GetPuntuacionGlobal();
        StartMission(); 
    }

    void StartMission()
    {   
        // Verificar si hay misiones por completar
        if (currentMissionIndex < missions.Length)
        {
            missionText.text = missions[currentMissionIndex];
            // Verificar si la misión actual es una misión opcional y si hay misiones opcionales por completar e iniciar la misión opcional
            if (currentMissionIndex == 2 && completedOptionalMissions1.Count < optionalMissions1.Length)
            {
                StartOptionalMission(optionalMissions1, completedOptionalMissions1, optionalNPCs1);
            }
            else if (currentMissionIndex == 6 && completedOptionalMissions2.Count < optionalMissions2.Length)
            {
                StartOptionalMission(optionalMissions2, completedOptionalMissions2, optionalNPCs2);
            }
            else if (currentMissionIndex == 8 && completedOptionalMissions3.Count < optionalMissions3.Length)
            {
                StartOptionalMission(optionalMissions3, completedOptionalMissions3, optionalNPCs3);
            }
        }
        else
        {
            Debug.Log("All missions completed!");
        }
    }

    void StartOptionalMission(string[] optionalMissions, List<string> completedMissions, string[] optionalNPCs)
    {
        // Mostrar la misión opcional actual
        foreach (string mission in optionalMissions)
        {
            // Verificar si la misión opcional actual no ha sido completada
            if (!completedMissions.Contains(mission))
            {
                // Se sustituye el texto de la misión por el texto de la misión opcional actual
                if (currentMissionIndex == 2){
                    missionText.text = "-(Opcional)Habla con los empleados para ver su opinión de la formación ("+opcional1+"/5)\n\n";
                    missionText.text += missions[currentMissionIndex];
                    break;
                }
                if (currentMissionIndex == 6){
                    missionText.text = "-(Opcional)Habla con los empleados sobre los métodos de comunicación ("+opcional2+"/5)\n\n";
                    missionText.text += missions[currentMissionIndex];
                    break;
                }
                if (currentMissionIndex == 8){
                    missionText.text = "-(Opcional)Habla con los empleados sobre su opinión de la formación y comunicación ("+opcional3+"/5)\n\n";
                    missionText.text += missions[currentMissionIndex];
                    break;
                }
                
            }
        }
    }

    public void CompleteMission(string npcID, int puntuacion)
    {
        // Verifica si hay misiones por completar
        if (currentMissionIndex < missions.Length)
    {
        // Verifica si el NPC interactuado es uno de los NPCs asociados a misiones opcionales
        if (currentMissionIndex == 2 && ArrayContains(optionalNPCs1, npcID))
        {
            variablesScript.SetPuntuacionGlobal(variablesScript.GetPuntuacionGlobal()+puntuacion);
            variablesScript.SetPuntuacion1Mision(variablesScript.GetPuntuacion1Mision()+puntuacion);
            completedOptionalMissions1.Add(missions[currentMissionIndex]);
            optionalNPCs1 = RemoveFromArray(optionalNPCs1, npcID);
            opcional1++;
        }
        else if (currentMissionIndex == 6 && ArrayContains(optionalNPCs2, npcID))
        {
            variablesScript.SetPuntuacionGlobal(variablesScript.GetPuntuacionGlobal()+puntuacion);
            variablesScript.SetPuntuacion1Mision(variablesScript.GetPuntuacion1Mision()+puntuacion);
            completedOptionalMissions2.Add(missions[currentMissionIndex]);
            optionalNPCs2 = RemoveFromArray(optionalNPCs2, npcID);
            opcional2++;
        }
        else if (currentMissionIndex == 8 && ArrayContains(optionalNPCs3, npcID))
        {
            variablesScript.SetPuntuacionGlobal(variablesScript.GetPuntuacionGlobal()+puntuacion);
            variablesScript.SetPuntuacion1Mision(variablesScript.GetPuntuacion1Mision()+puntuacion);
            completedOptionalMissions3.Add(missions[currentMissionIndex]);
            optionalNPCs3 = RemoveFromArray(optionalNPCs3, npcID);
            opcional3++;
        }
        else if (npcID == npcIDs[currentMissionIndex]) // Verifica si el NPC es para la misión principal
        {
            variablesScript.SetPuntuacionGlobal(variablesScript.GetPuntuacionGlobal()+puntuacion);
            
            if (currentMissionIndex == 2)
            {
                variablesScript.SetPuntuacionSeleccion(variablesScript.GetPuntuacionSeleccion()+puntuacion);
            } 
            else if (currentMissionIndex == 6) 
            {
                variablesScript.SetPuntuacionComunicacion(variablesScript.GetPuntuacionComunicacion()+puntuacion);
            } 
            else 
            {
                variablesScript.SetPuntuacion1Mision(variablesScript.GetPuntuacion1Mision()+puntuacion);
            }

            currentMissionIndex++;

        }

        missionProgressText.text = "Puntuación: " + variablesScript.GetPuntuacionGlobal();
        StartMission(); // Start the next mission
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
