using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("GreatswordAtk"))
        {
            CameraManager.instance.AddLargeTrauma();
            Debug.Log("BIG HIT");
		}
        if (collision.CompareTag("GreatswordAtkWeak"))
        {
            CameraManager.instance.AddTrauma();
            Debug.Log("WEAK HIT");
        }
	}
}
