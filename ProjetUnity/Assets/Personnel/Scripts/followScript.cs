using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followScript : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform player;
    public GameObject self;
    public Renderer rend;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
        if(CherryManager.onCherry == true)
        {
            gameObject.tag = "Untagged";
            rend.material.SetColor("_Color", new Color(0f, 0f, 255f, 1f));
        }
        else
        {
            rend.material.SetColor("_Color", new Color(255f, 0f, 0f, 1f));
            gameObject.tag = "Respawn";
            enemy.speed = 2f + (0.2f * scoreManager.score);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && gameObject.tag == "Untagged")
        {
            enemy.speed = 0f;
            gameObject.transform.position = startPosition;
        }
    }
}
