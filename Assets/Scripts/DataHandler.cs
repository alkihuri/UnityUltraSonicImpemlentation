using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataHandler : MonoBehaviour
{

    [SerializeField] List<SonarStates> data;
    List<GameObject> simulationData = new List<GameObject>();
    [SerializeField] Transform simulationWorld;
    [SerializeField, Range(1,10)] float size = 1;
     public  Material t, s;
    bool isReady;

    private void Awake()
    {
        isReady = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponentsInChildren<SonarStates>().ToList();
        CreateSimulation();
        
    }

    public void CreateSimulation()
    {
        foreach (SonarStates st in data)
        {
            GameObject newOne = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            newOne.transform.SetParent(simulationWorld);
            newOne.transform.localScale = new  Vector3(size, size, size);
            newOne.AddComponent<CubeController>();
            simulationData.Add(newOne);
            float _x =  st.levelX  + simulationWorld.transform.position.x;

            float _y = (float)st.levelY + simulationWorld.transform.position.y;

            float _z = (float)st.levelZ + simulationWorld.transform.position.z;

             

            Vector3 newPosition = new Vector3(_x, _y, _z);

            newOne.transform.position = newPosition;
        }
        isReady = true;
    }

    public void UpdateData()
    {
        if(data.Count == simulationData.Count)
        {
            for(int i=0;i<data.Count;i++)
            {
                float _x = (-data[i].levelX) + simulationWorld.transform.position.x;

                float _y = (float)data[i].levelY + simulationWorld.transform.position.y;

                float _z = (float)data[i].levelZ + simulationWorld.transform.position.z;

                simulationData[i].transform.position = new Vector3(_x, _y, _z);
                simulationData[i].transform.localScale = new Vector3(size, size, size);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isReady)
            UpdateData();
    }
}
