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

    public void Start()
    {
        cancelText.SetActive(false);
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

    public void endBuilding()
    {
        isBuilding = false;

        if(dummyPlacement != null)
        {
            Destroy(dummyPlacement);
        }
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
    }
}
