using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngineInternal;

public class PacmanMovement : MonoBehaviour {

    public AudioClip audioClip; 

    [SerializeField]
    GameObject pacman;

    GameObject pm;

    List<TweenLibrary> activeTweens;

    float deltaTime;

    // Start is called before the first frame update
    void Start()
    {
        activeTweens = new List<TweenLibrary>();

        GeneratePacman();
        StartCoroutine(TweenPacman());
        deltaTime = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTweens != null)
        {
            for (var i = 0; i < activeTweens.Count; i++)
            {
                if (Mathf.Abs((activeTweens[i].Target.position.x - activeTweens[i].EndPos.x)) > 0.1f ||
                   (Mathf.Abs((activeTweens[i].Target.position.y - activeTweens[i].EndPos.y)) > 0.1f))
                {
                    
                    float timeFraction = (deltaTime - activeTweens[i].StartTime) / activeTweens[i].Duration;
                    float lengthOfJourney = Vector2.Distance(activeTweens[i].StartPos, activeTweens[i].EndPos);
                    float distanceFraction = timeFraction / lengthOfJourney;

                    activeTweens[i].Target.position = Vector3.Lerp(activeTweens[i].StartPos, activeTweens[i].EndPos, distanceFraction);
                }

                else if (Mathf.Abs((activeTweens[i].Target.position.x - activeTweens[i].EndPos.x)) <= 0.1f ||
                        (Mathf.Abs((activeTweens[i].Target.position.y - activeTweens[i].EndPos.y)) <= 0.1f))
                {
                    activeTweens[i].Target.position = activeTweens[i].EndPos;
                    activeTweens.RemoveAt(i);
                }
            }
        }
        deltaTime += Time.deltaTime;
    }

    void GeneratePacman()
    {
        pm = Instantiate(pacman);
        //-17 1.7f
        pm.transform.position = new Vector2(-17, 1.7f);
        pm.AddComponent<AudioSource>(); 
        pm.GetComponent<SpriteRenderer>().sortingOrder = 1; 
    }

    IEnumerator TweenPacman()
    {
        AddTween(pm.transform, new Vector2(pm.transform.position.x, pm.transform.position.y), new Vector2(-10.4f, 1.7f), 0.4f);
        pm.GetComponent<AudioSource>().clip = audioClip;
        pm.GetComponent<AudioSource>().Play();
        pm.GetComponent<AudioSource>().loop = true; 
        yield return new WaitForSeconds(2.7f);

        pm.GetComponent<AudioSource>().Stop();
        pm.transform.rotation = Quaternion.Euler(0, 0, 90);
        AddTween(pm.transform, new Vector2(pm.transform.position.x, pm.transform.position.y), new Vector2(-10.4f, 18), 0.4f);
        yield return new WaitForSeconds(6.6f);

        pm.transform.rotation = Quaternion.Euler(0, 180, 0);
        AddTween(pm.transform, new Vector2(pm.transform.position.x, pm.transform.position.y), new Vector2(-17.4f, 18), 0.4f);
        yield return new WaitForSeconds(2.7f);

        pm.transform.rotation = Quaternion.Euler(0, 180, 90);
        AddTween(pm.transform, new Vector2(pm.transform.position.x, pm.transform.position.y), new Vector2(-17.4f, 35.5f), 0.4f);
        yield return new WaitForSeconds(7f);

        pm.transform.rotation = Quaternion.Euler(0, 0, 0);
        AddTween(pm.transform, new Vector2(pm.transform.position.x, pm.transform.position.y), new Vector2(-2.3f, 35.5f), 0.4f);
        yield return new WaitForSeconds(6f);

        pm.transform.rotation = Quaternion.Euler(0, 0, -90);
        AddTween(pm.transform, new Vector2(pm.transform.position.x, pm.transform.position.y), new Vector2(-2.3f, 25.5f), 0.4f);
        yield return new WaitForSeconds(4f);

        pm.transform.rotation = Quaternion.Euler(0, 180, 0);
        AddTween(pm.transform, new Vector2(pm.transform.position.x, pm.transform.position.y), new Vector2(-6.86f, 25.5f), 0.4f);
        yield return new WaitForSeconds(1.8f);

        pm.transform.rotation = Quaternion.Euler(0, 180, -90);
        AddTween(pm.transform, new Vector2(pm.transform.position.x, pm.transform.position.y), new Vector2(-6.86f, 18), 0.4f);
        yield return new WaitForSeconds(3);

        pm.transform.rotation = Quaternion.Euler(0, 0, 0);
        AddTween(pm.transform, new Vector2(pm.transform.position.x, pm.transform.position.y), new Vector2(-3.07f, 18), 0.4f);
        yield return new WaitForSeconds(1.5f);

        pm.transform.rotation = Quaternion.Euler(0, 0, -90);
        AddTween(pm.transform, new Vector2(pm.transform.position.x, pm.transform.position.y), new Vector2(-3.07f, 11), 0.4f);
        pm.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.8f);

        pm.transform.rotation = Quaternion.Euler(0, -180, 0);
        AddTween(pm.transform, new Vector2(pm.transform.position.x, pm.transform.position.y), new Vector2(-7, 11), 0.4f);
        yield return new WaitForSeconds(1.5f);

        pm.transform.rotation = Quaternion.Euler(0, -180, -90);
        AddTween(pm.transform, new Vector2(pm.transform.position.x, pm.transform.position.y), new Vector2(-7, 1.7f), 0.4f);
        yield return new WaitForSeconds(3.7f);

        pm.transform.rotation = Quaternion.Euler(0, -180, 0);
        AddTween(pm.transform, new Vector2(pm.transform.position.x, pm.transform.position.y), new Vector2(-17, 1.7f), 0.4f);

    }

    void AddTween(Transform targetObject, Vector2 startPos, Vector2 endPos, float duration)
    {
        TweenLibrary itemTweened = new TweenLibrary(targetObject.transform, startPos, endPos, deltaTime, duration);
        
        activeTweens.Add(itemTweened);
    }


    public Vector2 GetPacmanPosition()
    {
        return new Vector2(pm.transform.position.x, pm.transform.position.y);

    }

    public Transform GetPacmanTransform()
    {
        return pm.transform; 
    }
}
