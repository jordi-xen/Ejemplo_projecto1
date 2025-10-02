using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float vel = 10f;
    private Vector3 limitInferiorEsquerra;
    private Vector3 limitSuperiorDret;
    private Camera camera;

    //public GameObject jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;

        float distanciaZCameraNau = Mathf.Abs(transform.position.z - camera.transform.position.z);

        limitInferiorEsquerra = camera.ViewportToWorldPoint(new Vector3(0, 0, distanciaZCameraNau));
        limitSuperiorDret = camera.ViewportToWorldPoint(new Vector3(1, 1, distanciaZCameraNau));
    }

    // Update is called once per frame
    void Update()
    {

        MovimentNau();
        ControlLimitsPantalla();
    }

    void MovimentNau()
    {

        /*if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            
        */

        //Control limits pantalla


        // Moviment nau.

        float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxisRaw("Vertical");
        Vector3 direccio = new Vector3(direccioHoritzontal, direccioVertical, 0).normalized; //(x, y, z)
        Debug.Log("direccio =" + direccio);
        //transform.position = direccio;

        Vector3 nouDesplacament = new Vector3(
        vel * direccio.x * Time.deltaTime,
        vel * direccio.y * Time.deltaTime,
        vel * direccio.z * Time.deltaTime
        );
        //Debug.Log("Time.deltaTime =" + Time.deltaTime);

        //Control dels limits de la pantalla

        //El metode Math.clamp, ens retorna el primer parametre.

        /*
        Per, si aquet primer parametre, te un valor mes petit que el segon parametre, 
        retornara el segon parametre. I, si te un valor mes gran que el tercer parametre, 
        ens retornara el tercer parametre.
        */
        // Apliquem el vector desplaçament a l'objecte
        transform.position += nouDesplacament;
    }
    void ControlLimitsPantalla()
    {
        /*
        No podem modificar el transfomr.position.x, nomes consultar-ho, per tant,
         fem una nova variable 
         */
        Vector3 novaPos = transform.position;
        //Control dels limits de la pantalla
        //El metode Math.clamp, ens retorna el primer parametre.
        /*
        Per, si aquet primer parametre, te un valor mes petit que el segon parametre, 
        retornara el segon parametre. I, si te un valor mes gran que el tercer parametre, 
        ens retornara el tercer parametre.
        */
        novaPos.x = Math.Clamp(novaPos.x, limitInferiorEsquerra.x, limitSuperiorDret.x);
        novaPos.y = Math.Clamp(novaPos.y, limitInferiorEsquerra.y, limitSuperiorDret.y);

        transform.position = novaPos;
    }
    
}
