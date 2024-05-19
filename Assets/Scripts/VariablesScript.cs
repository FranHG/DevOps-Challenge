using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesScript : MonoBehaviour
{
    public static VariablesScript instance;

    private static int puntuacionGlobal = 0;
    private static int puntuacionIntro = 0;
    private static int puntuacion1Mision = 0;
    private static int puntuacionSeleccion = 0;
    private static int puntuacionComunicacion = 0;
    private static int puntuacion2Mision = 0;
    private static int puntuacionAutomatizacion = 0;
    private static int puntuacion3Mision = 0;
    private static int puntuacionFeedback = 0;

    private static int graficoComunicacion = 0;
    private static int graficoAutomatizacion = 0;
    private static int graficoFeedback = 0;

    //En un principio siempre usa el personaje 1
    private static int tipoJugador = 1;

    private static string nombreJugador = "Jugador";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetPuntuacionGlobal()
    {
        return puntuacionGlobal;
    }

    public void SetPuntuacionGlobal(int value)
    {
        puntuacionGlobal = value;
    }

    public int GetPuntuacionIntro()
    {
        return puntuacionIntro;
    }

    public void SetPuntuacionIntro(int value)
    {
        puntuacionIntro = value;
    }

    public int GetPuntuacion1Mision()
    {
        return puntuacion1Mision;
    }

    public void SetPuntuacion1Mision(int value)
    {
        puntuacion1Mision = value;
    }

    public int GetPuntuacionSeleccion (){
        return puntuacionSeleccion;
    }

    public void SetPuntuacionSeleccion(int value)
    {
        puntuacionSeleccion = value;
    }

    public int GetPuntuacionComunicacion(){
        return puntuacionComunicacion;
    }

    public void SetPuntuacionComunicacion(int value)
    {
        puntuacionComunicacion = value;
    }

    public int GetPuntuacion2Mision()
    {
        return puntuacion2Mision;
    }

    public int GetPuntuacionAutomatizacion() {
        return puntuacionAutomatizacion;
    }

    public void SetPuntuacionAutomatizacion(int value){
        puntuacionAutomatizacion = value;
    }

    public void SetPuntuacion2Mision(int value)
    {
        puntuacion2Mision = value;
    }

    public int GetPuntuacion3Mision()
    {
        return puntuacion3Mision;
    }

    public void SetPuntuacion3Mision(int value)
    {
        puntuacion3Mision = value;
    }

    public int GetPuntuacionFeedback() {
        return puntuacionFeedback;
    }

    public void SetPuntuacionFeedback(int value) {
        puntuacionFeedback = value;
    }

    public int GetGraficoComunicacion() {
        return graficoComunicacion;
    }

    public void SetGraficoComunicacion(int value) {
        graficoComunicacion = value;
    }

    public int GetGraficoAutomatizacion() {
        return graficoAutomatizacion;
    }

    public void SetGraficoAutomatizacion(int value) {
        graficoAutomatizacion = value;
    }

    public int GetGraficoFeedback() {
        return graficoFeedback;
    }

    public void SetGraficoFeedback(int value) {
        graficoFeedback = value;
    }

    public int GetTipoJugador() {
        return tipoJugador;
    }

    public void SetTipoJugador(int value) {
        tipoJugador = value;
    }

    public string GetNombreJugador () {
        return nombreJugador;
    }

    public void SetNombreJugador (string value) {
        nombreJugador = value;
    }
}

