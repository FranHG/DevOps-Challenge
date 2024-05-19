using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTransform; // Transform de la cámara principal
    public float moveSpeed = 5.0f;

    private Rigidbody rb;
    private Animator animator; // Referencia al componente Animator del personaje

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Obtiene el componente Animator del personaje

        // Bloquea la rotación en X y Z del Rigidbody para evitar que el personaje se caiga
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // Input del teclado
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Verifica si se están pulsando las teclas de movimiento
        bool semueve = moveHorizontal != 0 || moveVertical != 0;

        // Actualiza la variable semueve en el controlador de animación
        animator.SetBool("semueve", semueve);

        // Calcula la dirección de movimiento basada en la orientación de la cámara
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0; // Ignora la componente Y de la cámara para mantener el movimiento en el plano horizontal
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 direction = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;

        // Mueve el Rigidbody hacia la dirección calculada
        Vector3 movement = direction * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
