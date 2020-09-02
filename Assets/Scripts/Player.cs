using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Range(0,100)]
    public float runSpeed;
    public KeyCode jump;
    [Range(1,25)]
    public int jumpForce;

    public int deathScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPlayerDeath()
    {
        SceneManager.LoadScene(deathScene);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPlayerDeath();
        }
    }
}
