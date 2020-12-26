using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] float oKoffset = 1 ;
    [SerializeField] float timer = 0.06f;
    [SerializeField]float tempTimer = 0;
    [SerializeField] Material t, s;
    [SerializeField]Vector3 oldpos, newpos;

    [SerializeField] float compareMag;
    Vector3 startPostion;
    private void Start()
    {
        s = GameObject.FindObjectOfType<DataHandler>().s;
        t = GameObject.FindObjectOfType<DataHandler>().t;
        startPostion = transform.position;
        oldpos = transform.position;
    }
    private void Update()
    {
        tempTimer += Time.deltaTime;

        if(tempTimer > timer)
        {
            tempTimer = 0;
            newpos = transform.position;
            Vector3 comparePos = oldpos - newpos;
            compareMag = comparePos.magnitude;
            oldpos = transform.position;
           
        }
        if(compareMag> 0.1)
        {
            GetComponent<Renderer>().material = s;
           
        }
        else
        {
            GetComponent<Renderer>().material = t;
            Vector3 someShit = transform.position;
            someShit = new Vector3(startPostion.x, someShit.y, someShit.z);
            transform.position = someShit;
        }
    }

}
