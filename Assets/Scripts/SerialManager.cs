using System;
using UnityEngine;
using System.IO.Ports;
 
public class SerialManager // : MonoBehaviour
{
    SerialPort mbed = new SerialPort("/dev/cu.usbmodem14103", 9600);
    private static SerialManager instance;
    
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
        this.mbed.ReadTimeout = 50;
        this.mbed.Open();
        Debug.Log("スタート");
    }

    public void Run()
    {
        ReadDistance();
    }

    void ReadDistance()
    {
        try
        {
            string message = this.mbed.ReadLine();
            Debug.Log(message);
        }
        catch (Exception e)
        {
            Debug.Log("できてる！");
        }
        
    }
 
}
