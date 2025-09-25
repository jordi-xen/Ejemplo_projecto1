using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float vel = 10f;
    //public GameObject jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            
        */


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

        // Apliquem el vector desplaçament a l'objecte
        transform.position += nouDesplacament; 
    }
}
