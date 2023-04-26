using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;

    public int xRange;
    public int yRange;


    void Start()
    {
        spawnObjects();
    }

    public void spawnObjects()
    {
        destroyObjects();
        int randomItem = 0;
        GameObject toSpawn;
        //MeshCollider c = quad.GetComponent<MeshCollider>();
        

        float screenX, screenY;
        Vector2 pos;

        for(int i = 0; i < numberToSpawn; i++)
        {
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];

            screenX = Random.Range(-xRange, xRange);
            screenY = Random.Range(-yRange,yRange);
            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            Debug.Log("Instantiated a " +  toSpawn.name);
        }
    }
    private void destroyObjects()
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }


}
