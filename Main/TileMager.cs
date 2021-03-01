using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMager : MonoBehaviour
{
    public GameObject[] TilePrefabe;
    private float spanwz = 0.0f;
    private float tileLength = 75.0f;
    private Transform Player;
    private int amnTileOnScreen = 3;
    private List<GameObject> activeTiles;
    public float safeZone = 77.0f;
    private int lastPrefabeIndex =0;
    void Start()
    {
        activeTiles = new List<GameObject>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;

       for(int i = 0; i < amnTileOnScreen; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Player.position.z -safeZone > (spanwz - amnTileOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

   private void SpawnTile(int prefabe = -1)
    {
        GameObject go = Instantiate(TilePrefabe[RandomPrefabeIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spanwz;
        spanwz += tileLength;
        activeTiles.Add(go);

    }
   private void DeleteTile()
    {


        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
        

    }
    private int RandomPrefabeIndex()
    {
        if (TilePrefabe.Length <= 1)
            return 0;
        int randomIndex = lastPrefabeIndex;
        while(randomIndex == lastPrefabeIndex)
        {
            randomIndex = Random.Range(0, TilePrefabe.Length);
        }
        lastPrefabeIndex = randomIndex;
        return randomIndex;
    }
}
