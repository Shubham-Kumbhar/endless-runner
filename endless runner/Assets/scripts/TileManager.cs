using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{   public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    public float tileLength = 12.0f;
    public float safeZone = 2;
    public int lastPrefabIndex = 0;
    private int amnTileOnScreen = 10;


    public List<GameObject> activeTiles;


    // Start is called before the first frame update
    void Start()
    {   
       activeTiles = new List<GameObject>();
      playerTransform = GameObject.FindGameObjectWithTag ("Player").transform; 
       for (int i = 0 ; i<amnTileOnScreen; i ++)
       {    if ( i<2)
                SpawnTile(0);
            else
                SpawnTile();
       }
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerTransform.position.z - safeZone)  > (spawnZ - amnTileOnScreen* tileLength))
        {
            SpawnTile ();
            RemoveTile();
        }
    }




    public void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        
        if(prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomTileIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

        go.transform.SetParent (transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add (go);
    }

    public void RemoveTile()
    {
        Destroy(activeTiles [0]);
        activeTiles.RemoveAt(0);
    }

    public int RandomTileIndex()
    {
        if(tilePrefabs.Length <=1)
        return 0;

        int RandomIndex = lastPrefabIndex;
        while (RandomIndex == lastPrefabIndex)
        {
            RandomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = RandomIndex;
        return RandomIndex;
    }
}
