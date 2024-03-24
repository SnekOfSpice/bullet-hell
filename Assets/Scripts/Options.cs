using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject soundMixerManager;
    private void Start()
    {
        this.gameObject.transform.Find("MasterVolumeSlider").GetComponent<Slider>().value = soundMixerManager.GetComponent<SoundMixerManager>().GetMasterLevel();
    }
}
