using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int a = 0; a < 5; a++)
        {
            Vector3 vector3 = new Vector3(0, 0, 25 + (a * 15));
            Instantiate(obstaclePrefab, vector3, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
