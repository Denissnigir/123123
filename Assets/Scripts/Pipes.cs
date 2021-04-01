using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [Header("Set in Inspector")]
    public List<GameObject> pipeList;
    public GameObject pipesPrefab;
    public float defX = 0f;
    public float defY = 0f;
    public float spcBtw = 3f;
    public float minY = -1.7f;
    public float maxY = 1f;
    public float range = 20;

    // Start is called before the first frame update
    void Start()
    {
        pipeList = new List<GameObject>();
        for(int i = 0; i < 20; i++) {
            GameObject pipeInst = Instantiate<GameObject>(pipesPrefab);
            Vector3 pos = Vector3.zero;
            pos.x = defX + (spcBtw * i);
            pos.y = defY + Random.Range(minY, maxY);
            pipeInst.transform.position = pos;
            pipeList.Add(pipeInst);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos1 = GameObject.FindGameObjectWithTag("Bird").transform.position;
        GameObject[] tPipesArray = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject tGO in tPipesArray)
        {
            if (tGO.transform.position.x < pos1.x - 10f)
            {
                Destroy(tGO);
                int index = 0;
                pipeList.RemoveAt(index);
                index++;
            }
        }

        if (pipeList.Count < 20) {
            GameObject pipeInst = Instantiate<GameObject>(pipesPrefab);
            Vector3 pos = Vector3.zero;
            pos.x = defX + (spcBtw * range);
            pos.y = defY + Random.Range(minY, maxY);
            pipeInst.transform.position = pos;
            pipeList.Add(pipeInst);
            range++;
        }
    }
}
