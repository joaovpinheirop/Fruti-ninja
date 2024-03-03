using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    public List<GameObject> Prefabs;
    public float interval = 3f;
    public float cooldown = 0f;
    public float offSet;


    // Start is called before the first frame update
    void Start()
    {
        cooldown = interval;
    }

    // Update is called once per frame
    void Update()
    {
        float alternateInterval = Random.Range(0, interval);
        cooldown -= Time.deltaTime;

        cooldown = Mathf.Max(cooldown, 0);

        if (cooldown == 0 && GameManager.Instance.isPlay)
        {
            cooldown = alternateInterval;
            CreateFruit();
        }

    }

    private void CreateFruit()
    {
        int item = Random.Range(0, Prefabs.Count);
        GameObject fruits = Prefabs[item];

        // Random
        float offSetX = offSet / 2;
        float PositonCreator = Random.Range(-offSetX, offSetX);
        Vector3 position = new Vector3(PositonCreator, 0f, 0f);
        Instantiate(fruits, position, fruits.gameObject.transform.rotation);
    }
}
