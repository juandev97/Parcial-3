using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enem_logic : MonoBehaviour
{

    public bool andar;
    float speed = 7.0f;
    
    // con esta variable sabemos el color del enemigo
    public string StrColor;

//posicion del player
    public Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        
    }


//si el enemigo se activa, se va a mover en direccion al player
    private void LateUpdate() {
        if(andar){

        Vector3 direccion = goal.position - this.transform.position;
        this.transform.Translate(direccion.normalized * speed * Time.deltaTime);
        }
    }
    // Update is called once per frame


    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            SceneManager.LoadScene("GameOver");
        }
    }


    void Update()
    {
        
    }
}
