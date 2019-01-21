using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuberiasScript : MonoBehaviour {
    //Variables
    [SerializeField] private float speed = 5f;
    [SerializeField] int destroyTime = 5;
    GameObject gestorJuego;
    // Use this for initialization
    void Start() {
        gestorJuego = GameObject.Find("GestorJuego");
        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update() {
        //transform = referencia al gameobject
        //if (GestorJuego.GetJugando() == true) {
        //    transform.Translate(Vector3.back * Time.deltaTime * speed);
        //}
        if (gestorJuego.GetComponent<GestorJuego>().GetJugando() == true) {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

    }


}
