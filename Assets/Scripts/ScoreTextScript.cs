using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    public TMP_Text coinText;
    public static int coinAmount;

    void Start()
    {
        coinText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinAmount.ToString();
        

    }

}
