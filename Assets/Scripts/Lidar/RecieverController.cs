using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieverController : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] SonarStates sonarStates;
    [SerializeField] Transform raycastDirection;
    [SerializeField, Range(1, 5)] float delay = 10; 
    public void GetDistance()
    {
        Vector3 direction = raycastDirection.position - transform.position;
        RaycastHit objectOnHitLine; 
        if (Physics.Raycast(transform.position, direction, out objectOnHitLine, sonarStates.maxSonarDistance))
        {
            distance = objectOnHitLine.distance;
            sonarStates.levelX = distance  - transform.position.x;
            Debug.DrawLine(transform.position,  objectOnHitLine.transform.position, Color.yellow);
        }
    }

    IEnumerator DelaySonar()
    {
        while(1==1)
        {
            yield return new WaitForSeconds(delay / 100);
            GetDistance();
        }
    }
    private void Start()
    {
        StartCoroutine(DelaySonar());
    }
}
