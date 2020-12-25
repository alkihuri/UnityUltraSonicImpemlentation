using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarStates : MonoBehaviour
{
    public bool isRecieving ;
    public bool isTransmiting;
    public float maxSonarDistance;
    public float levelX;
    public double levelY;
    public double levelZ;
    private void Awake()
    {
        maxSonarDistance = 150;
        isRecieving = false;
        isTransmiting = false;
        levelY = transform.position.y;
        levelZ = transform.position.z;
    }

}
