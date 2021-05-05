using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int damage;
    [SerializeField] GameObject explosionArea;

    [SerializeField]private float timeToActivate;
    private float timerToActivate;

    [SerializeField]private float timeToDesactivate;
    private float timerToDesactivate;

    [SerializeField]private float timeToDestroy;
    private float timerToDestroy;

    private bool active;
    void Update()
    {
        if(active)
        {
            timerToActivate += Time.deltaTime;
            if(timerToActivate >= timeToActivate)
                timerToDestroy += Time.deltaTime;
            OnExplosion();
        }
    }

    public void OnExplosion()
    { 
        if (timerToActivate >= timeToActivate)
        {
            explosionArea.SetActive(true);
            if (GameManager.instanceGameManager != null)
            {
                GameManager.instanceGameManager.spawner.DecreaseCountBomb();
            }
        }

        if(timerToDestroy >= timeToDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            active = true;
        }
    }
}