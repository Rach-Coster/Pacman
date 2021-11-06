using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    [SerializeField]
    GameObject cherryPrefab;

    GameObject cherryInstance;

    private bool cherryMade;
    private int startScreenPosition; 

    // Start is called before the first frame update
    void Start()
    {
        cherryMade = false;

    }

    // Update is called once per frame
    void Update()
    {

        if(Mathf.Round(Time.time) % 10 == 0 && !cherryMade)
        {
            cherryInstance = Instantiate(cherryPrefab, new Vector2(-88, 0), Quaternion.identity);
            cherryMade = true; 
        }

        if (cherryMade) 
        {
            if(cherryInstance.transform.position.x == 88)
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
        float lerpDuration = 5;

        float currentXPosition = cherryInstance.transform.position.x;

        while (timeElapsed < lerpDuration)
        {

            if(cherryInstance.transform.position.x == 88)
            {
                currentXPosition = 88;
                break; 
            }

            else 
            {
                timeElapsed += Time.deltaTime;

                cherryInstance.transform.position = Vector2.Lerp(new Vector2(currentXPosition, cherryInstance.transform.position.y), new Vector2(currentXPosition + 88, cherryInstance.transform.position.y), timeElapsed / lerpDuration);
                yield return null;
            }
           
           
        }
    }
}
