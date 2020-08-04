using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance {
        get {
            // If there is already an instance of this object, return it.
            if(instance != null) {
                return instance;
            }

            var instances = FindObjectsOfType<T>();
            var count = instances.Length;

            if(count > 0) {
                return instance = instances[0];
            }

            Debug.LogErrorFormat("Missing a singleton");
            return null;

        }
    }
}