using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public float height;
    public Transform[] obj;
    public GameObject linePrefab;
    LineRenderer lr1; //Hat
    LineRenderer lr2; //Staff
    LineRenderer lr3; //Cards

    [HideInInspector] public List<LineRenderer> lines;

    private void Awake()
    {
        lr1 = Instantiate(linePrefab, obj[0]).GetComponent<LineRenderer>(); //Hat
        lr2 = Instantiate(linePrefab, obj[1]).GetComponent<LineRenderer>(); //Staff
        lr3 = Instantiate(linePrefab, obj[2]).GetComponent<LineRenderer>(); //Cards
        
        lines = new List<LineRenderer>();
        lines.Add(lr1);
        lines.Add(lr2);
        lines.Add(lr3);

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i< lines.Count; i++){
            var currentLine = lines[i];
            Vector3 ceiling = new Vector3 (obj[i].position.x + 0.2f, height);
            lines[i].SetPosition(0, ceiling);
            lines[i].SetPosition(1, obj[i].position);
            //Vector3[] positions = new Vector3[lines[i].positionCount];
            //lines[i].GetPositions(positions);
            
        }
    }

    public void BossDamage(int piece){
        switch(piece){
            case 0:
                obj[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                obj[0].gameObject.tag = "Map";
                break;
            case 1:
                obj[1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                obj[1].gameObject.tag = "Map";
                break;
            case 2:
                obj[2].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                obj[2].gameObject.tag = "Map";
                break;
        }
    }
}
