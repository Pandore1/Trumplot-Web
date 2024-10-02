using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplicationManager : MonoBehaviour
{
    public static ApplicationManager Instance;
    
    [SerializeField] private KeyCode _quitKey=KeyCode.Escape;
    [SerializeField] private GameObject _policeBtn;
    [SerializeField] private GameObject _townBtn;


    public Notebook _noteBookScript;

    private void Awake()
    {
        //on crée l'instance du singleton si elle n'existe pas déja
        if (Instance != null && Instance != this)
        {
            //sinon on la detryut
            Destroy(this);
            return;
        }
        Instance = this;//affectation de l'instance

        //on veut rester activé dans toutes les scènes
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "PoliceStation")
        {
            _townBtn.SetActive(true);
            _policeBtn.SetActive(false);
        }
        else if (scene.name == "Town")
        {
            _policeBtn.SetActive(true);
            _townBtn.SetActive(false);
        }
     
        if (Input.GetKeyUp(_quitKey))
        {
            Quit();
        }
    }
    public void Quit()
    {
        //utilisation des compilations dynamique
#if UNITY_EDITOR
        //on arrete le mode play de l'éditeur
        EditorApplication.isPlaying = false;
#else

        //on quitte le build

        Application.Quit();
#endif
    }
}
