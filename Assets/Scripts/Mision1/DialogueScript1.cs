using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueScript1 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float TextSpeed = 0.1f;
    private int index;
    private bool isPlayerNear = false;
    private bool dialogueStarted = false; // Variable para rastrear si se inició el diálogo
    public Canvas dialogueCanvas;
    private VariablesScript variablesScript;

    public string npcID;
    // Diálogos para la misión 1
    public string[] linesMission1;
    public string[] linesMission2;
    public string[] linesMission3a;
    public string[] linesMission3b;
    public string[] linesMission3c;
    public string[] linesMission3d;

    // Referencia al MissionManager
    private MisionManagerMision1 missionManager;

    void Start()
    {
        dialogueText.text = string.Empty;
        dialogueCanvas.gameObject.SetActive(false); // Desactiva el Canvas inicialmente

        missionManager = MisionManagerMision1.instance;
        variablesScript = VariablesScript.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        // Si el jugador está cerca del NPC, se activa el diálogo
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si el jugador se aleja del NPC, se desactiva el diálogo
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            dialogueCanvas.gameObject.SetActive(false); // Desactiva el Canvas al salir del área
            dialogueStarted = false; // Reinicia la variable cuando el jugador sale del área
        }
    }

    void Update()
    {
        // Si el jugador está cerca del NPC y presiona la tecla E, se inicia el diálogo
        if (isPlayerNear && !dialogueStarted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue();
            }
        }
        // Si el diálogo ya se inició y el jugador presiona el botón del mouse, se muestra el siguiente mensaje
        if (dialogueStarted && Input.GetMouseButtonDown(0))
        {
            if (dialogueText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
    }

    private void StartDialogue()
    {
        dialogueText.text = string.Empty;
        dialogueCanvas.gameObject.SetActive(true); // Activa el Canvas
        index = 0;
        // Selecciona los diálogos según la misión actual y la puntuación obtenida
        if (missionManager.GetCurrentMissionIndex() < 3){
            lines = linesMission1;
        } else if(missionManager.GetCurrentMissionIndex() < 7){
            lines = linesMission2;
        } else {
            int puntuacion = variablesScript.GetPuntuacionSeleccion()+variablesScript.GetPuntuacionComunicacion();
            if (puntuacion < 20) {
                lines = linesMission3a;
            }else if (puntuacion < 40){
                lines = linesMission3b;
            }else if(puntuacion < 60){
                lines = linesMission3c;
            }else{
                lines = linesMission3d;
            }
        }
        // Reemplaza el nombre del jugador en el diálogo por el nombre introducido en el menú de selección
        for (int i = 0; i < lines.Length; i++) {
            lines[i] = lines[i].Replace("{CHARACTER_NAME}", variablesScript.GetNombreJugador());
        }

        StartCoroutine(WriteLine());
        dialogueStarted = true; // Marca que el diálogo se ha iniciado
    }

    private IEnumerator WriteLine()
    {
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(TextSpeed);
        }
    }

    private void NextLine()
    {
        // Muestra el siguiente mensaje en el diálogo
        if (isPlayerNear && dialogueStarted)
        {
            if (index < lines.Length - 1)
            {
                index++;
                dialogueText.text = string.Empty;
                StartCoroutine(WriteLine());
            }
            else
            {
                dialogueCanvas.gameObject.SetActive(false); // Desactiva el Canvas al finalizar
                dialogueStarted = false;
                missionManager.CompleteMission(npcID,2);
            }
        }
    }
}
