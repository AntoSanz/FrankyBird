using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestorJuego : MonoBehaviour {
    [SerializeField] Text textoPuntuacion;
    [SerializeField] GameObject panelMenu;
    private int puntos = 0;
    private bool jugando;

    public int Puntos {
        get {
            return puntos;
        }
        set {
            puntos = value;
            //print(puntos);
            textoPuntuacion.text = puntos.ToString();
        }
    }

    // Use this for initialization
    void Start() {
        jugando = true;
    }

    public bool GetJugando() {
        return jugando;
    }

    public void MostrarMenu() {
        panelMenu.SetActive(true);
    }

    public void SetJugando(bool _jugando) {
        jugando = _jugando;
    }
    //public void FinalizarPartida() {
    //    jugando = false;
    //    Invoke("RecargarEscena", 2f);
    //}
    void Update() {

    }
    //private void RecargarEscena() {
    //    SceneManager.LoadScene(0);
    //}

}
