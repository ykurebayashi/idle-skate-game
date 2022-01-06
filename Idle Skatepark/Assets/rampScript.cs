using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rampScript : MonoBehaviour
{
    public GameObject theMenu;
    public double money;
    public double coinsPerSec;

    public Text moneyText;
    public Text coinsPerSecText;

    public float timer;
    public float delayAmount = 1f;

    void Start () {
        GameObject moneyObj = GameObject.Find("Money");
        GameObject conisPerSecObj = GameObject.Find("CoinsPerSecond");
        moneyText = moneyObj.GetComponent<Text>();
        coinsPerSecText = conisPerSecObj.GetComponent<Text>();
        getCoinsPerSec();
    }
    // Update is called once per frame
    void Update () {

        // Getting the clicked ramp
        if(Input.GetMouseButtonUp(0)) {
            int layer_mask = LayerMask.GetMask("Ramp");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, layer_mask)) {
                GameObject tempObj = hit.transform.gameObject;
                upgradeMenuActivate(tempObj.GetComponent<rampInfosScript>().name, tempObj.GetComponent<rampInfosScript>().level);
            }
        }

        // Updating UI
        coinsPerSecText.text = coinsPerSec.ToString() + " C/s";
        moneyText.text = money.ToString() + " S-Coins";

        // Adding coins after 1s
        timer += Time.deltaTime;
        if (timer >= delayAmount) {
            timer = 0f;
            money += coinsPerSec;
        }
    }

    public void upgradeMenuActivate(string name, int level) {
        // set the menu on
        theMenu.SetActive(true);

        // change UI
        // Change Name
        GameObject nameUi = theMenu.transform.Find("BuildingName").gameObject;
        Text nameText = nameUi.GetComponent<Text>(); 
        nameText.text= name;

        // Change Level
        GameObject levelUi = theMenu.transform.Find("BuildingLevel").gameObject;
        Text levelText = levelUi.GetComponent<Text>(); 
        levelText.text= level.ToString();
    }

    public void closeUpgradeMenu() {
        theMenu.SetActive(false);
    }

    public void getCoinsPerSec() {
        coinsPerSec = 0;
        GameObject[] allRamps = GameObject.FindGameObjectsWithTag("Ramp"); // Getting all ramps with tag Ramp
        
        for (int i = 0; i < allRamps.Length; i += 1) {
            allRamps[i].GetComponent<rampInfosScript>().updateCPS();
            coinsPerSec += allRamps[i].GetComponent<rampInfosScript>().sentCPS;
        }
    }

    public void improveBuilding() {

        // get the name of the building displayed on UI
        GameObject nameUi = theMenu.transform.Find("BuildingName").gameObject; // pegando o gameobject que representa o texto no UI
        Text nameText = nameUi.GetComponent<Text>(); // nome halfpipe, pad1, pad2, etc
        
        // get this gameobject
        GameObject tempObj = GameObject.Find(nameText.text);
        
        // access this gameobject script and improve its level
        tempObj.GetComponent<rampInfosScript>().level = tempObj.GetComponent<rampInfosScript>().level + 1;

        // change UI
        GameObject levelUi = theMenu.transform.Find("BuildingLevel").gameObject;
        Text levelText = levelUi.GetComponent<Text>(); 
        levelText.text= tempObj.GetComponent<rampInfosScript>().level.ToString();

        
        getCoinsPerSec();
    }
}
