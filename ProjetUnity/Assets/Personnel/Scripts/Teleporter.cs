using BUT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teleporter : MonoBehaviour
{
    public GameObject teleportTo;
    public GameObject player;
    private Vector3 teleportCoord;
    private bool onTeleporter;
    public GameObject hintMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        teleportCoord = teleportTo.transform.position;
        onTeleporter = false;
        hintMenuUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && scoreManager.score < 20)
        {
            hintMenuUI.SetActive(true);
            onTeleporter = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            hintMenuUI.SetActive(false);
            onTeleporter = false;
        }
    }

    public void Teleport(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (onTeleporter && scoreManager.score < 20)
            {
                player.transform.position = teleportCoord;
                onTeleporter = false;
            }
        }
    }
}
