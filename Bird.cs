using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;
    private int _levelScore = 0;
    private int numberOfTimesBirdLaunched = 0;
    private int numberOfTimesBirdCanBeLaunched = 0;
    public Score score;
    private Enemy[] _enemies;
    private bool enableDrag;

    [SerializeField] private float _launchPower = 500;

    private void Awake()
    {
        _initialPosition = transform.position;
        _enemies = FindObjectsOfType<Enemy>();
        numberOfTimesBirdCanBeLaunched = _enemies.Length;
        enableDrag = true;
    }


    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

       // GetComponent<ObjectDragger>().enabled = true;

        if (_birdWasLaunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y > 14 ||
            transform.position.y < -12 ||
            transform.position.x > 15 ||
            transform.position.x < -12)
        {
            //   string currentSceneName = SceneManager.GetActiveScene().name;
            //Invoke("LoadCurrentScene", 0.1f);
            enableDrag = false;
            Invoke("LoadCurrentScene",0f);
            return;
            //SceneManager.LoadScene(currentSceneName);
        }
        enableDrag = true;
        if (_timeSittingAround > 6)
        { 
            if(numberOfTimesBirdLaunched >= numberOfTimesBirdCanBeLaunched)
            {
                numberOfTimesBirdLaunched = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } else
            {
                LoadCurrentScene();
            }
        }
    }

    void LoadCurrentScene()
    {
        //int level = SceneManager.GetActiveScene().buildIndex;

        //SceneManager.LoadScene(level);
        _timeSittingAround = 0;
        _birdWasLaunched = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        Vector2 vector = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().AddForce(vector);
        GetComponent<Rigidbody2D>().angularVelocity = 0f;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = _initialPosition;
        enableDrag = true;
        Invoke("Delay", 1f);
        
    }

    void Delay()
    {
        Debug.Log("Delay");
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;

    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;
        numberOfTimesBirdLaunched++;
        string s = "NumberOfTimesBirdLaunched" + numberOfTimesBirdLaunched;
        Debug.Log(s);
        if (numberOfTimesBirdLaunched > 1)
            score.decreaseLevelScore();
        GetComponent<LineRenderer>().enabled = false;

    }
    
    private void OnMouseDrag()
    {
        //if (enableDrag == false) return;

        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (newPosition.y > 3 ||
            newPosition.y < -5 ||
            newPosition.x > -2 ||
            newPosition.x < -12)
            return;


            transform.position = new Vector3(newPosition.x, newPosition.y);
      

        if (transform.position.y > 12 ||
            transform.position.y < -12 ||
            transform.position.x > 12 ||
            transform.position.x < -12)
        {

            string currentSceneName = SceneManager.GetActiveScene().name;
            //  Invoke("LoadCurrentScene", 0.1f);
            //return;
        //    if (enableDrag == false) return;
            SceneManager.LoadScene(currentSceneName);
        }

    }
}
