using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueJefeScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float TextSpeed = 0.1f;
    private int index;
    private bool isPlayerNear = false;
    private bool dialogueStarted = false;
    public Canvas dialogueCanvas;

    public string npcID;

    private MissionManager missionManager;
    private VariablesScript variablesScript;

    // Nuevas variables
    public string[] linesMission1;
    public string[] linesMission2;

    void Start()
    {
        // Se Inicializa el texto del diálogo y se desactiva el Canvas
        dialogueText.text = string.Empty;
        dialogueCanvas.gameObject.SetActive(false);
        missionManager = MissionManager.instance;
        variablesScript = VariablesScript.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        // Se comprueba si el jugador está cerca del objeto
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Se comprueba si el jugador se aleja del objeto
        if (other.CompareTag("Player"))
        {
            // Se oculta el Canvas
            isPlayerNear = false;
            dialogueCanvas.gameObject.SetActive(false);
            dialogueStarted = false;
        }
    }

    void Update()
    {
        // Si el jugador está cerca y no ha comenzado el diálogo
        if (isPlayerNear && !dialogueStarted)
        {
            // Si se pulsa la tecla E comienza el dialogo
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue();
            }
        }

        // Si el diálogo ha comenzado y se pulsa el botón izquierdo del ratón
        if (dialogueStarted && Input.GetMouseButtonDown(0))
        {
            // Se avanza en el dialogo
            if (dialogueText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                // Se muestra todo el texto si se pulsa el botón izquierdo del ratón
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
    }

    private void StartDialogue()
    {
        dialogueText.text = string.Empty;
        dialogueCanvas.gameObject.SetActive(true);
        index = 0;
        // Se asignan los diálogos dependiendo de la misión actual
        if (missionManager.GetCurrentMissionIndex() < 8)
        {
            lines = linesMission1;
        }
        else
        {
            lines = linesMission2;
        }
        // Se reemplaza el nombre del jugador en el diálogo por el que introdujo el usuario
        for (int i = 0; i < lines.Length; i++) {
            lines[i] = lines[i].Replace("{CHARACTER_NAME}", variablesScript.GetNombreJugador());
        }

        StartCoroutine(WriteLine());
        dialogueStarted = true;
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
        // Si el jugador está cerca y se pulsa el botón izquierdo del ratón
        if (isPlayerNear && dialogueStarted)
        {
            // Si no se ha llegado al final del diálogo
            if (index < lines.Length - 1)
            {
                // Se avanza en el diálogo
                index++;
                dialogueText.text = string.Empty;
                StartCoroutine(WriteLine());
            }
            else
            {
                // Si se ha llegado al final del diálogo se oculta el Canvas y 
                //se completa la misión en el caso de que haya una misión asociada
                dialogueCanvas.gameObject.SetActive(false);
                dialogueStarted = false;
                missionManager.CompleteMission(npcID);
            }
        }
    }
}
