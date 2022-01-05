using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rampScript : MonoBehaviour
{

    void Start () {
    }
    // Update is called once per frame
    void Update () {
        if(Input.GetMouseButtonUp(0)) {
            int layer_mask = LayerMask.GetMask("Ramp");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, layer_mask)) {
                UnityEngine.Debug.Log(hit.transform.gameObject);
            }
        }
    }
}
