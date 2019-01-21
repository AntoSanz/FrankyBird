using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FankyScript : MonoBehaviour {
    [SerializeField] private float force = 100f; //Creamos una variable encapsulada para la fuerza del salto
    [SerializeField] GameObject sangrePrefab;
    [SerializeField] AudioClip aleteo;
    [SerializeField] AudioClip golpe;
    [SerializeField] AudioClip puntuacion;
    [SerializeField] GameObject gestorJuego;
    private Rigidbody rb; //Creamos una propiedad para el RigidBody.
    private AudioSource audioSource;
    // Use this for initialization
    void Start() {
        gestorJuego = GameObject.Find("GestorJuego");
        //Se inicia una vez al iniciar el scritp
        rb = GetComponent<Rigidbody>(); //Dar un valor inicial al Rigidbody y genera una referencia
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (rb.velocity.y > 0) {
            transform.rotation = Quaternion.Euler(new Vector3(25, 0, 0));
        } else {
            transform.rotation = Quaternion.Euler(new Vector3(-25, 0, 0));
        }
        //Se ejecuta constantemente cada 0.016 segundos aprox
        if (Input.GetKeyDown(KeyCode.Space)) {
            //Los efectos que se aplican al Rigidbody se aplican a todo el componente
            Impulsar();
        }
    }

    void Impulsar() {
        //print("IMPULSANDO");
        rb.AddForce(Vector3.up * force, ForceMode.Impulse); //Vector3.upo aplica una unidad de fuerza hacia arriba
        audioSource.PlayOneShot(aleteo);
    }

    private void OnCollisionEnter(Collision collision) {
        //Llamada a FinalizarJuego del GestorJuego
        //print(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Limite") == false) {
            gestorJuego.GetComponent<GestorJuego>().FinalizarPartida();
            GameObject sangre = Instantiate(sangrePrefab); //Instanciamos la sangre 
            sangre.transform.position = this.transform.position; //Ponemos la sangre en la posicion del pollo
            //audioSource.PlayOneShot(golpe);
            Destroy(this.gameObject); //Destruimos el pollo
            print("YOU DIED");
        }
    }

    private void OnTriggerExit(Collider other) {
        int puntos = gestorJuego.GetComponent<GestorJuego>().Puntos;
        puntos++;
        gestorJuego.GetComponent<GestorJuego>().Puntos = puntos;
    }
}
