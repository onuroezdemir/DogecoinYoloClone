using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    public int multValue =1;
    public bool isMultiplier = true;

    private Material stateMat;
    private TextMesh textMesh;

    private void Awake()
    {
        textMesh =transform.GetChild(0).GetComponent<TextMesh>();
        stateMat = GetComponent<MeshRenderer>().material;

        multValue = Random.Range(2, 6);
       
        int i = Random.Range(1, 3);
        if (i == 1)
        {
            isMultiplier = true;
            textMesh.text = "x" + multValue.ToString();
            stateMat.color = Color.green;
        }
        else
        {
            isMultiplier = false;
            textMesh.text = "/" + multValue.ToString();
            stateMat.color = Color.red;
        }
    }
}
