using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour
{
    public Canvas computerUI; // Asigna el Canvas que contiene la interfaz de usuario en el Inspector.
    private bool isUIVisible = false;

    private void OnTriggerEnter(Collider other)
    {
        // Se comprueba si el jugador está cerca de la computadora.
        if (other.CompareTag("Player"))
        {
        }
    }

    private void Update()
    {
        // Si el jugador está cerca del ordenador y presiona la tecla E.
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isUIVisible)
            {
                // Si la interfaz ya está visible, la oculta.
                HideComputerUI();
            }
            else
            {
                // Si la interfaz no está visible, la muestra.
                ShowComputerUI();
            }
        }
    }

    private void ShowComputerUI()
    {
        // Muestra la interfaz de usuario 
        computerUI.gameObject.SetActive(true);
        isUIVisible = true;
    }

    private void HideComputerUI()
    {
        // Oculta la interfaz de usuario 
        computerUI.gameObject.SetActive(false);
        isUIVisible = false;
    }
}
