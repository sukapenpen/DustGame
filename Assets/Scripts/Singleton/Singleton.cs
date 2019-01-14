using UnityEngine;

public class Singleton<T>
{
    protected static Singleton <T> instance;
    
    public static Singleton<T> Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton<T>();
            }

            return instance;
        }
        
        set
        {
            instance = value;
        }
    }
}
