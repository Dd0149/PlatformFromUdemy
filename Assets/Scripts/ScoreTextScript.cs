using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    public TMP_Text text;
    public int coinAmount;
       void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coinAmount.ToString();
    }
}
