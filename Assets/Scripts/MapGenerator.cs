using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    public Transform[] mapTilePrefabs;

    int[,] mapArray =
        {
            {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
            {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
            {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
            {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
            {1,2,2,2,2,3,5,4,3,4,4,3,0,4},
            {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
            {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
            {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
            {2,2,2,2,2,3,5,3,3,0,4,0,0,0},
            {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
        };

    float[,] tileRotations =
    {
        {0,270,270,270,270,270,270,270,270,270,270,270,270,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,270,270,270,0,0,270,270,270,270,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,90,270,270,180,0,90,270,270,270,180,0,90},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,270,270,270,0,0,270,0,0,270,270,270},
        {0,0,90,270,270,180,0,0,0,0,90,270,270,270},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {90,90,90,90,90,270,0,0,90,270,270,270,0,0},
        {0,0,0,0,0,0,0,0,0,270,270,180,0,90},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,270,270,0},
        {270,270,270,270,270,180,0,90,180,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };

    // Start is called before the first frame update
    void Start()
    { 
        GenerateCityMap();

        if (transform.tag == "MapTopRight")
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else if (transform.tag == "MapBottomLeft")
        {
            transform.rotation = Quaternion.Euler(0, 180, 180);
        } else if (transform.tag == "MapBottomRight")
        {
            transform.rotation = Quaternion.Euler(180, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateCityMap()
    {
        Vector3 parentPosition = transform.position;

        for (int y=0; y < mapArray.GetLength(0); y++)
        {
            for (int x = 0; x < mapArray.GetLength(1); x++)
            {
                int tileType = mapArray[y, x];
                if (tileType != 0)
                {
                    float tileRotation = tileRotations[y, x];
                    Vector3 tilePosition = new Vector3(x, -y, 0) + parentPosition;


                    Transform tile = Instantiate(mapTilePrefabs[tileType], tilePosition, Quaternion.identity);
                    tile.parent = transform;

                    tile.eulerAngles = new Vector3(0, 0, tileRotation);
                }
            }
        }
    }
}
