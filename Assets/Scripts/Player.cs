using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int life;

    [SerializeField]private float playerInmune;
    [SerializeField]private float timerFlag;
    private bool flag;
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
        flag = false;
    }

    void Update()
    {
        if (timerFlag <= playerInmune && flag)
            timerFlag += Time.deltaTime;
        else
        {
            flag = false;
            timerFlag = 0.0f;
        }
    }

    public bool IsAlive()
    {
        if (life <= 0)
            return false;
        return true;
    }


   private void OnTriggerEnter(Collider other)
   { 
       if(other.gameObject.tag == "explosionArea" && flag == false)
       {
           life -= 50;
           flag = true;
       }
   
       if(other.gameObject.tag == "Box")
       {
            GameManager.instanceGameManager.Score += 100;
            other.gameObject.SetActive(false);
       }
   }
}
