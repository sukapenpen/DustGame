using System;
using UnityEngine;
using System.IO.Ports;
using System.Text;

public class SerialManager // : MonoBehaviour
{
    private static SerialManager instance;

    private SerialPort mbed;
    
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
        try
        {
            ConnectSerialPort("/dev/cu.usbmodem14103");
        }
        catch
        {
            try
            {
                ConnectSerialPort("/dev/cu.usbmodem14203");
            }
            catch
            {
                Debug.Log("何もなかった！");
            }
        }
        
    }

    private void ConnectSerialPort(string _port)
    {
        mbed = new SerialPort(_port, 9600);
        mbed.ReadTimeout = 10;
        mbed.Open();
        Debug.Log("スタート");
    }

    public void Run()
    {
        
    }

    public float ReadDistance()
    {
        var text = new StringBuilder();
        string str;
        try
        {
            while (text.Length < 7)
            {
                text.Append(mbed.ReadExisting());
            }

            str = text.ToString();
            return float.Parse(str);
        }
        catch
        {
            return -1;
        }
    }
 
}
