using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColumnManager : MonoBehaviour
{
    public GameObject columnPrefab;     
    public int columnPoolSize = 5;      
    public float spawnRate = 3f;        
    public float columnYMin = -1f;      
    public float columnYMax = 3.5f;     
    public Vector3 standbyPos = new Vector3(-15, -25); 
    public float spawnXPos = 10f;
    private GameObject[] columns;
    private int currentColumn = 0;
    private float spawnTimer = 0f;
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = Instantiate(columnPrefab, standbyPos, Quaternion.identity);
        }
    }
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            spawnTimer = 0f;
            SpawnColumn();
        }
    }
    void SpawnColumn()
    {
        float spawnYPos = Random.Range(columnYMin, columnYMax);
        GameObject column = columns[currentColumn];
        column.transform.position = new Vector2(spawnXPos, spawnYPos);
        currentColumn++; 
        if (currentColumn >= columnPoolSize)
        {
            currentColumn = 0;
        }
    }
}
