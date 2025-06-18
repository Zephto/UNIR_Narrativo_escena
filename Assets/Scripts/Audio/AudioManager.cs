using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{

	//public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	void Awake()
	{
		// if (instance != null)
		// {
		// 	Destroy(gameObject);
		// }
		// else
		// {
		// 	instance = this;
		// 	DontDestroyOnLoad(gameObject);
		// }

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

	public void PlayAllAndMute(){
		foreach(Sound s in sounds){
			s.source.pitch = 1;
			s.source.volume = 0;
			s.source.Play();
		}
	}

	public void AudioTransition(string sound, float to, float time){
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.pitch = 1;
		float actualVolume = s.source.volume;
		LeanTween.value(s.source.gameObject, x => s.source.volume = x, actualVolume, to, time);
	}

	public void AudioTransition(Dictionary<string, float> soundsTo, float time){
		foreach(Sound s in sounds){
			foreach(KeyValuePair<string, float> sound in soundsTo){
				if(sound.Key == s.name){
					LeanTween.value(s.source.gameObject, x => s.source.volume = x, s.source.volume, sound.Value, time);
					break;
				}
			}
		}
	}

	public void FadeAllMusic(float to, float time){
		foreach(Sound s in sounds){
			float actualVolume = s.source.volume;
			LeanTween.value(s.source.gameObject, x => s.source.volume = x, actualVolume, to, time);
		}
	}

	public void FadeAllActiveMusic(float to, float time){
		foreach(Sound s in sounds){
			float actualVolume = s.source.volume;
			if(actualVolume > 0) LeanTween.value(s.source.gameObject, x => s.source.volume = x, actualVolume, to, time);
		}
	}

	public void Stop(string sound){
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Stop();
	}
	
	public void Mute(bool set){
		foreach(Sound s in sounds){
			s.source.mute = set;
		}
	}

}
