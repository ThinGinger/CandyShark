using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    public GameObject[] prefabFish;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(fishCoroutine());
    }

    private void spawnFish()
    {


        GameObject a = Instantiate(prefabFish[Random.Range(0,3)]) as GameObject;
        float randomY = Random.Range(-2, 4);//random y position

        if (Random.Range(0, 2) == 0)//choose between left or right side
        {
            a.transform.position = new Vector2(-screenBounds.x - 2, randomY);
            a.GetComponent<Fish>().bSwimLeft = false;
        }
        else
        {
            a.transform.position = new Vector2(screenBounds.x + 2, randomY);
            a.GetComponent<Fish>().bSwimLeft = true;
        }
    }

    //Spawn fish every second
    IEnumerator fishCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnFish();
        }
    }
}
