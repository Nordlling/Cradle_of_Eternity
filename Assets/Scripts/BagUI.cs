using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
    public Text WoodCount;
    
    private void Start()
    {
        Bag.Instance.OnUpdate += UpdateUI; 
    }

    public void UpdateUI(Bag bag)
    {
        WoodCount.text = bag.WoodCount.ToString();
    }

    private void OnDestroy()
    {
        Bag.Instance.OnUpdate -= UpdateUI;
    }
}
