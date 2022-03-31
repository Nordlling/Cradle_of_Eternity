using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public int WoodCount { get; private set; }
    public static Bag Instance { get; private set; }
    public event System.Action<Bag> OnUpdate;

    public void AddWood(int count)
    {
        WoodCount += count;
        if (OnUpdate != null)
        {
            OnUpdate(this);
        }
    }
    void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        //Instance = null;
    }
}
