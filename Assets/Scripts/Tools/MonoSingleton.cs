using UnityEngine;
using System.Collections;

public class MonoSingleton<T> : MonoBehaviour where T:MonoSingleton<T>{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (null == instance)
            {
                GameObject obj = new GameObject(typeof(T).Name);
                instance = obj.AddComponent<T>();
            }
            return instance;
        }
           
    }
	protected virtual void Awake()
    {
        instance = this as T;
        //Debug.Log(this.name+ instance);
    }
}
