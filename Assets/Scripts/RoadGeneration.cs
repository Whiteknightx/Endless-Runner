using UnityEngine;

public class RoadGeneration : MonoBehaviour
{

    [SerializeField] Transform _spawnPoint;

    [SerializeField] GameObject[] _paths;
    //[SerializeField] GameObject paths;

    [SerializeField] float _moveSpeed = 1;

    public bool selfSpeed;

    void Start()
    {
        //Add a spawn point gameObject in scene where u want to spawn next Prefab
        _spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;
    }

    void Update()
    {
        if (!selfSpeed) _moveSpeed = SceneManagement.Instance.pathSpeed;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - _moveSpeed * Time.deltaTime);

        //Change 96 to ur preffered number as it is when it destroys current gameobject and spawns new one
        if (transform.position.z < -1000)
        {
            Generate();
            Destroy(gameObject);
        }
    }

    //spawning prefab(road)
    void Generate()
    {
        int RandomPath = Random.Range(0, _paths.Length);

        var path = Instantiate(_paths[RandomPath], _spawnPoint.position, Quaternion.identity);
    }
}
