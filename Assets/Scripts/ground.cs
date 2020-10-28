using UnityEngine;
using UnityEngine.SceneManagement;

public class ground : MonoBehaviour {
    

public Material material1;
private PlayerControl plc;
public string QueColor;
public GameObject[] enemigos;
private void Start() {
    
}

private string valor;

public string valorSuelo;


// si el enemigo toca el suelo de otro color, su color cambia 


//private void OnTriggerEnter(Collider other) {
    //if(other.tag == "Enemy"){

        //other.gameObject.GetComponent<MeshRenderer>().material = material1;
        //other.gameObject.GetComponent<Enem_logic>().StrColor = QueColor;
    


private void OnTriggerStay(Collider other) {
    
     if(other.tag == "Player"){

       
        //Si el jugador entra a una casilla, se verifica su color
        plc = other.GetComponent<PlayerControl>();


        enemigos = GameObject.FindGameObjectsWithTag("Enemy");


          if(enemigos.Length == 0){
              SceneManager.LoadScene("Win");
          }
// se recorren los enemigos y se meten en un array 

        foreach(GameObject enemigo in enemigos){
        
        valor = enemigo.GetComponent<Enem_logic>().StrColor;
//Si el color del player es verde
        if(!plc.color){

//  hay enemigos y se toco un suelo rojo
            if(valor == "red" && valorSuelo == "red"){
// enemigo persigue 
            enemigo.GetComponent<Enem_logic>().andar = true;
            }else{
                enemigo.GetComponent<Enem_logic>().andar = false;
            }
          

//Si el color es rojo
        }else if(plc.color){

        //  hay enemigos verdes y toca suelo verde
            if(valor == "green" && valorSuelo == "green"){
                // enemigo persigue
            enemigo.GetComponent<Enem_logic>().andar = true;
            }else{
                enemigo.GetComponent<Enem_logic>().andar = false;
            }

            }
        }
    }

}
}