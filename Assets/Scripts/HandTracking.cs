using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject[] handPoints;


    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;

        data = data.Remove(0, 1);
        data = data.Remove(data.Length-1, 1);
        // print(data);
        string[] points = data.Split(',');
        // print(points[0]);

        for (int i = 0; i < 21; i++)
        {
            int xindex = i * 3;
            int yindex = i * 3 + 1;

            float x = 5 - float.Parse(points[xindex])/70;
            float y = float.Parse(points[yindex])/70 - 10;
            float z = 0;

            handPoints[i].transform.localPosition = new Vector3(x, y, z);
        }
    }
}
