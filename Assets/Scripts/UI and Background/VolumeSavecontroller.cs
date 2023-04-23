using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Recorder.OutputPath;

public class VolumeSavecontroller : MonoBehaviour
{
    [SerializeField] private Slider VolumeSli = null;
    [SerializeField] private Text Volumelabel= null;

    private void Start()
    {

        loadvalue();
    }
    public void Savevolumebutton()
    {
        float Volumevalue= VolumeSli.value;
        PlayerPrefs.SetFloat("VolumeValue", Volumevalue);
        loadvalue();
    }
    void loadvalue()
    {
        float volumevalue = PlayerPrefs.GetFloat("VolumeValue");
        VolumeSli.value= volumevalue;
        AudioListener.volume= volumevalue;  
    }
}
