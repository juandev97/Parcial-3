using UnityEngine;

public class explosion : MonoBehaviour {
    

    // si la explosion toca un enemigo desaparece
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy"){
            Destroy(other.gameObject);
        }
    }
}