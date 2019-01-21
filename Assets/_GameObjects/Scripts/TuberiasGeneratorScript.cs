using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuberiasGeneratorScript : MonoBehaviour {
    [SerializeField] GameObject tuberiasPrefab;
    [SerializeField] float timeBetweenPipes = 2f;
    GameObject gestorJuego;

    void Start() {
        gestorJuego = GameObject.Find("GestorJuego");
        InvokeRepeating("CrearTuberia", 0, timeBetweenPipes);
    }

    void Update() {

    }
    private void CrearTuberia() {
        if (gestorJuego.GetComponent<GestorJuego>().GetJugando() == true) {
            Instantiate(tuberiasPrefab, transform);
        }
    }
}
