using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placementController : MonoBehaviour
{
    public shopManager shopManager;
    public GameObject basicTowerObject;
    public GameObject sniperTowerObject;
    public GameObject fastTowerObject;
    public GameObject slowTowerObject;
    public GameObject splashTowerObject;
    private GameObject dummyPlacement;
    public Camera cam;
    private GameObject hoverTile;
    public LayerMask mask;
    public LayerMask towerMask;
    public bool isBuilding;
    private GameObject currentTowerPlacing;
    public GameObject cancelText;
    public GameObject basicTowerPop;
    public GameObject sniperTowerPop;
    public GameObject fastTowerPop;
    public GameObject slowTowerPop;
    public GameObject AOETowerPop;
    public GameObject FoundObject;
    public string RaycastReturn;

    public void Start()
    {
        cancelText.SetActive(false);
        basicTowerPop.SetActive(false);
    }
    public Vector2 GetMousePosition()
    {
       return cam.ScreenToWorldPoint(Input.mousePosition); 
    }

    public void getCurrentHoverTile()
    {
        Vector2 mousePosition = GetMousePosition();

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0,0), 0.1f, mask, -100, 100);

        if(hit.collider != null)
        {
            if(mapGenerator.mapTiles.Contains(hit.collider.gameObject))
            {
                if(!mapGenerator.pathTiles.Contains(hit.collider.gameObject))
                {
                    hoverTile = hit.collider.gameObject;
                }
            }
        }
    }

    public bool CheckForTower()
    {
        bool towerOnSlot = false;

        Vector2 mousePosition = GetMousePosition();

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0,0),0.1f, towerMask, -100, 100);

        if(hit.collider != null)
        {
            towerOnSlot = true;
        }

        return towerOnSlot;
    }

    public void placeBuilding()
    {
        if(hoverTile != null)
        {
            if(CheckForTower() == false)
            {
                if(shopManager.canBuyTower(currentTowerPlacing) == true)
                {
                    GameObject newTowerObject = Instantiate(currentTowerPlacing);
                    newTowerObject.layer = LayerMask.NameToLayer("Tower");
                    newTowerObject.transform.position = hoverTile.transform.position;

                    endBuilding();
                    shopManager.buyTower(currentTowerPlacing);
                }
                else
                {
                    Debug.Log("Not enough money!!");
                }
            }
        }
    }

    public void startBuilding(GameObject towerToBuild)
    {
        if(isBuilding == false)
        {
            isBuilding = true;
            currentTowerPlacing = towerToBuild;
            cancelText.SetActive(true);

            dummyPlacement = Instantiate(currentTowerPlacing);

            if(dummyPlacement.GetComponent<Tower>() != null)
            {
                Destroy(dummyPlacement.GetComponent<Tower>());
            }

            if(dummyPlacement.GetComponent<barrelTargeting>() != null)
            {
                Destroy(dummyPlacement.GetComponent<barrelTargeting>());
            }
        }
        else{
            endBuilding();
            startBuilding(towerToBuild);
        }
    }

    public void endBuilding()
    {
        isBuilding = false;

        if(dummyPlacement != null)
        {
            Destroy(dummyPlacement);
        }
    }

     IEnumerator basicPopUp()
     {
        basicTowerPop.SetActive(true);
        yield return new WaitForSeconds(5f);
        basicTowerPop.SetActive(false);
     }
     IEnumerator fastPopUp()
     {
        fastTowerPop.SetActive(true);
        yield return new WaitForSeconds(5f);
        fastTowerPop.SetActive(false);
     }
     IEnumerator sniperPopUp()
     {
        sniperTowerPop.SetActive(true);
        yield return new WaitForSeconds(5f);
        sniperTowerPop.SetActive(false);
     }
     IEnumerator slowPopUp()
     {
        slowTowerPop.SetActive(true);
        yield return new WaitForSeconds(5f);
        slowTowerPop.SetActive(false);
     }
     IEnumerator AOEPopUp()
     {
        AOETowerPop.SetActive(true);
        yield return new WaitForSeconds(5f);
        AOETowerPop.SetActive(false);
     }

    public void Update()
    {
        if(isBuilding == true)
        {
            
            if(dummyPlacement != null)
            {
                getCurrentHoverTile();
                if(hoverTile != null)
                {
                    dummyPlacement.transform.position = hoverTile.transform.position;
                }
            }
            if(Input.GetButtonDown("Fire1"))
            {
                Vector2 mousePosition = GetMousePosition();
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0,0), 0.1f, mask, -100, 100);

                if(hit.collider != null)
                {

                placeBuilding();
                cancelText.SetActive(false);
                }
            }

            if(Input.GetKeyDown(KeyCode.X))
            {
                endBuilding();
                cancelText.SetActive(false);
            }
        }
        else if(isBuilding == false)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Vector2 mousePosition = GetMousePosition();
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0,0), 0.1f, mask, -100, 100);

                if(hit.collider != null)
                {
                    RaycastReturn = hit.collider.gameObject.name;
                    FoundObject = GameObject.Find(RaycastReturn);
                    int layer = FoundObject.layer;
                    string layerName = LayerMask.LayerToName(layer);
                    if(layerName == "Tower"){
                        if(FoundObject.name == "basicTower(Clone)")
                        {
                            StartCoroutine("basicPopUp");
                        }
                        if(FoundObject.name == "sniperTower(Clone)")
                        {
                            StartCoroutine("sniperPopUp");
                        }
                        if(FoundObject.name == "fastTower(Clone)")
                        {
                            StartCoroutine("fastPopUp");
                        }
                        if(FoundObject.name == "slowTower(Clone)")
                        {
                            StartCoroutine("slowPopUp");
                        }
                        if(FoundObject.name == "AOETower(Clone)")
                        {
                            StartCoroutine("AOEPopUp");
                        }
                    }
                }


            }

        }


    }
}
