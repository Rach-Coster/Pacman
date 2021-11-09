using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    [SerializeField]
    GameObject cherryPrefab;

    GameObject cherryInstance;

    private bool cherryMade;

    private enum cherryMovementPositions { TopLeft, TopRight, TopMiddle, MiddleLeft, MiddleRight, BottomLeft, BottomRight, BottomMiddle };
    int cherryPosition;

    private List<Vector2> cherrySpawnPositions;

    // Start is called before the first frame update
    void Start()
    {
        cherryMade = false;
        cherrySpawnPositions = new List<Vector2>();
        cherryPosition = -1; 

        CherrySpawnPos();
    }

    // Update is called once per frame
    void Update()
    { 

        if (Mathf.Round(Time.time) % 10 == 0 && !cherryMade)
        {
            Vector2 cherryPos = RandomCherryPosition();

            cherryInstance = Instantiate(cherryPrefab, new Vector2(cherryPos.x, cherryPos.y), Quaternion.identity);        
            cherryPosition = CherryMovement(cherryPos);
          
            cherryMade = true;
        }

        if (cherryMade)
        {
            if (cherryPosition >= 0 && cherryPosition < 3 && cherryInstance.transform.position.y < -50 || 
                cherryPosition == 3 && cherryInstance.transform.position.x > 66 ||
                cherryPosition == 4 && cherryInstance.transform.position.x < -66 ||
                cherryPosition >= 5 && cherryPosition < 8 && cherryInstance.transform.position.y > 50)
            {
                StopAllCoroutines();
                Destroy(cherryInstance);
                cherryMade = false;
            }

            else
            {
                StartCoroutine(CherryLerp());
            }
        }


    }
    IEnumerator CherryLerp()
    {
        float timeElapsed = 0;
        float lerpDuration = 0.2f;

        float currentXPosition = cherryInstance.transform.position.x;
        float currentYPosition = cherryInstance.transform.position.y;

        while (timeElapsed < lerpDuration)
        {

            if (cherryPosition >= 0 && cherryPosition < 3 && cherryInstance.transform.position.y < -50)
            {
                currentYPosition = -50;
                break;
            }

            else if (cherryPosition == 3 && cherryInstance.transform.position.x > 66)
            {
                currentXPosition = 66;
                break;
            }

            else if(cherryPosition == 4 && cherryInstance.transform.position.x < -66)
            {
                currentXPosition = -66;
                break;
            }

            else if (cherryPosition >= 5 && cherryPosition < 8 && cherryInstance.transform.position.y > 50)
            {
                currentYPosition = 50;
                break; 
            }

            if (cherryPosition == (int)cherryMovementPositions.TopLeft)
            {
                timeElapsed += Time.deltaTime;

                cherryInstance.transform.position = Vector2.Lerp(new Vector2(currentXPosition, currentYPosition), new Vector2(currentXPosition + 3, currentYPosition - 3), timeElapsed / lerpDuration);
                yield return null;
            }

            else if (cherryPosition == (int)cherryMovementPositions.MiddleLeft)
            {
                timeElapsed += Time.deltaTime;

                cherryInstance.transform.position = Vector2.Lerp(new Vector2(currentXPosition, currentYPosition), new Vector2(currentXPosition + 3, currentYPosition), timeElapsed / lerpDuration);
                yield return null;
            }

            else if(cherryPosition == (int)cherryMovementPositions.BottomLeft)
            {
                timeElapsed += Time.deltaTime;

                cherryInstance.transform.position = Vector2.Lerp(new Vector2(currentXPosition, currentYPosition), new Vector2(currentXPosition + 3, currentYPosition + 3), timeElapsed / lerpDuration);
                yield return null;
            }

            else if(cherryPosition == (int)cherryMovementPositions.TopMiddle)
            {
                timeElapsed += Time.deltaTime;

                cherryInstance.transform.position = Vector2.Lerp(new Vector2(currentXPosition, currentYPosition), new Vector2(currentXPosition, currentYPosition - 3), timeElapsed / lerpDuration);
                yield return null;
            }

            else if(cherryPosition == (int) cherryMovementPositions.TopRight)
            {
                timeElapsed += Time.deltaTime;

                cherryInstance.transform.position = Vector2.Lerp(new Vector2(currentXPosition, currentYPosition), new Vector2(currentXPosition - 3, currentYPosition - 3), timeElapsed / lerpDuration);
                yield return null;
            }

            else if (cherryPosition == (int)cherryMovementPositions.MiddleRight)
            {
                timeElapsed += Time.deltaTime;

                cherryInstance.transform.position = Vector2.Lerp(new Vector2(currentXPosition, currentYPosition), new Vector2(currentXPosition - 3, currentYPosition), timeElapsed / lerpDuration);
                yield return null;
            }

            else if(cherryPosition == (int)cherryMovementPositions.BottomRight)
            {
                timeElapsed += Time.deltaTime;

                cherryInstance.transform.position = Vector2.Lerp(new Vector2(currentXPosition, currentYPosition), new Vector2(currentXPosition - 3, currentYPosition + 3), timeElapsed / lerpDuration);
                yield return null;
            }

            else if(cherryPosition == (int)cherryMovementPositions.BottomMiddle)
            {
                timeElapsed += Time.deltaTime;

                cherryInstance.transform.position = Vector2.Lerp(new Vector2(currentXPosition, currentYPosition), new Vector2(currentXPosition, currentYPosition + 3), timeElapsed / lerpDuration);
                yield return null;
            }
        }
    }


    void CherrySpawnPos()
    {
        //Vector2 Positions for 3,0 -> 7,0    3,19 -> 7,19   13,0 -> 16,0    13,19 -> 16,19    22,0 ->  26,0    22,19 -> 26,19    0,9 & 0,10    29,9 & 29,10

        float positionY = 38.53f;

        //3,0 - 7,0 && 3,19 - 7,19
        for (var i = 0; i < 5; i++)
        {
            positionY -= 3; 

            cherrySpawnPositions.Add(new Vector2(-23.45f, positionY));
            cherrySpawnPositions.Add(new Vector2(33.55f, positionY));
        }

        positionY = 8.529999f;

        //13,0 - 16,0 && 13,19 - 16,19
        for(var i = 0; i < 4; i++)
        {
            positionY -= 3;

           cherrySpawnPositions.Add(new Vector2(-23.45f, positionY));
           cherrySpawnPositions.Add(new Vector2(33.55f, positionY));
        }

        positionY = -18.47f;

        //22,0 - 26,0 && 22,19 - 26,19
        for (var i = 0; i < 5; i++)
        {
            positionY -= 3;

            cherrySpawnPositions.Add(new Vector2(-23.45f, positionY));
            cherrySpawnPositions.Add(new Vector2(33.55f, positionY));
        }

        //0,9 && 0,10
        cherrySpawnPositions.Add(new Vector2(3.549999f, 44.53f));
        cherrySpawnPositions.Add(new Vector2(6.549999f, 44.53f));

        //29,9 && 29,10
        cherrySpawnPositions.Add(new Vector2(3.549999f, -42.47f));
        cherrySpawnPositions.Add(new Vector2(6.549999f, -42.47f));

    }

    Vector2 RandomCherryPosition()
    {
        int value = Random.Range(0, cherrySpawnPositions.Count - 1);

        return cherrySpawnPositions[value];
    }

    int CherryMovement(Vector2 cherryPos)
    {
        float leftHandSide = -23.45f;
        float rightHandSide = 33.55f;

        float middleTop = 5.529999f;
        float middleBottom = -3.840001f;

        float topYPos = 44.53f;
        float bottomYPos = -42.47f;

        float topMiddleLeft = 3.549999f;
        float topMiddleRight = 6.549999f;


        if (cherryPos.x == leftHandSide || cherryPos.x == leftHandSide - 0.05f)
        {
            //Middle Left
            if (cherryPos.y <= middleTop && cherryPos.y >= middleBottom)
            {
                cherryInstance.transform.position = new Vector2(cherryPos.x - 42, cherryPos.y);
                return (int)cherryMovementPositions.MiddleLeft;
            }

            //Bottom Left
            else if (cherryPos.y < middleBottom)
            {
                cherryInstance.transform.position = new Vector2(cherryPos.x - 42, cherryPos.y - 42);
                return (int)cherryMovementPositions.BottomLeft;
            }

            //Top Left
            else
            {
                cherryInstance.transform.position = new Vector2(cherryPos.x - 42, cherryPos.y + 42);
                return (int)cherryMovementPositions.TopLeft;
            }
        }

        //Top Middle
        else if (cherryPos.x == topMiddleLeft && cherryPos.y == topYPos || cherryPos.x == topMiddleRight && cherryPos.y == topYPos)
        {
            cherryInstance.transform.position = new Vector2(cherryPos.x, cherryPos.y + 10);
            return (int)cherryMovementPositions.TopMiddle;
        }

        //Bottom Middle
        else if (cherryPos.x == topMiddleLeft && cherryPos.y == bottomYPos || cherryPos.x == topMiddleRight && cherryPos.y == bottomYPos)
        {
            cherryInstance.transform.position = new Vector2(cherryPos.x, cherryPos.y - 10);
            return (int)cherryMovementPositions.BottomMiddle;
        }

        else if (cherryPos.x == rightHandSide || cherryPos.x == rightHandSide + 0.05f)
        {
            //Middle Right
            if (cherryPos.y <= middleTop && cherryPos.y >= middleBottom)
            {
                cherryInstance.transform.position = new Vector2(cherryPos.x + 32, cherryPos.y);
                return (int)cherryMovementPositions.MiddleRight;
            }

            //Bottom Right
            else if (cherryPos.y < middleBottom)
            {
                cherryInstance.transform.position = new Vector2(cherryPos.x + 32, cherryPos.y - 32);
                return (int)cherryMovementPositions.BottomRight;
            }

            //Top Right
            else
            {
                cherryInstance.transform.position = new Vector2(cherryPos.x + 32, cherryPos.y + 32);
                return (int)cherryMovementPositions.TopRight;
            }
        }

        else
        {
            //For potential error detection if needed
            Debug.Log(cherryPos.x + " " + cherryPos.y);
            return -1;
        }

    }

}
