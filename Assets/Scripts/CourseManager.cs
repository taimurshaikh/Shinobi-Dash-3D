using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseManager : MonoBehaviour
{
    public Transform player;
    public GameObject[] prefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    public float zSpawn = 0f;
    public float tileLength = 0f;
    public int numTiles = 5;
    public GameObject terrain;

    void Start()
    {

        for (int i = 0; i < numTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0 , prefabs.Length));
            }
        }       
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z - 50 > zSpawn - (numTiles * tileLength))
        {
            SpawnTile(Random.Range(0 , prefabs.Length));
            DeleteTile();
        }
        terrain.transform.parent = activeTiles[0].transform;
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject currentTile = Instantiate(prefabs[tileIndex], transform.forward * zSpawn, Rotate(transform.rotation));
        FindObjectOfType<PlayerMove>().speedMultiplier += FindObjectOfType<PlayerMove>().speedIncrement;
        activeTiles.Add(currentTile);
        zSpawn += tileLength;
    }

    private Quaternion Rotate(Quaternion baseRot)
    {
        Quaternion rot = baseRot; 
        rot = Quaternion.Euler(0 , 90, 0);
        return rot;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
