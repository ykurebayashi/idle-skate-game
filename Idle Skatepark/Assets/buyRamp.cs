using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyRamp : MonoBehaviour
{
    
    public GameObject theRampToBeBought;
       
    public void buyStore() {
        theRampToBeBought.SetActive(true);
    }
}
