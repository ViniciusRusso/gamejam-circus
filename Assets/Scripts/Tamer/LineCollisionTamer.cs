using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCollisionTamer : MonoBehaviour
{
    private LineControllerTamer lc;
    private LineRenderer lr;
    private PolygonCollider2D polygonCollider2D;
    private CharacterController2D player;
    
    private GameObject parent;
    
    List<Vector2> colliderPoints = new List<Vector2>();


    void Start()
    {
        parent = GetComponent<Transform>().parent.gameObject;
        player = GameObject.Find("Player").GetComponent<CharacterController2D>();
        lc = GameObject.Find("LineController").GetComponent<LineControllerTamer>();
        lr = GetComponent<LineRenderer>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        colliderPoints = CalculateColliderPoints();
        polygonCollider2D.SetPath(0, colliderPoints.ConvertAll(p => (Vector2)transform.InverseTransformPoint(p)));
    }

    private List<Vector2> CalculateColliderPoints() {
        //Get All positions on the line renderer
        //Vector3[] positions = lc.GetPositions(num);
        Vector3[] positions = new Vector3[lr.positionCount];
        lr.GetPositions(positions);

        //Get the Width of the Line
        //float width = lc.GetWidth(num);
        float width = lr.startWidth;

        //m = (y2 - y1) / (x2 - x1)
        float m = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);
        float deltaX = (width / 2f) * (m / Mathf.Pow(m * m + 1f, 0.5f));
        float deltaY = (width / 2f) * (1f / Mathf.Pow(1f + m * m, 0.5f));

        //Calculate the Offset from each point to the collision vertex
        Vector3[] offsets = new Vector3[2];
        offsets[0] = new Vector3(-deltaX, deltaY);
        offsets[1] = new Vector3(deltaX, -deltaY);


        //Generate the Colliders Vertices
        List<Vector2> colliderPositions = new List<Vector2> {
            positions[0] + offsets[0],
            positions[1] + offsets[0],
            positions[1] + offsets[1],
            positions[0] + offsets[1]
        };

        return colliderPositions;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (player.isDashing){
            if (other.gameObject.tag == "Player"){
                lc.Damage(parent, lr);
            }
        }
    }
}
