using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathFollower : MonoBehaviour
{
    [SerializeField][Range(0.1f, 1f)] float speedModifier = 0.25f;
    
    //any number of paths can be added in the inspector
    //the cell will follow the paths one after the other
    [SerializeField] Transform[] paths;
    int currentPathIndex;
    
    float t;
    Vector3 cellPosition;
    bool isPathCompleted;

    private void Start()
    {
        currentPathIndex = 0;
        t = 0f;
        isPathCompleted = true;
    }

    private void Update()
    {
        if (isPathCompleted)
        {
            StartCoroutine(FollowPath(currentPathIndex));
        }
    }

    private IEnumerator FollowPath(int pathNumber)
    {
        isPathCompleted = false;
        //get points for current path
        Vector3 p0 = paths[pathNumber].GetChild(0).position;
        Vector3 p1 = paths[pathNumber].GetChild(1).position;
        Vector3 p2 = paths[pathNumber].GetChild(2).position;
        Vector3 p3 = paths[pathNumber].GetChild(3).position;

        while(t < 1)
        {
            //move cell along a cubic bezier curve as a function of time
            t += Time.deltaTime * speedModifier;
            cellPosition = Mathf.Pow(1 - t, 3) * p0 +
                            3 * Mathf.Pow(1 - t, 2) * t * p1 +
                            3 * (1 - t) * Mathf.Pow(t, 2) * p2 +
                            Mathf.Pow(t, 3) * p3;

            transform.position = cellPosition;
            yield return new WaitForEndOfFrame();
        }

        t = 0f;

        currentPathIndex += 1;
        if(currentPathIndex > paths.Length -1) { currentPathIndex = 0; }

        isPathCompleted = true;
    }
}
