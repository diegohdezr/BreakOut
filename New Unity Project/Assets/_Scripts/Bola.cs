using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class Bola : MonoBehaviour
{

    bool isGameStarted;
    [SerializeField] public float velocidadBola = 80f;
    Vector3 ultimaPosicion= Vector3.zero;
    Vector3 direccion = Vector3.zero;
    private Rigidbody rigidbody;
    private ControlBordes control;
    public UnityEvent BolaDestruida;
    

    void Awake()
    {
        control = GetComponent<ControlBordes>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
        Vector3 posicionInicial = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        posicionInicial.y += 3;
        this.transform.position = posicionInicial;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        Debug.Log("trygetRigidBody");
    }

    // Update is called once per frame
    void Update()
    {



        if (control.offAbajo)
        {
            BolaDestruida.Invoke();
            Destroy(gameObject);
        }
        if (control.offArriba)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("toco el borde superior");
            direccion.y *= -1;
            direccion.Normalize();
            rigidbody.velocity = velocidadBola * direccion;
            control.offArriba = false;
        }

        if (control.offIzquierda)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("toco el borde izquierdo");
            direccion.x *= -1;
            direccion.Normalize();
            rigidbody.velocity = velocidadBola * direccion;
            control.offIzquierda = false;
        }

        if (control.offDerecha)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("toco el borde derecho");
            direccion.x *= -1;
            direccion.Normalize();
            rigidbody.velocity = velocidadBola * direccion;
            control.offDerecha = false;
        }
            
        

        if (Input.GetKey(KeyCode.Space)|| Input.GetButton("Submit"))
        {
            if (!isGameStarted) 
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                rigidbody.velocity = velocidadBola * Vector3.up;
            }
        }
        
    }

    public void FixedUpdate()
    {
        ultimaPosicion = transform.position;
    }

    public void LateUpdate()
    {
        if (direccion != Vector3.zero)direccion= Vector3.zero;
    }
}
