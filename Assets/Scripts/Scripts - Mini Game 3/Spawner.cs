using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject goodItem;
    public GameObject badItem;

    public int maxItemCount = 3;

    public Vector2 center;
    public Vector2 size;
    [SerializeField] int goodItemCount;
    [SerializeField] int badItemCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Spawn items above for player to avoid or collect
        goodItemCount = GameObject.FindGameObjectsWithTag("GoodItem").Length;
        if (goodItemCount < maxItemCount)
        {
            SpawnGoodItem();
        }
        badItemCount = GameObject.FindGameObjectsWithTag("BadItem").Length;
        if (badItemCount < maxItemCount)
        {
            SpawnBadItem();
        }
    }

    public void SpawnGoodItem()
    {
        Vector2 pos = center + new Vector2(Random.Range(-size.x * 0.5f, size.x * 0.5f), Random.Range(-size.y * 0.5f, size.y * 0.5f));

        Instantiate(goodItem, pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        //shows outline of spawning area used for debugging and adjusting size
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }
    public void SpawnBadItem()
    {
        Vector2 pos = center + new Vector2(Random.Range(-size.x * 0.5f, size.x * 0.5f), Random.Range(-size.y * 0.5f, size.y * 0.5f));

        Instantiate(badItem, pos, Quaternion.identity);
    }
}
