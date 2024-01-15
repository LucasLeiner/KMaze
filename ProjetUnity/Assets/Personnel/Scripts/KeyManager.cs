using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public Transform KeyPosition;
    public static bool keyTaken;
    // Start is called before the first frame update
    void Start()
    {
        keyTaken = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            keyTaken = true;
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (scoreManager.score >= 20)
        {
            gameObject.transform.position = KeyPosition.position;
        }
    }
}
