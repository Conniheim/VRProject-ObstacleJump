using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialTest : MonoBehaviour
{
    public Light lightObject;
    SerialPort serialPort = new SerialPort("COM3", 9600); // Replace "COM3" with the port name of your Arduino board

    void Start()
    {
        serialPort.Open();
    }

    void Update()
    {
        if (lightObject.enabled = true)
        {
            serialPort.Write("0");
        }
        else
        {
            serialPort.Write("1");
        }
        
    }

    void OnApplicationQuit()
    {
        serialPort.Close();
    }
}
