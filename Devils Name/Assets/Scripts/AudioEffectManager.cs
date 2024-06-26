﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioEffectManager : MonoBehaviour
{
	public static AudioEffectManager instance;

	public Sound[] Sounds;

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

		foreach (Sound s in Sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	private void Start()
	{

	}

	public void Play(string name)
	{
		Sound s = Array.Find(Sounds, sound => sound.name == name);
		if (s == null)
		{
			Debug.LogError("Sound not found");
			return;
		}
		s.source.Play();
	}
}
