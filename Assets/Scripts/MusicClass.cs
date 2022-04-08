using UnityEngine;

 public class MusicClass : MonoBehaviour
 {
     private AudioSource _audioSource;
     private void Awake()
     {
         DontDestroyOnLoad(transform.gameObject);
         _audioSource = GetComponent<AudioSource>();
     }
 
     public void PlayMusic()
     {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1) {
            return;
        }
        _audioSource.Play();
         
     }
 
     public void StopMusic()
     {
         _audioSource.Stop();
     }
 }