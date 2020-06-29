//mathematical function based on the wikipedia article on bezier curves https://en.wikipedia.org/wiki/B%C3%A9zier_curve#Cubic_B%C3%A9zier_curves
//idea for visualizing paths in inspector with gizmos inspired by https://www.youtube.com/watch?v=11ofnLOE8pw

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCellPath : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 0.5f)] float gizmoScale = 0.25f;
    [SerializeField] Color gizmoColor = Color.gray;
    [SerializeField] Transform[] controlPoints;
    Vector3 gizmosPosition;

    //visualizes a cubic bezier curve based on the position of the 4 child objects called "control points"
    //a cell will follow the bezier path if the object that this path is attached to is specified as a parameter of PathFollower.cs
    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t+= 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                        3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
                        3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
                        Mathf.Pow(t, 3) * controlPoints[3].position;

            Gizmos.color = gizmoColor;
            Gizmos.DrawSphere(gizmosPosition, gizmoScale);
        }

        Gizmos.DrawLine(new Vector3(controlPoints[0].position.x, controlPoints[0].position.y, controlPoints[0].position.z), 
                        new Vector3(controlPoints[1].position.x, controlPoints[1].position.y, controlPoints[1].position.z));

        Gizmos.DrawLine(new Vector3(controlPoints[2].position.x, controlPoints[2].position.y, controlPoints[2].position.z), 
                        new Vector3(controlPoints[3].position.x, controlPoints[3].position.y, controlPoints[3].position.z));
    }
}
