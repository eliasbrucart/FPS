using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private int distanceRay;

    public static event Action<Gun> AddScore;
    void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        Vector3 mousePos = Input.mousePosition;

        Ray ray = cam.ScreenPointToRay(mousePos);

        Debug.DrawRay(ray.origin, ray.direction * distanceRay, Color.yellow);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, distanceRay))
            {
                if(hit.collider.gameObject.tag == "Bomb")
                {
                    hit.collider.gameObject.SetActive(false);
                    AddScore?.Invoke(this);
                }
            }
        }
    }
}
