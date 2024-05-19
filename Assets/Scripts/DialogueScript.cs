using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float TextSpeed = 0.1f;
    private int index;
    private bool isPlayerNear = false;
    private bool dialogueStarted = false; // Variable para rastrear si se inició el diálogo
    public Canvas dialogueCanvas;

    public string npcID;

    // Referencia al MissionManager
    private MissionManager missionManager;
    private VariablesScript variablesScript;

    void Start()
    {
        dialogueText.text = string.Empty;
        dialogueCanvas.gameObject.SetActive(false); // Se desactiva el Canvas inicialmente

        missionManager = MissionManager.instance;
        variablesScript = VariablesScript.instance;

        // Se reemplaza el nombre del jugador en el diálogo por el que introdujo el usuario
        for (int i = 0; i < lines.Length; i++) {
            lines[i] = lines[i].Replace("{CHARACTER_NAME}", variablesScript.GetNombreJugador());
        }
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
            isPlayerNear = false;
            dialogueCanvas.gameObject.SetActive(false); // Se desactiva el Canvas al salir del área
            dialogueStarted = false; // Se reinicia la variable cuando el jugador sale del área
        }
    }

    void Update()
    {
        // Si el jugador está cerca y no ha comenzado el diálogo
        if (isPlayerNear && !dialogueStarted)
        {
            // Si se pulsa la tecla E comienza el diálogo
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue();
            }
        }

        // Si el diálogo ha comenzado y se pulsa el botón izquierdo del ratón
        if (dialogueStarted && Input.GetMouseButtonDown(0))
        {
            // Se avanza en el diálogo
            if (dialogueText.text == lines[index])
            {
                NextLine();
            }
            else // Se muestra todo el texto si se pulsa el botón izquierdo del ratón
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
        StartCoroutine(WriteLine());
        dialogueStarted = true; // Marca que el diálogo se ha iniciado
    }

    private IEnumerator WriteLine()
    {
        // Escribe el diálogo letra por letra
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(TextSpeed);
        }
    }

    private void NextLine()
    {
        if (isPlayerNear && dialogueStarted) // Asegura que el diálogo se haya iniciado con la tecla "E"
        {
            // Si hay más líneas de diálogo, se avanza
            if (index < lines.Length - 1)
            {
                index++;
                dialogueText.text = string.Empty;
                StartCoroutine(WriteLine());
            }
            else // Si no, se desactiva el Canvas y se marca la misión como completada si hay misió asociada
            {
                dialogueCanvas.gameObject.SetActive(false); // Desactiva el Canvas al finalizar
                dialogueStarted = false;
                missionManager.CompleteMission(npcID);
            }
        }
    }
}