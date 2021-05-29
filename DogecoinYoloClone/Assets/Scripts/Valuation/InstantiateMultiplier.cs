using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMultiplier : MonoBehaviour
{
    private GameObject player;

    public GameObject Multiplier;

    float timer =.1f;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            CreateMultiplier();
            timer = Random.Range(0.5f, 1f);
        }
    }

    void CreateMultiplier()
    {

        float randomX = Random.Range(-10f, -20f);
        float randomY = Random.Range(-3f, 15f);
        Vector3 position = new Vector3(player.transform.position.x + randomX, player.transform.position.y +randomY, player.transform.position.z);
        Instantiate(Multiplier, position,Quaternion.identity, transform);
    }
}
