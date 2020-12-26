using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarCntlr : MonoBehaviour
{
    [SerializeField] GameObject center, directionPoint;
    [SerializeField, Range(1, 10)] float rotateSpeed;
    [SerializeField, Range(1, 25)] float distance;
    [SerializeField] bool isScaning = false; 
 

    // Update is called once per frame
    void Update()
    {
        directionPoint.transform.Rotate(0, rotateSpeed, 0);
        Vector3 _startPoint = transform.position;
        Vector3 _direction =  directionPoint.transform.forward*15; 
        RaycastHit objectOnHitLine;
        if(Physics.Raycast(_startPoint, _direction,out objectOnHitLine))
        {
            Debug.DrawLine(_startPoint, objectOnHitLine.transform.position,Color.red);
            distance = objectOnHitLine.distance;
            if(isScaning)
            {
                int _x =  (int)objectOnHitLine.point.x;
                int _y =  (int)objectOnHitLine.point.z;
                Vector2 _p = new Vector2(_x * 10, _y * 10);
                Debug.Log(_p);
                GameObject.FindObjectOfType<DrawLine>().DrawPoint(_p);
            }
        }

    } 
}
