using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public Transform GridParent;
    public Transform DotParent;

<<<<<<< HEAD
    public List<Vector2> edgeList;
    public List<Vector2> cellList;
    public List<Vector2> cellListEstimate;
    public List<Vector2> dotList;
    public List<Vector2> pelletList; 
=======
    public List<Vector2> edgeList; 
>>>>>>> parent of ee38052... Pacman now moves around board without issue

    //Change to const numbers
    [SerializeField]
    int width;

    [SerializeField]
    int height;

    [SerializeField]
    GameObject tile;

    [SerializeField]
    GameObject mazeOuterCorner;

    [SerializeField]
    GameObject mazeOuterLine;

    [SerializeField]
    GameObject mazeInnerLine;

    [SerializeField]
    GameObject mazeInnerCorner;

    [SerializeField]
    GameObject mazeOuterT;

    [SerializeField]
    GameObject mazeInnerDouble; 

    [SerializeField]
    GameObject dot;

    [SerializeField]
    GameObject pellet; 

    [SerializeField]
    GameObject pacman;

    [SerializeField]
    GameObject redGhost;

    [SerializeField]
    GameObject yellowGhost;

    [SerializeField]
    GameObject purpleGhost;

    [SerializeField]
    GameObject greenGhost; 

    private float xPos;
    private float yPos;
    // Start is called before the first frame update
    void Start()
    {
        edgeList = new List<Vector2>();
<<<<<<< HEAD
        cellList = new List<Vector2>();
        cellListEstimate = new List<Vector2>(); 
        dotList = new List<Vector2>();
        pelletList = new List<Vector2>(); 
=======
>>>>>>> parent of ee38052... Pacman now moves around board without issue

        xPos = tile.transform.position.x;
        yPos = tile.transform.position.y;

        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateGrid()
    {
        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                GameObject cell;

                if (i != 0 && j == 0)
                {
                    xPos = -26.45f;
                    cell = Instantiate(tile, new Vector2(xPos += 3, yPos -= 3), Quaternion.identity);
<<<<<<< HEAD
                    cellList.Add(new Vector2(cell.transform.position.x, cell.transform.position.y));
                    cellListEstimate.Add(new Vector2(Mathf.Round(cell.transform.position.x), Mathf.Round(cell.transform.position.y)));
=======
>>>>>>> parent of ee38052... Pacman now moves around board without issue
                }
                else
                {
                    cell = Instantiate(tile, new Vector2(xPos += 3, yPos), Quaternion.identity);
<<<<<<< HEAD
                    cellList.Add(new Vector2(cell.transform.position.x, cell.transform.position.y));
                    cellListEstimate.Add(new Vector2(Mathf.Round(cell.transform.position.x), Mathf.Round(cell.transform.position.y)));
=======
>>>>>>> parent of ee38052... Pacman now moves around board without issue
                }

                cell.name = "Cell " + i + " " + j;
                cell.transform.parent = GridParent.transform;

                GenerateBorderLeft(i, j);
                GenerateBorderRight(i, j);
                GenerateBorderTop(i, j);
                GenerateBorderBottom(i, j);

                GenerateLevelTopLeft(i, j);
                GenerateLevelTopRight(i, j);
                GenerateLevelBottomLeft(i, j);
                GenerateLevelBottomRight(i, j);

                GenerateGhostBorder(i, j);

                GenerateDots(i, j);
                GeneratePellets(i, j);
                GenerateCharacters(i, j); 
            }
        }
    }

    void GenerateBorderLeft(int i, int j)
    {
       
        Vector3 cellPosition = GameObject.Find("Cell " + i + " " + j).GetComponent<Transform>().position;

        if (i == 0 && j == 0)
        {
            Instantiate(mazeOuterCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
        else if (i > 0 && i < 9 && j == 0)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x - 0.37f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 9 && j == 0)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));

        }

        else if (i == 9 && j > 0 && j < 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x, cellPosition.y - 0.37f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 9 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerDouble, new Vector2(cellPosition.x, cellPosition.y - 0.72f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 9 && i < 13 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x + 0.37f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 13 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerDouble, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 13 && j < 3)
        {
            Instantiate(mazeOuterLine, new Vector2(cellPosition.x, cellPosition.y - 0.32f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 16 && j < 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x, cellPosition.y - 0.37f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 16 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerDouble, new Vector2(cellPosition.x, cellPosition.y - 0.72f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 16 && i < 20 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x + 0.37f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 20 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerDouble, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 20 && j > 0 && j < 3)
        {
            Instantiate(mazeOuterLine, new Vector2(cellPosition.x, cellPosition.y - 0.35f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 20 && j == 0)
        {
            Instantiate(mazeOuterCorner, new Vector2(cellPosition.x, cellPosition.y - 0.7f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 20 && i < 29 && j == 0)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x - 0.37f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if(i == 29 && j == 0)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
    }
    void GenerateBorderRight(int i, int j)
    {
        
        Vector3 cellPosition = GameObject.Find("Cell " + i + " " + j).GetComponent<Transform>().position;
        if (i == 0 && j == 19)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i != 0 && i < 9 && j == 19)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x + 0.37f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, -90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 9 && j == 19)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 9 && j > 16 && j < 19)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x, cellPosition.y - 0.37f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 9 && j == 16)
        {
            Instantiate(mazeInnerDouble, new Vector2(cellPosition.x, cellPosition.y - 0.72f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 9 && i < 13 && j == 16)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x - 0.37f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 270);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 13 && j == 16)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerDouble, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 13 && j > 16 && j < 20)
        {
            Instantiate(mazeOuterLine, new Vector2(cellPosition.x, cellPosition.y - 0.32f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 16 && j > 16 && j < 20)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x, cellPosition.y - 0.37f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 16 && j == 16)
        {
            Instantiate(mazeInnerDouble, new Vector2(cellPosition.x, cellPosition.y - 0.72f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 16 && i < 20 && j == 16)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x - 0.37f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 270);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 20 && j == 16)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerDouble, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 20 && j > 16 && j < 19)
        {
            Instantiate(mazeOuterLine, new Vector2(cellPosition.x, cellPosition.y - 0.35f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 20 && j == 19)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterCorner, new Vector2(cellPosition.x, cellPosition.y - 0.7f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 20 && i < 29 && j == 19)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x + 0.37f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 270);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 29 && j == 19)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        } 
    }
    void GenerateBorderTop(int i, int j)
    {
      
        Vector3 cellPosition = GameObject.Find("Cell " + i + " " + j).GetComponent<Transform>().position;

        if (i == 0 && j > 0 && j < 9)
        {
            Instantiate(mazeOuterLine, new Vector2(cellPosition.x, cellPosition.y + 0.36f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        if (i == 0 && j < 19 && j > 10)
        {
            Instantiate(mazeOuterLine, new Vector2(cellPosition.x, cellPosition.y + 0.36f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 0 && j == 9)
        {
            Instantiate(mazeOuterT, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 0 && j == 10)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterT, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i != 0 && i < 4 && j == 10)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.04f, cellPosition.y - 0.01f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
        else if (i != 0 && i < 4 && j == 9)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.04f, cellPosition.y + 0.01f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 4 && j == 9)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.12f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 4 && j == 10)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x - 0.13f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
    }
    void GenerateBorderBottom(int i, int j)
    {
      
        Vector3 cellPosition = GameObject.Find("Cell " + i + " " + j).GetComponent<Transform>().position;
        if (i == 29 && j > 0 && j < 9)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x, cellPosition.y - 0.36f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        if (i == 29 && j < 19 && j > 10)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterLine, new Vector2(cellPosition.x, cellPosition.y - 0.36f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 29 && j == 9)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterT, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 29 && j == 10)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeOuterT, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i < 29 && i > 25 && j == 9)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.04f, cellPosition.y + 0.01f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i < 29 && i > 25 && j == 10)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.04f, cellPosition.y - 0.01f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 25 && j == 9)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.12f, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 25 && j == 10)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x - 0.13f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
    }

    void GenerateLevelTopLeft(int i, int j)
    {

        Vector3 cellPosition = GameObject.Find("Cell " + i + " " + j).GetComponent<Transform>().position;

        //Top of box one in left hand corner
        if (i == 2 && j == 2)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 2 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 3 && j == 2)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 3 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 4 && j == 2)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 4 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }


        //Top of box two in left hand corner 
        else if (i == 2 && j == 5)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
        else if (i == 2 && j == 6)
        {
            Instantiate(mazeInnerLine, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
        else if (i == 2 && j == 7)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 3 && j == 5)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 3 && j == 7)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 4 && j == 6)
        {
            Instantiate(mazeInnerLine, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 4 && j == 5)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 4 && j == 7)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        //Box 3 underneath box 1 

        else if (i == 6 && j == 2)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 6 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 7 && j == 2)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 7 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        // Sideways T shape next to box 3
        else if (i == 6 && j == 5)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 6 && j == 6)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 6 && i < 13 && j == 5)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 13 && j == 5)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 13 && j == 6)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 6 && i < 9 && j == 6 || i > 10 && i < 13 && j == 6)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 9 && j == 6)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.16f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 10 && j == 6)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.16f, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 9 && j == 7)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.01f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 10 && j == 7)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.01f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        //Central T
        else if (i == 6 && j == 8)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.16f, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 6 && j > 8 && j < 11)
        {
            Instantiate(mazeInnerLine, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 6 && j == 11)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
                
        else if (i == 7 && j == 8)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.16f, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 7 && j == 11)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 7 && j == 9)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));

        }

        else if (i == 7 && j == 10)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.1f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if(i > 7 && i < 10 && j == 9)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.08f, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

            
        else if (i > 7 && i < 10 && j == 10)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if(i == 10 && j == 9)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.15f, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }


        else if (i == 10 && j == 10)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x - 0.15f, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
    }
    void GenerateLevelTopRight(int i, int j)
    {
        Vector3 cellPosition = GameObject.Find("Cell " + i + " " + j).GetComponent<Transform>().position;
        //Box one in top right hand corner
        if (i == 2 && j == 16)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 2 && j == 17)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x - 0.1f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 3 && j == 16)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 3 && j == 17)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.03f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 4 && j == 16)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 4 && j == 17)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x - 0.11f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        //Box two in top right hand corner 
        else if (i == 2 && j == 12)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
        else if (i == 2 && j == 13)
        {
            Instantiate(mazeInnerLine, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
        else if (i == 2 && j == 14)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 3 && j == 12)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 3 && j == 14)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 4 && j == 13)
        {
            Instantiate(mazeInnerLine, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 4 && j == 12)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 4 && j == 14)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        //Box 3 underneath box 1 

        else if (i == 6 && j == 16)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.1f, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 6 && j == 17)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 7 && j == 16)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.1f, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 7 && j == 17)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        // Sideways T shape next to box 3
        else if (i == 6 && j == 13)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 6 && j == 14)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 6 && i < 13 && j == 14)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 13 && j == 14)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 13 && j == 13)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 6 && i < 9 && j == 13 || i > 10 && i < 13 && j == 13)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 9 && j == 13)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x - 0.16f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 10 && j == 13)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x - 0.16f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 9 && j == 12)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y - 0.01f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 10 && j == 12)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.01f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
    }
    void GenerateLevelBottomLeft(int i, int j)
    {
      
        Vector3 cellPosition = GameObject.Find("Cell " + i + " " + j).GetComponent<Transform>().position;

        //Box one in bottom left hand corner 
        if(i == 25 && j == 2)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 25 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 26 && j == 2)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 26 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 27 && j == 2)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 27 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        //Box two in bottom left hand corner

        else if (i == 25 && j == 5)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
        else if (i == 25 && j == 6)
        {
            Instantiate(mazeInnerLine, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
        else if (i == 25 && j == 7)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 26 && j == 5)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 26 && j == 7)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 27 && j == 6)
        {
            Instantiate(mazeInnerLine, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 27 && j == 5)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 27 && j == 7)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        //Box three on top of box one

        else if (i == 22 && j == 2)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 22 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 23 && j == 2)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 23 && j == 3)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        //T Shaped box next to box 3

        else if (i == 16 && j == 5)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 16 && j == 6)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 16 && i < 23 && j == 5)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 23 && j == 5)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 23 && j == 6)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 16 && i < 19 && j == 6 || i > 20 && i < 23 && j == 6)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 19 && j == 6)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.16f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 20 && j == 6)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.16f, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 19 && j == 7)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y - 0.02f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 20 && j == 7)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.02f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        //Central T

        else if (i == 23 && j == 8)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.16f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 23 && j > 8 && j < 11)
        {
            Instantiate(mazeInnerLine, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 23 && j == 11)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 22 && j == 8)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.16f, cellPosition.y - 0.1f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }


        else if (i == 22 && j == 11)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y - 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 22 && j == 9)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y - 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));

        }

        else if (i == 22 && j == 10)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y - 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }



        else if (i > 19 && i < 22 && j == 9)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.08f, cellPosition.y - 0.1f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }


        else if (i > 19 && i < 22 && j == 10)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y - 0.1f), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }


        else if (i == 19 && j == 9)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.15f, cellPosition.y - 0.1f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 19 && j == 10)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x - 0.15f, cellPosition.y - 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
    }
    void GenerateLevelBottomRight(int i, int j)
    {
     
        Vector3 cellPosition = GameObject.Find("Cell " + i + " " + j).GetComponent<Transform>().position;

        //Box one bottom right hand corner 

        if (i == 25 && j == 16)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 25 && j == 17)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x - 0.1f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 26 && j == 16)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 26 && j == 17)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.03f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 27 && j == 16)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 27 && j == 17)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x - 0.11f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        //Box two in bottom right hand corner 

        else if (i == 25 && j == 12)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
        else if (i == 25 && j == 13)
        {
            Instantiate(mazeInnerLine, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
        else if (i == 25 && j == 14)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 26 && j == 12)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 26 && j == 14)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 27 && j == 13)
        {
            Instantiate(mazeInnerLine, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 27 && j == 12)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 27 && j == 14)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        //Box three on top of box one
        else if (i == 22 && j == 16)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.1f, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 22 && j == 17)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 23 && j == 16)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x + 0.1f, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 23 && j == 17)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.1f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        //Sideways T shape next to box 3

        else if (i == 16 && j == 13)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 16 && j == 14)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 16 && i < 23 && j == 14)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 23 && j == 14)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 23 && j == 13)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i > 16 && i < 19 && j == 13 || i > 20 && i < 23 && j == 13)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 19 && j == 13)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x - 0.16f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 20 && j == 13)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x - 0.16f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 19 && j == 12)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y - 0.02f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 20 && j == 12)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y + 0.02f), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }
    }
    void GenerateGhostBorder(int i, int j)
    {
      
        Vector3 cellPosition = GameObject.Find("Cell " + i + " " + j).GetComponent<Transform>().position;

        if (i == 12 && j == 8)
        {
            Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 12 && j == 11)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, 1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i < 17 && i > 12 && j == 11)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x + 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i < 17 && i > 12 && j == 8)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerLine, new Vector2(cellPosition.x - 0.08f, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 17 && j == 8)
        {
            GameObject rotatingObject; 
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if (i == 17 && j == 11)
        {
            GameObject rotatingObject;
            rotatingObject = Instantiate(mazeInnerCorner, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            rotatingObject.transform.localScale = new Vector2(-1, -1);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }

        else if(i == 17 && j > 8 && j < 11)
        {
            Instantiate(mazeInnerLine, new Vector2(cellPosition.x, cellPosition.y + 0.01f), Quaternion.identity);
            edgeList.Add(new Vector2(cellPosition.x, cellPosition.y));
        }   
    }

    void GenerateDots(int i, int j)
    {
        //Todo: Clean up
        Vector3 cellPosition = GameObject.Find("Cell " + i + " " + j).GetComponent<Transform>().position;
        GameObject circle; 

        if (i == 1 && j > 1 && j < 9)
        {
            circle = Instantiate(dot, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            circle.transform.parent = DotParent.transform; 
            circle.name = "Dot " + i + " " + j;
            dotList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }

        else if (i > 1 && i < 5 && j == 8 || i > 1 && i < 5 && j == 11 || i > 24 && i < 28 && j == 8 || i > 24 && i < 28 && j == 11)
        {
            circle = Instantiate(dot, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            circle.transform.parent = DotParent.transform;
            circle.name = "Dot " + i + " " + j;
            dotList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }

        else if (i == 1 && j > 10 && j < 19 || i == 28 && j > 10 && j < 19)
        {
            circle = Instantiate(dot, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            circle.transform.parent = DotParent.transform;
            circle.name = "Dot " + i + " " + j;
            dotList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }

        else if (i > 1 && i < 5 && j == 4 || i > 1 && i < 5 && j == 15 || i > 24 && i < 28 && j == 4 || i > 24 && i < 28 && j == 15)
        {
            circle = Instantiate(dot, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            circle.transform.parent = DotParent.transform;
            circle.name = "Dot " + i + " " + j;
            dotList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }

        else if (i == 2 && j == 1 || i == 2 && j == 18)
        {
            circle = Instantiate(dot, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            circle.transform.parent = DotParent.transform;
            circle.name = "Dot " + i + " " + j;
            dotList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }

        else if(i > 3 && i < 9 && j == 1 || i > 3 && i < 9 && j == 18 || i > 20 && i < 27 && j == 1 || i > 20 && i < 27 && j == 18)
        {
            circle = Instantiate(dot, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            circle.transform.parent = DotParent.transform;
            circle.name = "Dot " + i + " " + j;
            dotList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }

        else if(i == 5 && j > 1 && j < 18 || i == 24 && j > 1 && j < 18)
        {
            circle = Instantiate(dot, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            circle.transform.parent = DotParent.transform;
            circle.name = "Dot " + i + " " + j;
            dotList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }

        else if (i > 5 && i < 9 && j == 7 || i > 5 && i < 9 && j == 12 || i > 20 && i < 24 && j == 7 || i > 20 && i < 24 && j == 12)
        {
            circle = Instantiate(dot, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            circle.transform.parent = DotParent.transform;
            circle.name = "Dot " + i + " " + j;
            dotList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }

        else if (i > 5 && i < 23 && j == 4 || i > 5 && i < 23 && j == 15)
        {
            circle = Instantiate(dot, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            circle.transform.parent = DotParent.transform;
            circle.name = "Dot " + i + " " + j;
            dotList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }

        else if (i == 8 && j > 1 && j < 4 || i == 8 && j > 15 && j < 18 || i == 21 && j > 1 && j < 4 || i == 21 && j > 15 && j < 18)
        {
            circle = Instantiate(dot, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            circle.transform.parent = DotParent.transform;
            circle.name = "Dot " + i + " " + j;
            dotList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }

        else if (i > 7 && i < 11 && j == 8 || i > 7 && i < 11 && j == 11 || i > 18 && i < 22 && j == 8 || i > 18 && i < 22 && j == 11)
        {
            circle = Instantiate(dot, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            circle.transform.parent = DotParent.transform;
            circle.name = "Dot " + i + " " + j;
            dotList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }

        else if (i == 11 && j > 6 && j < 13 || i == 18 && j > 6 && j < 13)
        {
            circle = Instantiate(dot, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            circle.transform.parent = DotParent.transform;
            circle.name = "Dot " + i + " " + j;
            dotList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }

        else if (i == 28 && j > 0 && j < 9)
        {
            circle = Instantiate(dot, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
            circle.transform.parent = DotParent.transform;
            circle.name = "Dot " + i + " " + j;
            dotList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }
    }
    void GeneratePellets(int i, int j)
    {
        Vector3 cellPosition = GameObject.Find("Cell " + i + " " + j).GetComponent<Transform>().position;

        if (i == 3 && j == 1 || i == 3 && j == 18 || i == 27 && j == 1 || i == 27 && j == 18)
        {
            Instantiate(pellet, new Vector2(cellPosition.x, cellPosition.y + 0.01f), Quaternion.identity);
            pelletList.Add(new Vector2(Mathf.Round(cellPosition.x), Mathf.Round(cellPosition.y)));
        }
    }

    void GenerateCharacters(int i, int j)
    {
 
        Vector3 cellPosition = GameObject.Find("Cell " + i + " " + j).GetComponent<Transform>().position;
        if(i == 1 && j == 1)
        {
            Instantiate(pacman, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
        }

        else if(i == 16 && j == 9)
        {
            Instantiate(redGhost, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
        }

        else if(i == 16 && j == 10)
        {
            Instantiate(yellowGhost, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
        }

        else if(i == 14 && j == 9)
        {
            Instantiate(purpleGhost, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
        }

        else if(i == 14 && j == 10)
        {
            Instantiate(greenGhost, new Vector2(cellPosition.x, cellPosition.y), Quaternion.identity);
        }
    }
}
