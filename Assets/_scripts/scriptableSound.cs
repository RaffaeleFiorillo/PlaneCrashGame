using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
using evenEnum;
using System.Diagnostics.Tracing;

[CreateAssetMenu(fileName = "SoundInfo")]
public class scriptableSound : ScriptableObject
{
    [SerializeField] public AudioResource audio;
    [SerializeField] public AudioResource notFollowAudio;
   
    [Header("Not required")]
    [SerializeField] public AudioSource doingGreat;
    [SerializeField] public AudioSource doingWrong;

    [Header("If Event")]
    public bool noEvent;
    public theEnum nextEvent;

    [Header("Evento especifico")]
    [Range(-1,1)] public int direcao;

    [Space]
    [SerializeField]public List<scriptableSound> variants = new List<scriptableSound>();
    public float timing;
}
