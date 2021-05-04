using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int life;
    public int Life 
    {
        get
        {
            return life;
        }
        set
        {
            life = value;
        }
    }
    void Start()
    {
        life = 100;
    }

    void Update()
    {
        
    }

    public bool IsAlive()
    {
        if (life <= 0)
            return false;
        return true;
    }


   private void OnTriggerEnter(Collider other)
   {
       if(other.gameObject.tag == "Bomb")
       {
           Debug.Log("Hizo trigger!");
           life -= 50;
           other.gameObject.SetActive(false);
       }

       if(other.gameObject.tag == "Box")
        {
            GameManager.instanceGameManager.Score += 100;
            other.gameObject.SetActive(false);
        }
   }
}
