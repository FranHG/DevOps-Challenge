using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueJefeScriptMision3 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float TextSpeed = 0.1f;
    private int index;
    private bool isPlayerNear = false;
    private bool dialogueStarted = false;
    public Canvas dialogueCanvas;

    public string npcID;

    private MisionManagerMision3 missionManager;
    private VariablesScript variablesScript;

    // Nuevas variables
    public string[] linesMission1;
    public string[] linesMission2;

    public string[] linesMission3a;
    public string[] linesMission3b;
    public string[] linesMission3c;
    public string[] linesMission3d;

    public string[] linesMission4a;
    public string[] linesMission4b;
    public string[] linesMission4c;
    public string[] linesMission4d;


    void Start()
    {
        dialogueText.text = string.Empty;
        dialogueCanvas.gameObject.SetActive(false);
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
            dialogueCanvas.gameObject.SetActive(false);
            dialogueStarted = false;
        }
    }

    void Update()
    {
        // Si el jugador está cerca y no ha comenzado el diálogo
        if (isPlayerNear && !dialogueStarted)
        {
            // Si presiona la tecla E se inicia el diálogo
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue();
            }
        }
        // Si el diálogo ha comenzado y se presiona el botón izquierdo del ratón
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
        // Dependiendo de la misión actual y la puntuación obtenida se mostrarán unos diálogos u otros
        if (missionManager.GetCurrentMissionIndex() < 3)
        {
            lines = linesMission1;
        }
        else if (missionManager.GetCurrentMissionIndex() < 5)
        {
            lines = linesMission2;
        }
        else if (missionManager.GetCurrentMissionIndex() < 7)
        {
            int puntuacion = variablesScript.GetPuntuacionFeedback();
            switch (puntuacion)
            {
                case 0:
                    lines = linesMission3a;
                    break;
                case 5:
                    lines = linesMission3b;
                    break;
                case 15:
                    lines = linesMission3c;
                    break;
                case 30:
                    lines = linesMission3d;
                    break;
            }
        }
         else 
        {
            int puntuacionTotal= 209;
            double porcentaje = (double)variablesScript.GetPuntuacionGlobal() / puntuacionTotal * 100;
            // Dependiendo del porcentaje de acierto se mostrarán unos diálogos u otros
            if (porcentaje >= 76){
                lines = linesMission4a;
            }else if (porcentaje >= 51) {
                lines = linesMission4b;
            }else if (porcentaje >= 26) {
                lines = linesMission4c;
            }else {
                lines = linesMission4d;
            }
            
        }
        // Se sustituye el nombre del jugador en el diálogo por el nombre introducido por el jugador en el menú de selección
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
        // Si no se ha llegado al final del diálogo se muestra la siguiente línea
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
                dialogueCanvas.gameObject.SetActive(false);
                dialogueStarted = false;
                missionManager.CompleteMission(npcID,2);
            }
            // Si se ha completado la misión 8 se carga la escena de la decisión final
            if (missionManager.GetCurrentMissionIndex() == 8) {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("DecisionFinal");
            }
        }
    }
}
