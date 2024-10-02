using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public static ApplicationManager Instance;
    [SerializeField] private KeyCode _quitKey=KeyCode.Escape;

    private void Awake()
    {
        //on cr�e l'instance du singleton si elle n'existe pas d�ja
        if (Instance != null && Instance != this)
        {
            //sinon on la detryut
            Destroy(this);
            return;
        }
        Instance = this;//affectation de l'instance

        //on veut rester activ� dans toutes les sc�nes
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(_quitKey))
        {
            Quit();
        }
    }
    public void Quit()
    {
        //utilisation des compilations dynamique
#if UNITY_EDITOR
        //on arrete le mode play de l'�diteur
        EditorApplication.isPlaying = false;
#else

        //on quitte le build

        Application.Quit();
#endif
    }
}
