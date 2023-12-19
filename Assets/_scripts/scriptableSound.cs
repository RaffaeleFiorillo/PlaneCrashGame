using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SoundInfo")]
public class scriptableSound : ScriptableObject
{

    [SerializeField] public AudioResource audio;

    [SerializeField]public List<scriptableSound> variants = new List<scriptableSound>();


}
