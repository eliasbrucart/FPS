using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;

    [Header("Prefabs")]
    [SerializeField] private Ghost prefabGhost;
    [SerializeField] private Box prefabBox;
    [SerializeField] private Bomb prefabBomb;

    [Header("Time to spawn")]
    [Range(0, 5)]
    [SerializeField] private float timeToSpawnGhost;
    [Range(0, 20)]
    [SerializeField] private float timeToSpawnBox;
    [Range(0, 10)]
    [SerializeField] private float timeToSpawnBomb;

    [Header("Limits of the spawn")]
    [Range(0, 5)]
    [SerializeField] private int limitGhost;
    [ReadOnly(true)] public int cantGhost;
    [Range(0, 5)]
    [SerializeField] private int limitBox;
    [ReadOnly(true)] public int cantBox;
    [Range(0, 5)]
    [SerializeField] private int limitBomb;
    [ReadOnly(true)] public int cantBomb;

    private float timerGhost;
    private float timerBox;
    private float timerBomb;

    public void SpawnQueue()
    {
        timerGhost += Time.deltaTime;
        timerBox += Time.deltaTime;
        timerBomb += Time.deltaTime;
        SpawnSomething(prefabGhost.gameObject, timeToSpawnGhost, ref timerGhost, limitGhost, ref cantGhost);
        SpawnSomething(prefabBox.gameObject, timeToSpawnBox, ref timerBox, limitBox, ref cantBox);
        SpawnSomething(prefabBomb.gameObject, timeToSpawnBomb, ref timerBomb, limitBomb, ref cantBomb);
    }

    private void SpawnSomething(GameObject go, float timeToSpawnGO, ref float timer, int limitGO, ref int actualCount)
    {
        if(timer >= timeToSpawnGO /*&& actualCount <= limitGO*/)
        {
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);
            Instantiate(go, new Vector3(randomX, 0, randomZ), Quaternion.identity);
            //actualCount++;
            timer = 0.0f;
        }
    }

    public void DecreaseCountGhost()
    {
        cantGhost -= 1;
    }

    public void DecreaseCountBox()
    {
        cantBox -= 1;
    }

    public void DecreaseCountBomb()
    {
        cantBomb -= 1;
    }
}
