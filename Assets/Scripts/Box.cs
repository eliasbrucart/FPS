using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject boxPrefab;
    public List<GameObject> boxesRandom = new List<GameObject>();

    [SerializeField] private int amountOfBoxes;

    private float timeToSpawm;
    private float timeToDestroy;

    public void SpawnBox()
    {
        timeToSpawm += Time.deltaTime;
        if(timeToSpawm >= 20.0f)
        {
            for(int i = 0; i < amountOfBoxes; i++)
            {
                float randomX = Random.Range(40.0f, 130.0f);
                float randomY = Random.Range(40.0f, 210.0f);
                GameObject go = Instantiate(boxPrefab, new Vector3(randomX, 0.0f, randomY), Quaternion.identity);
                boxesRandom.Add(go);
            }
            timeToSpawm = 0.0f;
        }
    }

    public void DeleteBox()
    {
        timeToDestroy += Time.deltaTime;
        if(timeToDestroy >= 25.0f)
        {
            for(int i = 0; i < boxesRandom.Count; i++)
            {
                Destroy(boxesRandom[i].gameObject);
                boxesRandom.RemoveAt(i);
            }
            timeToDestroy = 0.0f;
        }
    }
}
