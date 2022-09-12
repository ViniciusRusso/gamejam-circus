using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControllerTamer : MonoBehaviour
{
    public float height;
    public Transform[] animals;
    private LineRenderer[] lr = new LineRenderer[7];
    public GameObject linePrefab;
    public Animator animator;

    [HideInInspector] public List<LineRenderer> lines;
    
    private BossTamerController btc;

    private void Awake()
    {   
        btc = GameObject.Find("BossTamerController").GetComponent<BossTamerController>();
        lines = new List<LineRenderer>();
        for (int i = 0; i< animals.Length; i++){
            lr[i] = Instantiate(linePrefab, animals[i]).GetComponent<LineRenderer>();
            lines.Add(lr[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int x = lines.Count -1;
        
        for (int i = 0; i < lines.Count; i++){

            if(animals[i].gameObject.activeSelf){
                var currentLine = lines[i];
                Vector3 ceiling = new Vector3 (animals[i].position.x + 0.2f, height);
                currentLine.SetPosition(0, ceiling);
                currentLine.SetPosition(1, animals[i].position);
            }     

        }

    }

    public void Damage(GameObject parent, LineRenderer line){
        line.gameObject.SetActive(false);
        parent.SetActive(false);

        //Death Animation
        btc.animalsDefeated++;

        if (parent.name == "Tigre"){
            btc.StartPhase2();
        }
    }

}