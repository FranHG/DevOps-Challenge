using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueJefeScriptMision2 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float TextSpeed = 0.1f;
    private int index;
    private bool isPlayerNear = false;
    private bool dialogueStarted = false;
    public Canvas dialogueCanvas;

    public string npcID;

    private MisionManagerMision2 missionManager;
    private VariablesScript variablesScript;

    // Diálogos para la misión 2
    public string[] linesMission1;
    public string[] linesMission2;
    public string[] linesMission2b;
    public string[] linesMission2c;
    public string[] linesMission2d;
    public string[] linesMission2e;


    void Start()
    {
        dialogueText.text = string.Empty;
        dialogueCanvas.gameObject.SetActive(false);
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
            dialogueCanvas.gameObject.SetActive(false);
            dialogueStarted = false;
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
        // Si el diálogo ha comenzado y el jugador pulsa el botón izquierdo del ratón
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
        dialogueCanvas.gameObject.SetActive(true);
        index = 0;
        // Seleccionar los diálogos en funcion de la misión actual y la puntuación obtenida
        if (missionManager.GetCurrentMissionIndex() < 3)
        {
            lines = linesMission1;
        }
        else 
        {
            int puntuacion = variablesScript.GetPuntuacionAutomatizacion();
            switch (puntuacion)
            {
                case 0:
                    lines = linesMission2;
                    break;
                case 5:
                    lines = linesMission2b;
                    break;
                case 10:
                    lines = linesMission2c;
                    break;
                case 20:
                    lines = linesMission2d;
                    break;
                case 35:
                    lines = linesMission2e;
                    break;
            }
        }
        // Reemplazar el nombre del jugador en el diálogo por el nombre introducido en el menú de selección
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
        // Muestra el siguiente mensaje en el diálogo
        if (isPlayerNear && dialogueStarted)
        {
            // Si hay más mensajes por mostrar, se muestra el siguiente
            if (index < lines.Length - 1)
            {
                index++;
                dialogueText.text = string.Empty;
                StartCoroutine(WriteLine());
            }
            else
            {
                dialogueCanvas.gameObject.SetActive(false);
                dialogueStarted = false;
                missionManager.CompleteMission(npcID,2);
            }
        }
    }
}
