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
            return Life;
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
}
