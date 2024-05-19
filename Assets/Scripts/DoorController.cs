using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    public Transform pivotPoint;
    public float interactionDistance = 2.0f;
    private bool isOpen = false;
    private bool isPlayerNear = false;

    // Referencia a la puerta más cercana
    private DoorController nearestDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;

            // Establece esta puerta como la más cercana si no hay otra puerta más cercana
            if (nearestDoor == null || Vector3.Distance(transform.position, Camera.main.transform.position) < Vector3.Distance(nearestDoor.transform.position, Camera.main.transform.position))
            {
                nearestDoor = this;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del área de interacción, se desactiva la variable
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void Update()
    {
        // Si el jugador está cerca y pulsa la tecla E, se abre o cierra la puerta
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && nearestDoor == this)
        {
            // Si la puerta está abierta, se cierra
            if (isOpen)
            {
                RotateDoor(-90.0f);
                isOpen = false;
            }
            else // Si la puerta está cerrada, se abre
            {
                RotateDoor(90.0f);
                isOpen = true;
            }
        }
    }
    
    // Método para rotar la puerta
    private void RotateDoor(float angle)
    {
        Vector3 pivot = pivotPoint != null ? pivotPoint.position : transform.position;
        transform.RotateAround(pivot, Vector3.up, angle);
    }
}
