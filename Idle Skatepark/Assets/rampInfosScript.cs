using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rampInfosScript : MonoBehaviour
{
    public int level;
    public string name;
    public int baseCPS; // quantas coins pro segundo no level 1
    public int sentCPS; // coins por segundo enviada para o outro script

    public GameObject theGameManager;
    // Start is called before the first frame update
    void Start()
    {
        theGameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCPS() {
        sentCPS = baseCPS * level;
    }
}
