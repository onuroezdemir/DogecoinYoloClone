using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCube : MonoBehaviour
{

    public GameObject cubePrefabUp;
    public GameObject cubePrefabDown;

    public TextMesh textMeshValue;

    private void OnEnable()
    {
        EventManager.OnPressedUp.AddListener(CreateCubeUp);
        EventManager.OnPressedDown.AddListener(CreateCubeDown);
    }

    private void OnDisable()
    {
        EventManager.OnPressedUp.RemoveListener(CreateCubeUp);
        EventManager.OnPressedDown.RemoveListener(CreateCubeDown);
    }

    public void CreateCubeUp()
    {
        Instantiate(cubePrefabUp, transform, true);
        textMeshValue.color = Color.green;
    }

    public void CreateCubeDown()
    {
        Instantiate(cubePrefabDown, transform, true);
        textMeshValue.color = Color.red;
    }
}
