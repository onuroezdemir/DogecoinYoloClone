using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Value : MonoBehaviour
{
    public int coinValue = 1;
    private GameObject player;
    private TextMesh textMesh;




    private void Awake()
    {
        player = GameObject.Find("Player");
        textMesh = GetComponent<TextMesh>();
    }

    private void Update()
    {
        coinValue = (int)(100 * player.transform.position.y);
        textMesh.text = string.Format(new CultureInfo("en-US"), "{0:C0}", coinValue);
    }
}
