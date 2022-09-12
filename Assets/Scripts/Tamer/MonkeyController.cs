using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject bone;
    public float boneDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThrowBones());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ThrowBones(){
        while (true){
            yield return new WaitForSeconds(boneDelay);
            Instantiate(bone, throwPoint.position, Quaternion.identity, gameObject.GetComponent<Transform>());
        }    
    }
}
