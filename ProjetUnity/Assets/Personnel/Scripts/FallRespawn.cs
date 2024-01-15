using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawn : MonoBehaviour
{
    public float threshold;
    private Vector3 startPosition;


    // Start is called before the first frame update
    private void Start(){
        startPosition = transform.position;
        startPosition.y += 0.1f;
    }

    void OnControllerColliderHit(ControllerColliderHit col){
        if (col.gameObject.CompareTag("Respawn")){
            transform.position = startPosition;
            RestartManager.health -= 1;
        }
    }
}
