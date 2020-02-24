using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int rows;

    public int columns;

    private float roomWidth = 50.0f;

    private float roomHeight = 50.0f;

    public GameObject[] gridPrefabs;

    private Room[,] grid;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject RandomRoomPrefab()
    {
        return gridPrefabs[Random.Range(0, gridPrefabs.Length)];
    }

    public void GenerateGrid()
    {
        grid = new Room[columns,rows];
        // for each row
        for (int row = 0; row < rows; row++)
        {
            // for each column in that row
            for (int col = 0; col < columns; col++)
            {
                float xPosition = roomWidth * col;
                float zPosition = roomHeight * row;
                Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);

                GameObject tempRoomObj = Instantiate(RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;

                // Set our room's parent object
                tempRoomObj.transform.parent = this.transform;

                tempRoomObj.name = "Room_" + col + "," + row;

                Room tempRoom = tempRoomObj.GetComponent<Room>();

                if (row == 0)
                {
                    tempRoom.doorNorth.SetActive(false);
                }
                else if (row == rows - 1)
                {
                    tempRoom.doorSouth.SetActive(false);
                }
                else
                {
                    tempRoom.doorSouth.SetActive(false);
                    tempRoom.doorNorth.SetActive(false);
                }

                if (col == 0)
                {
                    tempRoom.doorEast.SetActive(false);
                }
                else if (col == columns - 1)
                {
                    tempRoom.doorWest.SetActive(false);
                }
                else
                {
                    tempRoom.doorEast.SetActive(false);
                    tempRoom.doorWest.SetActive(false);
                }
                grid[col, row] = tempRoom;

            }
        }
    }
}
