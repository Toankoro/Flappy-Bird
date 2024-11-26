using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject pipeRefab;
    private float countdouwn;
    public float timeDuration;
    public bool enableGenratePipe; //Cho phep sinh ra ong !
    // Start is called before the first frame update
    private void Awake()
    {
        countdouwn=1.0f;
        enableGenratePipe = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enableGenratePipe == true)
        {
            countdouwn -= Time.deltaTime;
            if (countdouwn <= 0)
            {
                Instantiate(pipeRefab, new Vector3(20, Random.Range(0.4f, 3.2f), 0), Quaternion.identity);
                countdouwn = timeDuration;
            }
        }
    }
}
