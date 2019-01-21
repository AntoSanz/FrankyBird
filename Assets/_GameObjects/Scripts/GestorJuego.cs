using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorJuego : MonoBehaviour {
    private int puntos = 0;
    private bool jugando;



    // Use this for initialization
    void Start() {
        jugando = true;
    }

    public bool GetJugando() {
        return jugando;
    }

    public void FinalizarPartida() {
        jugando = false;
        Invoke("RecargarEscena", 2f);
    }

    // Update is called once per frame
    void Update() {

    }
    private void RecargarEscena() {
        SceneManager.LoadScene(0);
    }
}
