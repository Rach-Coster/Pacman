using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenLibrary { 
    public Transform Target { get; private set; }
    public Vector2 StartPos { get; private set; }
    public Vector2 EndPos { get; private set; }
    public float StartTime { get; private set; }
    public float Duration { get; private set; }

    public TweenLibrary(Transform target, Vector2 startPos, Vector2 endPos, float startTime, float duration) { 
    
        Target = target;
        StartPos = startPos;
        EndPos = endPos;
        StartTime = startTime;
        Duration = duration; 
    }
}
