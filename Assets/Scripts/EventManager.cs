using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public TextMeshProUGUI topText;
    public TextMeshProUGUI bottomText;

    public float loadNextSceneDelayInSeconds = 1f;
    public GameObject fire;

    public void TakeWater(GameObject fireInteractionToActivate)
    {
        print("shloups");
        // shloups sound
        
        fireInteractionToActivate.SetActive(true);
    }

    public IEnumerator LoadNextScene(string scenePath, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(scenePath);
    }
    
    public void ExtinguishFire(string scenePath)
    {
        fire.SetActive(false);
        StartCoroutine(LoadNextScene(scenePath, loadNextSceneDelayInSeconds));
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
