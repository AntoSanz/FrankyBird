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
    [SerializeField] float velocidadRotacion = -5f;
    private Rigidbody rb; //Creamos una propiedad para el RigidBody.
    private AudioSource audioSource;
    // Use this for initialization
    void Start() {
        gestorJuego = GameObject.Find("GestorJuego");
        //Se inicia una vez al iniciar el scritp
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        transform.rotation = Quaternion.Euler(new Vector3(rb.velocity.y * velocidadRotacion, 0, 0));
        if (rb.IsSleeping() == true)
            rb.WakeUp();
        
        if (Input.GetKeyDown(KeyCode.Space))
            Impulsar();
    }

    void Impulsar() {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse); //Vector3.upo aplica una unidad de fuerza hacia arriba
        audioSource.PlayOneShot(aleteo);
    }

    private void OnCollisionEnter(Collision collision) {
        //Llamada a FinalizarJuego del GestorJuego
        //print(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Limite") == false) {
            gestorJuego.GetComponent<GestorJuego>().SetJugando(false);
            gestorJuego.GetComponent<GestorJuego>().MostrarMenu();
            GameObject sangre = Instantiate(sangrePrefab);
            sangre.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        int puntos = gestorJuego.GetComponent<GestorJuego>().Puntos;
        puntos++;
        gestorJuego.GetComponent<GestorJuego>().Puntos = puntos;
    }
}
