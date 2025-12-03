using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;

    [SerializeField]
    private float spawnRate = 2f;
    private float timer = 0f;

    [SerializeField]
    private float hightOffset = 10f;

    private LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPipe();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float adjustedSpawnRate = spawnRate * (5f / logic.moveSpeed);

        if (timer < adjustedSpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0f;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - hightOffset;
        float highestPoint = transform.position.y + hightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
