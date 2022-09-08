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
            Vector3 ceiling = new Vector3 (obj[i].position.x + 0.1f, height);
            lines[i].SetPosition(0, ceiling);
            lines[i].SetPosition(1, obj[i].position);
            //Vector3[] positions = new Vector3[lines[i].positionCount];
            //lines[i].GetPositions(positions);
            
        }
              
        
    }

    public float GetWidth(float num) {
        switch (num){
            case 1:
                return lr1.startWidth;
                
            case 2:
                return lr2.startWidth;
                
            case 3:
                return lr3.startWidth;
                
        }
        return 0;
    }

    public Vector3[] GetPositions(float num) {
        Vector3[] positions = new Vector3[lr1.positionCount];
        switch (num){
            case 1:
                lr1.GetPositions(positions);
                //Debug.Log(positions[1].ToString());
                return positions;
            case 2:
                lr2.GetPositions(positions);
                return positions;
            case 3:
                lr3.GetPositions(positions);
                return positions;          
        }
        return null;
    }
}
