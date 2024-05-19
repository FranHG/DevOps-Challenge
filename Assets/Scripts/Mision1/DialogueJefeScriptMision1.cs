using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueJefeScriptMision1 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float TextSpeed = 0.1f;
    private int index;
    private bool isPlayerNear = false;
    private bool dialogueStarted = false;
    public Canvas dialogueCanvas;

    public string npcID;

    private MisionManagerMision1 missionManager;
    private VariablesScript variablesScript;

    // Diálogos para la misión 1
    public string[] linesMission1;

    public string[] linesMission2;
    public string[] linesMission2b;
    public string[] linesMission2c;
    public string[] linesMission2d;

    public string[] linesMission3;

    public string[] linesMission4;
    public string[] linesMission4b;
    public string[] linesMission4c;
    public string[] linesMission4d;


    void Start()
    {
        dialogueText.text = string.Empty;
        dialogueCanvas.gameObject.SetActive(false);
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
            dialogueCanvas.gameObject.SetActive(false);
            dialogueStarted = false;
        }
    }

    void Update()
    {
        // Si el jugador está cerca del NPC y pulsa la tecla E, se inicia el diálogo
        if (isPlayerNear && !dialogueStarted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue();
            }
        }
        // Si el diálogo ha comenzado y el jugador pulsa el botón izquierdo del ratón, se muestra el siguiente mensaje
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
        // Selecciona los diálogos en función de la misión actual y la puntiación obtenida
        if (missionManager.GetCurrentMissionIndex() < 3)
        {
            lines = linesMission1;
        }
        else if (missionManager.GetCurrentMissionIndex() < 5)
        {
            int puntuacion = variablesScript.GetPuntuacionSeleccion();
            if (puntuacion <= 5) {
                lines = linesMission2;
            } else if (puntuacion  <= 15) {
                lines = linesMission2b;
            } else if (puntuacion <= 25) {
                lines = linesMission2c;
            } else {
                lines = linesMission2d;
            }
        } 
        else if (missionManager.GetCurrentMissionIndex() < 7)
        {
            lines = linesMission3;
        }
        else 
        {
            int puntuacion = variablesScript.GetPuntuacionComunicacion();
            switch (puntuacion)
            {
                case 0:
                    lines = linesMission4;
                    break;
                case 10:
                    lines = linesMission4b;
                    break;
                case 20:
                    lines = linesMission4c;
                    break;
                case 30:
                    lines = linesMission4d;
                    break;
            }
        }
        // Se reemplaza el nombre del jugador en el diálogo por el nombre introducido por el usuario
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
        // Si el jugador pulsa el botón izquierdo del ratón, se muestra el siguiente mensaje
        if (isPlayerNear && dialogueStarted)
        {
            if (index < lines.Length - 1)
            {
                index++;
                dialogueText.text = string.Empty;
                StartCoroutine(WriteLine());
            }
            // Si se han mostrado todos los mensajes, se desactiva el diálogo y se completa la misión si la hay asociada
            else 
            {
                dialogueCanvas.gameObject.SetActive(false);
                dialogueStarted = false;
                missionManager.CompleteMission(npcID,2);
            }
        }
    }
}
