using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text.RegularExpressions;

public class MenuController : MonoBehaviour
{
    public Button jugarButton;
    public Button controlesButton;
    public Button acercaDeButton;
    public Button salirButton;

    public GameObject controlesImage;
    public GameObject acercaDeImage;
    public GameObject seleccionPersonaje;

    public Button volverDesdeControlesButton;
    public Button volverDesdeAcercaDeButton;
    public Button volverDesdeJugar;

    public Button avatar1;
    public Button avatar2;

    public Button jugarTrasPersonaje;

    public Image botonPersonaje1;
    public Image botonPersonaje2;
    public Image personajeEnPantalla;

    public Sprite personaje1on;
    public Sprite personaje1off;
    public Sprite personaje2on;
    public Sprite personaje2off;

    public Sprite IMGpersonaje1;
    public Sprite IMGpersonaje2;

    public TextMeshProUGUI CampoNombreJugador;
    public TextMeshProUGUI error;

    private VariablesScript variablesScript;

    void Start()
    {
        variablesScript = VariablesScript.instance;
        // Configura los eventos de clic para cada botón
        jugarButton.onClick.AddListener(OnClickJugar);
        controlesButton.onClick.AddListener(OnClickControles);
        acercaDeButton.onClick.AddListener(OnClickAcercaDe);
        salirButton.onClick.AddListener(OnClickSalir);
        volverDesdeControlesButton.onClick.AddListener(OnClickVolverDesdeControles);
        volverDesdeAcercaDeButton.onClick.AddListener(OnClickVolverDesdeAcercaDe);
        volverDesdeJugar.onClick.AddListener(OnClickVolverDesdeJugar);
        jugarTrasPersonaje.onClick.AddListener(onClickJugarTrasPersonaje);

        botonPersonaje1 = avatar1.GetComponent<Image>();
        botonPersonaje2 = avatar2.GetComponent<Image>();

        //Inicialmente esta seleccionado el personaje 1
        botonPersonaje1.sprite = personaje1on;
        botonPersonaje2.sprite = personaje2off;
        variablesScript.SetTipoJugador(1);

        avatar1.onClick.AddListener(onClickAvatar1);
        avatar2.onClick.AddListener(onClickAvatar2);

        personajeEnPantalla.sprite = IMGpersonaje1;

        // Desactiva las imágenes de controles y acerca de al inicio
        controlesImage.SetActive(false);
        acercaDeImage.SetActive(false);
        seleccionPersonaje.SetActive(false);

        // Desactiva los botones de "Volver" al inicio
        volverDesdeControlesButton.interactable = false;
        volverDesdeAcercaDeButton.interactable = false;

        error.gameObject.SetActive(false);
    }

    void OnClickJugar()
    {
        // Cargar la escena del juego
        seleccionPersonaje.SetActive(true);

    }

    void OnClickControles()
    {
        // Mostrar la imagen de controles
        controlesImage.SetActive(true);
        acercaDeImage.SetActive(false); 

        // Activa el botón de "Volver desde controles"
        volverDesdeControlesButton.interactable = true;
        volverDesdeAcercaDeButton.interactable = false;
    }

    void OnClickAcercaDe()
    {
        // Muestrar la imagen acerca de
        acercaDeImage.SetActive(true);
        controlesImage.SetActive(false);

        // Activa el botón de "Volver desde acerca de"
        volverDesdeControlesButton.interactable = false; 
        volverDesdeAcercaDeButton.interactable = true;
    }

    void OnClickSalir()
    {
        // Salir de la aplicación
        Application.Quit();
    }

    void OnClickVolverDesdeControles()
    {
        // Oculta la imagen de controles y volver al menú principal
        controlesImage.SetActive(false);

        // Desactiva el botón de "Volver desde controles"
        volverDesdeControlesButton.interactable = false;
    }

    void OnClickVolverDesdeAcercaDe()
    {
        // Oculta la imagen acerca de y volver al menú principal
        acercaDeImage.SetActive(false);

        // Desactiva el botón de "Volver desde acerca de"
        volverDesdeAcercaDeButton.interactable = false;
    }

    void OnClickVolverDesdeJugar()
    {
        seleccionPersonaje.SetActive(false);
        error.gameObject.SetActive(false);
    }

    void onClickJugarTrasPersonaje ()
    {
        //Expresión que suprime los espacios de inicio y fin, además de otros carácteres como el espacio de ancho cero
        string nombreJugadorLimpio = Regex.Replace(CampoNombreJugador.text, @"^[\s\u200B]+|[\s\u200B]+$", "",RegexOptions.CultureInvariant);
        if (!string.IsNullOrWhiteSpace(nombreJugadorLimpio)){
            variablesScript.SetNombreJugador(nombreJugadorLimpio);
            // Cargar la escena del juego tras seleccionar el personaje y el nombre
            SceneManager.LoadScene("DevOps Game");
        } else {
            error.gameObject.SetActive(true);
        }
    }

    void onClickAvatar1 () 
    {
        // Cambia el sprite de los botones de personaje y el personaje en pantalla
        botonPersonaje1.sprite = personaje1on;
        botonPersonaje2.sprite = personaje2off;
        personajeEnPantalla.sprite = IMGpersonaje1;
        variablesScript.SetTipoJugador(1);
    }

    void onClickAvatar2 () 
    {
        // Cambia el sprite de los botones de personaje y el personaje en pantalla
        botonPersonaje1.sprite = personaje1off;
        botonPersonaje2.sprite = personaje2on;
        personajeEnPantalla.sprite = IMGpersonaje2;
        variablesScript.SetTipoJugador(2);
    }
}
