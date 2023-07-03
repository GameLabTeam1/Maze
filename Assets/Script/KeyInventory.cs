using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    public List<GameObject> keys = new List<GameObject>();

    public void AddKey(GameObject key)
    {
        keys.Add(key);
    }

    public void RemoveKey(GameObject key)
    {
        keys.Remove(key);
    }

    public bool HasKey(GameObject key)
    {
        return keys.Contains(key);
    }
}
