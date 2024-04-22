using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CameraManager : MonoBehaviour
{
	private PlayerCharacter player;
	private PixelPerfectCamera pixelPerfectCamera;

	private float trauma = 0;

	private int goalPPU = 0;
	private float currPPU = 0;

	public static CameraManager instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}
	}

	void Start()
	{
		player = FindObjectOfType<PlayerCharacter>();
		pixelPerfectCamera = GetComponent<PixelPerfectCamera>();

		goalPPU = pixelPerfectCamera.assetsPPU;
		currPPU = goalPPU;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			AddTrauma();
		}
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		trauma = Mathf.Clamp(trauma - Time.deltaTime, 0, 0.75f);

		float offsetX = 1 * (trauma * trauma) * Random.Range(-1.0f, 1.0f);
		float offsetY = 1 * (trauma * trauma) * Random.Range(-1.0f, 1.0f);

		var newPosition = Vector3.Lerp(transform.position, player.transform.position, 0.25f);
		transform.position = new Vector3(newPosition.x, newPosition.y, -10) + new Vector3(offsetX, offsetY, 0);

		currPPU = Mathf.Lerp(currPPU, goalPPU, 0.1f);
		pixelPerfectCamera.assetsPPU = (int)currPPU;
	}

	public void AddTrauma()
	{
		trauma += 0.25f;
	}

	public void AddLargeTrauma()
	{
		trauma += 0.5f;
	}
}
