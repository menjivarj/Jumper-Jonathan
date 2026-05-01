using UnityEngine;

public class BarScript : MonoBehaviour
{

    public GameObject platform;
    public float spacing;
    public float width;
    public float spawnHeight;
    public float spawnBound;
    public GameObject gameOverPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (float i = transform.position.y / 2; i < spawnHeight; i += spacing)
        {
            Instantiate(platform, new Vector2(Random.Range(-spawnBound, spawnBound), i), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(collision.gameObject);
            Instantiate(platform, new Vector2(Random.Range(-spawnBound, spawnBound), spawnHeight), Quaternion.identity);
            spawnHeight += spacing;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            gameOverPanel.SetActive(true);
        }
    }

}
