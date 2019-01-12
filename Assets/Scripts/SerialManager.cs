using System;
using UnityEngine;
using System.IO.Ports;
using System.Runtime.Remoting.Messaging;

public class SerialManager // : MonoBehaviour
{
    private static String port;
    private static SerialManager instance;

    private SerialPort mbed;
    private string message;
    
    public static SerialManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SerialManager();
            }

            return instance;
        }
        
        set
        {
            instance = value;
        }
    }
    
    public void Init()
    {
        port = "/dev/cu.usbmodem14203";
        this.mbed = new SerialPort(port, 9600);
        this.mbed.ReadTimeout = 50;
        this.mbed.Open();
        Debug.Log("スタート");
    }

    public void Run()
    {
        //ReadDistance();
        /*
        message = ReadDistance();
        Debug.Log(message);
        */
    }

    public float ReadDistance()
    {
        try
        {
            float distance = float.Parse(this.mbed.ReadLine());
            
            return distance;
        }
        catch
        {
            return -1;
        }
    }

    /*
    private void ReadDistance()
    {
        try
        {
            string message = this.mbed.ReadLine();
            Debug.Log(message);
        }
        catch (Exception e)
        {
            
        }
        
    }
    */
 
}
