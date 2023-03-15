using UnityEngine;
using System.IO.Ports;

public class LightController : MonoBehaviour
{
    public Light lightObject;  
    public string serialPort = "COM3"; 
    public int baudRate = 9600;
    private SerialPort arduino;

    void Start()
    {
        arduino = new SerialPort(serialPort, baudRate);
        arduino.Open();
        arduino.ReadTimeout = 10;
    }

    void Update()
    {
        try
        {
            int potValue = int.Parse(arduino.ReadLine());
            float brightness = Mathf.InverseLerp(0, 1023, potValue);
            lightObject.intensity = brightness * 8f; 
        }
        catch (System.Exception)
        {
            
        }
    }

    void OnDisable()
    {
        if (arduino != null && arduino.IsOpen)
        {
            arduino.Close();
        }
    }
}
