using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    static public ScenesManager instanceScenesManager;

    static public ScenesManager Instcane { get { return instanceScenesManager; } }

    private void Awake()
    {
        if(instanceScenesManager != null && instanceScenesManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instanceScenesManager = this;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
