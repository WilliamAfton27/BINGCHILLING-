using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
   

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // If the instance is not found, try to find it in the scene
                _instance = FindObjectOfType<GameManager>();

                // If it's still not found, create a new GameObject and add GameManager component to it
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<GameManager>();
                    singletonObject.name = typeof(GameManager).ToString() + " (Singleton)";
                }
            }
            return _instance;
        }
    }

    public bool HasCard = false;
    

    void Awake()
    {
        // Ensure that the instance is unique
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
