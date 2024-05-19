using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueScript3 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float TextSpeed = 0.1f;
    private int index;
    private bool isPlayerNear = false;
    private bool dialogueStarted = false; // Variable para rastrear si se inició el diálogo
    public Canvas dialogueCanvas;

    public string npcID;
    // Diálogos de las misiones
    public string[] linesMission1;
    public string[] linesMission2a;
    public string[] linesMission2b;
    public string[] linesMission2c;
    public string[] linesMission2d;

    // Referencia al MissionManager
    private MisionManagerMision3 missionManager;
    private VariablesScript variablesScript;

    void Start()
    {
        dialogueText.text = string.Empty;
        dialogueCanvas.gameObject.SetActive(false); // Desactiva el Canvas inicialmente

        missionManager = MisionManagerMision3.instance;
        variablesScript = VariablesScript.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra en el área de interacción
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del área de interacción
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            dialogueCanvas.gameObject.SetActive(false); // Desactiva el Canvas al salir del área
            dialogueStarted = false; // Reinicia la variable cuando el jugador sale del área
        }
    }

    void Update()
    {
        // Si el jugador está cerca y no se ha iniciado el diálogo
        if (isPlayerNear && !dialogueStarted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue();
            }
        }
        // Si el diálogo se ha iniciado y se presiona el botón izquierdo del ratón
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
        // Selecciona el diálogo de la misión actual dependiendo del índice de la misión y de la puntuación obtenida
        if (missionManager.GetCurrentMissionIndex() < 6){
            lines = linesMission1;
        }
        else 
        {
            int puntuacion = variablesScript.GetPuntuacionFeedback();
            switch (puntuacion)
            {
                case 0:
                    lines = linesMission2a;
                    break;
                case 5:
                    lines = linesMission2b;
                    break;
                case 15:
                    lines = linesMission2c;
                    break;
                case 30:
                    lines = linesMission2d;
                    break;
            }
        }
        // Reemplaza el nombre del jugador en el diálogo por el introducido en el menú de selección de personaje
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
        // Si no se ha llegado al final del diálogo
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
