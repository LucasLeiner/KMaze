using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryManager : MonoBehaviour
{

    public GameObject spawnPoints;
    private Transform spawnTransforms;
    private Vector3 startPosition;
    public static bool onCherry;

    // Start is called before the first frame update
    void Start()
    {
        onCherry = false;
        startPosition = transform.position;
        spawnTransforms = spawnPoints.transform;
    }

    private void teleportCherry()
    {
        Transform child = spawnTransforms.GetChild(Random.Range(0, spawnTransforms.childCount));
        gameObject.transform.position = child.position;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine("OnCherry");
        }
    }

    IEnumerator OnCherry()
    {
        onCherry = true;
        gameObject.transform.position = startPosition;
        yield return new WaitForSeconds(10f);
        onCherry = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(coinRespawn.cherrySpawn == true)
        {
            teleportCherry();
            coinRespawn.cherrySpawn = false;
        }
    }
}
