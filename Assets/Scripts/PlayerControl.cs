using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float movimiento;
    public float rotacion;
    public float speed = 20f;
    public float velocidadRotacion = 60f;
    public bool color;
    private Rigidbody rb;
    public GameObject explosion;

//.GetComponent<MeshRenderer> ().material = Material1;
    private MeshRenderer rend;
    public Material red;
    public Material green;

    private float maxAtaque = 7.2f;

    public GameObject[] enemigos;
    private Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rend = GetComponent<MeshRenderer>();
    }


private void Awake() {


    // dejamos la explosion pequeña 
     explosion.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    //Le damos un valor de crecimiento 
    scaleChange = new Vector3(0.2f, 0.2f, 0.2f);
}

private void Update() {

    // Cuando presiona Q cambia la variable color, luego esa variable controla el cambio 
      if (Input.GetKeyDown(KeyCode.Q)){

             color = !color;
         }


// cuando presiona E hace el ataque 
    if (Input.GetKeyDown(KeyCode.E)){

       
       //Inicia pequeña
        explosion.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        explosion.SetActive(true);
        // Las corrutinas sirven para esperar un tiempo entre acciones, en este caso para que la explosion crezca
            StartCoroutine(explosionCreciendo());

      }


}
    // Update is called once per frame

    private string valor;
    void FixedUpdate()
    {

        // codigo de movimiento WASD
        rotacion = Input.GetAxis("Horizontal")*velocidadRotacion;
        movimiento = Input.GetAxis("Vertical")*speed;
        movimiento *= Time.deltaTime;
        rotacion *= Time.deltaTime;
        transform.Translate(0,0,movimiento);
        transform.Rotate(0,rotacion,0);




// Cambia el color del pesonaje 
        if(color){
            rend.material = red;

        }else{

        rend.material = green;
        }

        
/*
// busca todos los objetos que tengan el tag enemigo y lo ponemos en un arreglo 
      enemigos = GameObject.FindGameObjectsWithTag("Enemy");

    // recorremos el arreglo de enemigos
        foreach(GameObject enemigo in enemigos){
        
        valor = enemigo.GetComponent<Enem_logic>().StrColor;
//Si el color del player es verde
        if(!color){

// y hay enemigos rojos
            if(valor == "red"){
// inician a perseguirlo
            enemigo.GetComponent<Enem_logic>().andar = true;
            }else{
                enemigo.GetComponent<Enem_logic>().andar = false;
            }
          

//Si el color es rojo
        }else if(color){
        //Y hay enemigos verdes 
            if(valor == "green"){
// inician a perseguirlo
            enemigo.GetComponent<Enem_logic>().andar = true;
            }else{
                enemigo.GetComponent<Enem_logic>().andar = false;
            }

            }
        }
*/
 
    }
    public float getSpeed(){
        return speed;
    }
    public void setSpeed(float s){
        this.speed = s;
    }


      IEnumerator explosionCreciendo()
    {


         // esto controla como crece la explosion        
    while (explosion.transform.localScale.y < maxAtaque)
        {
        // va amentando el tamaño hasta que llega al maximo y desaparece
        explosion.transform.localScale += scaleChange;
        yield return new WaitForSeconds(.01f);
        }
        explosion.SetActive(false);
    }
}
