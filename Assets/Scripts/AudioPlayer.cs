using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)]float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    static AudioPlayer instance;

    
    void Awake()
    {
        ManagerSingleton();
    }

    void ManagerSingleton()
    {
       // int instanceCount = FindObjectsOfType(GetType()).Length;
       // if (instanceCount > 1)
        if(instance !=null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        // AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        PlayClip(shootingClip,shootingVolume);
    }

    public void PlayDamageClip()
    {
        //AudioSource.PlayClipAtPoint(damageClip, Camera.main.transform.position, damageVolume);
        PlayClip(damageClip, damageVolume);
    }

    void PlayClip(AudioClip clip , float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip,cameraPos ,volume);
        }
    }

}
