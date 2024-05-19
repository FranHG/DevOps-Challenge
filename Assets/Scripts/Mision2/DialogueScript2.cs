using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueScript2 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float TextSpeed = 0.1f;
    private int index;
    private bool isPlayerNear = false;
    private bool dialogueStarted = false; // Variable para rastrear si se inició el diálogo
    public Canvas dialogueCanvas;

    public string npcID;
    // Diálogos para la misión 2
    public string[] linesMission1;
    public string[] linesMission2a;
    public string[] linesMission2b;
    public string[] linesMission2c;
    public string[] linesMission2d;

    // Referencia al MissionManager
    private MisionManagerMision2 missionManager;
    private VariablesScript variablesScript;

    void Start()
    {
        dialogueText.text = string.Empty;
        dialogueCanvas.gameObject.SetActive(false); // Desactiva el Canvas inicialmente

        missionManager = MisionManagerMision2.instance;
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
        // Si el jugador está cerca del NPC y pulsa la tecla E
        if (isPlayerNear && !dialogueStarted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue();
            }
        }
        // Si el diálogo se ha iniciado y el jugador pulsa el botón izquierdo del ratón
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
        // Selecciona las líneas de diálogo según la misión actual y la puntuación de automatización
        if (missionManager.GetCurrentMissionIndex() < 4){
            lines = linesMission1;
        }
        else 
        {
            int puntuacion = variablesScript.GetPuntuacionAutomatizacion();
            switch (puntuacion)
            {
                case 10:
                    lines = linesMission2b;
                    break;
                case 20:
                    lines = linesMission2c;
                    break;
                case 35:
                    lines = linesMission2d;
                    break;
                default:
                    lines = linesMission2a;
                    break;
            }
        }
        // Reemplaza el nombre del jugador en el diálogo por el nombre introducido por el jugador en el menú principal
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
        // Si hay más líneas de diálogo, se muestra la siguiente
        if (isPlayerNear && dialogueStarted)
        {
            if (index < lines.Length - 1)
            {
                index++;
                dialogueText.text = string.Empty;
                StartCoroutine(WriteLine());
            }
            else // Si no hay más líneas de diálogo, se desactiva el Canvas y se marca la misión como completada
            {
                dialogueCanvas.gameObject.SetActive(false); // Desactiva el Canvas al finalizar
                dialogueStarted = false;
                missionManager.CompleteMission(npcID,2);
            }
        }
    }
}
