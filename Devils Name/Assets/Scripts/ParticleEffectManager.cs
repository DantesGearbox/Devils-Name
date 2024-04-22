using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectManager : MonoBehaviour
{
	public static ParticleEffectManager instance;

	public GameObject SquareParticle;
	public GameObject TriangleParticle;
	public GameObject CircleParticle;
	public GameObject InwardsParticle;

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

		DontDestroyOnLoad(gameObject);
	}

	public void SpawnSqaureParticles(Color color, Vector3 position)
	{
		int amount = Random.Range(6, 10);

		for (int i = 0; i < amount; i++)
		{
			GameObject particle = Instantiate(SquareParticle, position, transform.rotation);
			particle.GetComponent<SpriteRenderer>().color = color;
			Vector3 velo = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), 0);
			particle.GetComponent<Rigidbody2D>().velocity = velo;
		}
	}

	public void SpawnSqaureParticles(Color color, Vector3 position, int min, int max, float velocityMax)
	{
		int amount = Random.Range(min, max);

		for (int i = 0; i < amount; i++)
		{
			GameObject particle = Instantiate(SquareParticle, position, transform.rotation);
			particle.GetComponent<SpriteRenderer>().color = color;
			Vector3 velo = new Vector3(Random.Range(-velocityMax, velocityMax), Random.Range(-velocityMax, velocityMax), 0);
			particle.GetComponent<Rigidbody2D>().velocity = velo;
		}
	}

	public void SpawnCircleParticles(Color color, Vector3 position, int amount, float displacementMax)
	{
		for (int i = 0; i < amount; i++)
		{
			Vector3 displacementPos = new Vector3(Random.Range(-displacementMax, displacementMax), Random.Range(-displacementMax, displacementMax), 1);
			GameObject particle = Instantiate(CircleParticle, position + displacementPos, transform.rotation);

			particle.GetComponent<SpriteRenderer>().color = color;

			Vector3 velo = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), 0);
			particle.GetComponent<Rigidbody2D>().velocity = velo;
		}
	}

	public void SpawnCircleParticlesInward(Color color, Vector3 position, int amount, float displacementMax)
	{
		for (int i = 0; i < amount; i++)
		{
			Vector3 displacementPos = new Vector3(Random.Range(-displacementMax, displacementMax), Random.Range(-displacementMax, displacementMax), 1);
			GameObject particle = Instantiate(InwardsParticle, position + displacementPos, transform.rotation);

			particle.GetComponent<SpriteRenderer>().color = color;
		}
	}
}

