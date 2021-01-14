using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Difficalty : MonoBehaviour
{
    private Button button;
    private EnemyGenerate gameManager;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("buttom start");
        button = GetComponent<Button>();
        gameManager = GameObject.Find("God").GetComponent<EnemyGenerate>();
        button.onClick.AddListener(SetDifficulty);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }
}
