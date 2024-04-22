using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	public GameObject GreatswordAtkPrefab;

	private float movespeed = 5;

	private Rigidbody2D rb;

	private Vector3 movementInput;
	private Vector3 mousePos;

	private bool isSwinging = false;
	private bool spawned = false;
	private float swingTime = 0.75f;
	private float spawnTime = 0.40f;
	private float swingTimer = 0.0f;
	private GameObject greatswordAtk;
	private Vector3 mousePosInSwing;

	private bool movementStop = false;
	private bool rotationStop = false;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		float xInput = Input.GetAxisRaw("Horizontal");
		float yInput = Input.GetAxisRaw("Vertical");
		movementInput = new Vector3(xInput, yInput, 0);

		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0f;
		
		if (Input.GetKeyDown(KeyCode.Mouse0) && !isSwinging)
		{
			isSwinging = true;
			mousePosInSwing = mousePos;
		}

		if (isSwinging)
		{
			swingTimer += Time.deltaTime;

			if(swingTimer > spawnTime && !spawned)
			{
				var playerToMouse = new Vector2(mousePosInSwing.x, mousePosInSwing.y) - rb.position;
				var spawnPos = transform.position + new Vector3(playerToMouse.x, playerToMouse.y, 0).normalized * 2;
				var spawnRot = Quaternion.Euler(0, 0, (Mathf.Atan2(playerToMouse.y, playerToMouse.x) * Mathf.Rad2Deg) - 90f);
				greatswordAtk = Instantiate(GreatswordAtkPrefab, spawnPos, spawnRot);
				ParticleEffectManager.instance.SpawnSqaureParticles(Color.red, spawnPos);
				spawned = true;
			}

			if(swingTimer > swingTime)
			{
				if(greatswordAtk != null) { Destroy(greatswordAtk); }

				swingTimer = 0.0f;
				isSwinging = false;
				spawned = false;
			}
		}

		if (isSwinging)
		{
			rb.velocity = Vector3.zero;
			movementStop = true;
			rotationStop = true;
		}

		if (!isSwinging)
		{
			movementStop = false;
			rotationStop = false;
		}
	}


	void FixedUpdate()
	{
		SetVelocity();
		SetRotation();
	}

	private void SetVelocity()
	{
		if (!movementStop)
		{
			rb.velocity = movementInput.normalized * movespeed;
		}
	}

	private void SetRotation()
	{
		if (!rotationStop)
		{
			var playerToMouse = new Vector2(mousePos.x, mousePos.y) - rb.position;
			float angle = (Mathf.Atan2(playerToMouse.y, playerToMouse.x) * Mathf.Rad2Deg) - 90f;
			rb.rotation = angle;
		}
	}
}
