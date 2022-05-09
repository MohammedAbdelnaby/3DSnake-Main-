using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    private Vector2Int TopSize;
    [SerializeField]
    private GameObject ApplePrefab;
    private GameObject Apple;

    private bool AppleOnField = false;
    // Start is called before the first frame update
    void Start()
    {
        TopSize = new Vector2Int(10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Apple == null)
        {
            Apple = Instantiate(ApplePrefab, new Vector3(Random.Range(-9, 9) / 2, 0.125f, Random.Range(-9, 9) / 2), Quaternion.identity);
        }
    }
}
