using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    //Intervalo
    public float interval = 3f;
    //Cooldown quanto tempo passou ate prox bola
    private float cooldown = 0f;
    //lista de bolinhas
    public List<GameObject> prefabs;
    //ponto de origem
    public Vector3 originPoint = new Vector3(0f, 15f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameActive)
            return;

        cooldown -= Time.deltaTime;
        if (cooldown <=0f)
        {
            cooldown = interval;
            SpawnBall();
        }
    }
    
    private void SpawnBall()
    {
        int prefabIndex = Random.Range(0, prefabs.Count);
        GameObject prefab = prefabs[prefabIndex];
        //Get position
        float gameWidth = GameManager.Instance.gameWidth / 2f;
        float xOffSet = Random.Range(-gameWidth, gameWidth);
        Vector3 position = originPoint;
        position.x = xOffSet;
        //Get Rotation
        Quaternion rotation = prefab.transform.rotation;
        //Spawn Ball
        Instantiate(prefab, position, rotation);
    }
}
