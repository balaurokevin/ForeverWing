using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audio.Play();
    }

   
        void Update()
        {
            if (Input.GetKey("escape"))
                Application.Quit();

        }

    public void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(1);
    }
}
