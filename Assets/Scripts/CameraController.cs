using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensibilidad del ratón
    public Transform playerBody; // Referencia al cuerpo del jugador para rotar

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
    }

    void Update()
    {
        // Obtener input del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotación vertical

        // Aplicar rotación
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
