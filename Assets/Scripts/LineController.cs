using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public float height;
    public Transform[] obj;
    public Transform boss;
    public GameObject linePrefab;
    public Animator animator;
    LineRenderer lr1; //Hat
    LineRenderer lr2; //Staff
    LineRenderer lr3; //Cards

    [HideInInspector] public List<LineRenderer> lines;
    

    private void Awake()
    {
        lr1 = Instantiate(linePrefab, obj[0]).GetComponent<LineRenderer>(); //Hat
        lr2 = Instantiate(linePrefab, obj[1]).GetComponent<LineRenderer>(); //Cards
        lr3 = Instantiate(linePrefab, obj[2]).GetComponent<LineRenderer>(); //Staff
        
        lines = new List<LineRenderer>();
        lines.Add(lr1);
        lines.Add(lr2);
        lines.Add(lr3);
    }

    // Update is called once per frame
    void Update()
    {
        int x = lines.Count -1;
        
        for (int i = x; i >= 0; i--){
            //Debug.Log(i);
            var currentLine = lines[i];
            Vector3 ceiling = new Vector3 (obj[i].position.x + 0.2f, height);
            currentLine.SetPosition(0, ceiling);
            currentLine.SetPosition(1, obj[i].position);
            //Vector3[] positions = new Vector3[lines[i].positionCount];
            //lines[i].GetPositions(positions);
            
        }
    }

    public void BossDamage(int piece){
        Vector3 pos;
        switch(piece){
            case 0:
                //pos = lr1.GetPosition(1);
                //obj[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                //obj[0].GetComponent<Rigidbody2D>().mass = 10f;
                //obj[0].gameObject.tag = "Map";
                //obj[0].parent = null;

                obj[1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                obj[2].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                obj[1].parent = boss;
                obj[2].parent = boss;

                lines.Remove(lr1);
                Destroy(lr1.gameObject);
                animator.Rebind();
                animator.SetBool("StaffDefeated", true);
                animator.SetBool("CardsDefeated", true);
                animator.SetBool("HatDefeated", true);
                //obj[0].position = pos;
                break;
            case 1:      
                pos = lr2.GetPosition(1);
                obj[1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                obj[1].GetComponent<Rigidbody2D>().mass = 10f;
                obj[1].gameObject.tag = "Map";
                obj[1].parent = null;
                lines.Remove(lr2);
                Destroy(lr2.gameObject);
                animator.Rebind();
                animator.SetBool("StaffDefeated", true);
                animator.SetBool("CardsDefeated", true);
                obj[1].position = pos;
                break;
            case 2:
                pos = lr3.GetPosition(1);
                obj[2].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                obj[2].GetComponent<Rigidbody2D>().mass = 10f;
                obj[2].gameObject.tag = "Map";
                obj[2].parent = null;
                lines.Remove(lr3);
                Destroy(lr3.gameObject);
                animator.Rebind();
                animator.SetBool("StaffDefeated", true);
                obj[2].position = pos;
                break;
        }
    }
}
