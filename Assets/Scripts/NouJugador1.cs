using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float vel = 10f;
    
    private Camera camera;

    //public GameObject jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    MovimentNau();
    }

    void MovimentNau(){

        /*if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            
        */

        //Control limits pantalla
        Vector3 limitInferiorEsquerra = camera.ViewportToWorldPoint(new Vector2(0, 0));
        Vector3 limitSuperiorDret = camera.ViewportToWorldPoint(new Vector2(1, 1));

        // Moviment nau.
        
        float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxis("Vertical");
        Vector3 direccio = new Vector3(direccioHoritzontal, direccioVertical, 0).normalized; //(x, y, z)
        //Debug.Log("direccio =" + direccio);
        //transform.position = direccio;

        Vector3 nouDesplacament = new Vector3(
        vel * direccio.x * Time.deltaTime,
        vel *  direccio.y * Time.deltaTime,
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
        nouDesplacament.x = Math.Clamp(nouDesplacament.x, limitInferiorEsquerra.x, limitSuperiorDret.x);
        nouDesplacament.x = Math.Clamp(nouDesplacament.y, limitInferiorEsquerra.y, limitSuperiorDret.y);

        // Apliquem el vector desplaçament a l'objecte
        transform.position += nouDesplacament; 
    }
    
}
