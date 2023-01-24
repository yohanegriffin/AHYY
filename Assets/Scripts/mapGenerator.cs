using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    public GameObject mapTile;

    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHeight;

    private List<GameObject> mapTiles = new List<GameObject>();
    private List<GameObject> pathTiles = new List<GameObject>();

    private GameObject currentTile;
    private int currentIndex;
    private int nextIndex;

    public Color pathColor;

    private void Start()
    {
        generateMap();
    }

    private List<GameObject> getTopEdgeTiles()
    {
        List<GameObject> edgeTiles = new List<GameObject>();

        for (int i = mapWidth * (mapHeight-1); i < mapWidth * mapHeight; i++)
        {
            edgeTiles.Add(mapTiles[i]);

        }


        return edgeTiles;
    }

    private List<GameObject> getBottomEdgeTiles()
    {
        List<GameObject> edgeTiles = new List<GameObject>();

        for(int i = 0; i < mapWidth; i++)
        {
            edgeTiles.Add(mapTiles[i]);
        }

        return edgeTiles;
    }

    private void Up()
    {

    pathTiles.Add(currentTile);
    currentIndex = mapTiles.IndexOf(currentTile);
    nextIndex = currentIndex + mapWidth;
    currentTile = mapTiles[nextIndex];

    }

    private void Down()
    {

    pathTiles.Add(currentTile);
    currentIndex = mapTiles.IndexOf(currentTile);
    nextIndex = currentIndex - mapWidth;
    currentTile = mapTiles[nextIndex];

    }

    private void Left()
    {

    pathTiles.Add(currentTile);
    currentIndex = mapTiles.IndexOf(currentTile);
    nextIndex = currentIndex - 1;
    currentTile = mapTiles[nextIndex];

    }

    private void Right()
    {

    pathTiles.Add(currentTile);
    currentIndex = mapTiles.IndexOf(currentTile);
    nextIndex = currentIndex + 1;
    currentTile = mapTiles[nextIndex];

    }

    private void generateMap()
    {
        for(int y = 0; y < mapHeight; y++)
        {
            for(int x = 0; x < mapWidth; x++)
            {
                GameObject newTile = Instantiate(mapTile);

                mapTiles.Add(newTile);

                newTile.transform.position = new Vector2(x, y);
            }

        }
        List<GameObject> topEdgeTiles = getTopEdgeTiles();
        List<GameObject> bottomEdgeTiles = getBottomEdgeTiles();

        GameObject startTile = topEdgeTiles[2];
        GameObject endTile = bottomEdgeTiles[6];

        currentTile = startTile;


        //Start of stupid map generation
        Down();
        Down();
        Down();
        Down();
        
        Right();
        Right();
        Right();
        Right();
        
        Up();
        Up();
        Right();
        Right();
        Right();
        Right();
        Down();
        Down();
        Down();
        Down();
        Left();
        Left();
        Left();
        Left();
        Left();
        Left();
        Left();
        Down();
        Down();
        Down();
        Down();
        Right();
        Right();
        Right();
        Down();
        Down();
        pathTiles.Add(endTile);
        // end of map generation

        foreach (GameObject obj in pathTiles)
        {
            obj.GetComponent<SpriteRenderer>().color = pathColor;
        }
    }
}
