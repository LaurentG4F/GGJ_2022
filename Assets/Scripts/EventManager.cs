using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public TextMeshProUGUI topText;
    public TextMeshProUGUI bottomText;

    public void TakeWater(GameObject fireInteractionToActivate)
    {
        print("shloups");
        // shloups sound
        
        fireInteractionToActivate.SetActive(true);
    }

    public void ExtinguishFire(string scenePath)
    {
        SceneManager.LoadScene(scenePath);
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
