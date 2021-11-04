using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    GameObject pacman;
    string lastInput;
    string currentInput;

    public GameObject GameManager;
    private TileGenerator tileGenerator;

    // Start is called before the first frame update
    void Start()
    {
        lastInput = " ";
        currentInput = " ";

        GameManager = GameObject.Find("GameManager");
        tileGenerator = GameManager.GetComponent<TileGenerator>();

        pacman = GameObject.Find("PacmanMouthOpen(Clone)");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = KeyCode.W.ToString();
            currentInput = KeyCode.W.ToString();
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = KeyCode.S.ToString();
            currentInput = KeyCode.S.ToString();
        }

 
        else if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = KeyCode.A.ToString();
            currentInput = KeyCode.A.ToString();
        }


        else if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = KeyCode.D.ToString();
            currentInput = KeyCode.D.ToString();
        }


        if (currentInput == "W")
        {
            StartCoroutine(LerpUp());
        }

        else if (currentInput == "S")
        {
            StartCoroutine(LerpDown());
        }

        else if (currentInput == "A")
        {
            StartCoroutine(LerpRight());
        }

        else if (currentInput == "D")
        {
            StartCoroutine(LerpLeft());
        }


        if (tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x, pacman.transform.position.y + 3)))
        {
            StopAllCoroutines();
        }

        else if (tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x, pacman.transform.position.y - 3)))
        {
            StopAllCoroutines();
        }

        else if (tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x - 3, pacman.transform.position.y)))
        {
            StopAllCoroutines();
        }

        else if (tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x + 3, pacman.transform.position.y)))
        {
            StopAllCoroutines();
        }


      

     
    }

    IEnumerator LerpUp()
    {
        float timeElapsed = 0;
        float lerpDuration = 1;

        float currentYPosition = pacman.transform.position.y;


        while (timeElapsed < lerpDuration)
        {
            if (tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x, currentYPosition + 3)))
            {
                Debug.Log("In coroutine " + currentYPosition);
                break;
            }

            else
            {
                timeElapsed += Time.deltaTime;

                pacman.transform.position = Vector2.Lerp(new Vector2(pacman.transform.position.x, currentYPosition), new Vector2(pacman.transform.position.x, currentYPosition + 3), timeElapsed / lerpDuration);
                yield return null;
            }
        }
    }
    IEnumerator LerpDown()
    {
        float timeElapsed = 0;
        float lerpDuration = 1;

        float currentYPosition = pacman.transform.position.y;


        while (timeElapsed < lerpDuration)
        {
            if (tileGenerator.edgeList.Contains(new Vector2(pacman.transform.position.x, currentYPosition - 3)))
            {
                Debug.Log("In coroutine " + currentYPosition);
                break;
            }

            else
            {
                timeElapsed += Time.deltaTime;

                pacman.transform.position = Vector2.Lerp(new Vector2(pacman.transform.position.x, currentYPosition), new Vector2(pacman.transform.position.x, currentYPosition - 3), timeElapsed / lerpDuration);
                yield return null;
            }
        }
    }
    IEnumerator LerpLeft()
    {
         float timeElapsed = 0;
         float lerpDuration = 1; 

         float currentXPosition = pacman.transform.position.x;


        while (timeElapsed < lerpDuration)
        {
            if (tileGenerator.edgeList.Contains(new Vector2(currentXPosition + 3, pacman.transform.position.y)))
            {
                Debug.Log("In coroutine " + currentXPosition);
                break;  
            }

            else
            {
                timeElapsed += Time.deltaTime;

                pacman.transform.position = Vector2.Lerp(new Vector2(currentXPosition, pacman.transform.position.y), new Vector2(currentXPosition + 3, pacman.transform.position.y), timeElapsed / lerpDuration);
                yield return null;
            }
        }
    }
    IEnumerator LerpRight()
    {
        float timeElapsed = 0;
        float lerpDuration = 1;

        float currentXPosition = pacman.transform.position.x;


        while (timeElapsed < lerpDuration)
        {
            if (tileGenerator.edgeList.Contains(new Vector2(currentXPosition - 3, pacman.transform.position.y)))
            {
                Debug.Log("In coroutine " + currentXPosition);
                break;
            }

            else
            {
                timeElapsed += Time.deltaTime;

                pacman.transform.position = Vector2.Lerp(new Vector2(currentXPosition, pacman.transform.position.y), new Vector2(currentXPosition - 3, pacman.transform.position.y), timeElapsed / lerpDuration);
                yield return null;
            }
        }
    }



    


}


