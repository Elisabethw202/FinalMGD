using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    void Awake(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
            
        if(objs.Length > 1){
                // this is obviously a copy and should not be in the level.
            Destroy(this.gameObject);
        }
            
        DontDestroyOnLoad(this.gameObject);
    }

    public int mainMenuIndex = 0;
    public int worldIndex = 1;
    public int world2Index = 4;
    public int world3Index = 7;

    public List<AudioClip> songs = new List<AudioClip>();

    private AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = this.GetComponent<AudioSource>();
        aud.clip = songs[0];
        aud.Play();
        
    }

    public bool debug = true;
    // Update is called once per frame
    void Update()
    {
        if(debug){
            if(Input.GetKeyDown(KeyCode.Alpha9)){
                Debug.Log("Starting next level!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                StartCoroutine(StartNextLevel());
            }
        }
    }
    
    public IEnumerator StartNextLevel(){
        yield return new WaitForSeconds(0.5f);
        int currentIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if(currentIndex >= mainMenuIndex){
            aud.clip = songs[0];
            aud.Play();
        }
        else if (currentIndex == worldIndex){
            aud.clip = songs[1];
            aud.Play();
        }
         else if (currentIndex == world2Index){
            aud.clip = songs[2];
            aud.Play();
        }
         else if (currentIndex == world3Index){
            aud.clip = songs[3];
            aud.Play();
        }
    }
}
