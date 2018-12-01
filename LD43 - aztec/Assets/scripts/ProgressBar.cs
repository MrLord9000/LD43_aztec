using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    Button progressBar;
    public float maxTime = 10f;
    private float timeLeft;
    
	
    // Use this for initialization
	void Start ()
    {
        progressBar = GetComponent<Button>();
        timeLeft = maxTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            progressBar.image.fillAmount = 1 - timeLeft / maxTime;
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
