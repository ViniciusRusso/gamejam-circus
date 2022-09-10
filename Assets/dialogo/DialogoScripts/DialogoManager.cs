using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandartAssets.Characters.FirstPerson;

// REUSAR E DESBLOQUEAR, ATUALIZA O DIALOGO
public class DialogoManager : MonoBehaviour
{
    public static DialogoManager instance { get; private set; }
    public static DialogueSpeaker speakerAtual;
    [SerializeField]
    private DialogoUI dialogoUI;
    [SerializeField]
    private GameObject player;
    
   
    //////////
    public CtrPerguntas ctrPerguntas;
    //////////

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
           DontDestroyOnLoad(gameObject);
        }
        else
        {
          Destroy(gameObject);
        }

        dialogoUI = FindObjectOfType<DialogoUI>();

        //player.GetComponent<DialogueSpeaker>().Conversar();
        speakerAtual = FindObjectOfType<DialogueSpeaker>();

        //////////
        ctrPerguntas = FindObjectOfType<CtrPerguntas>();
        //////////

    }

    private void Update()
    { 
        if(ctrPerguntas == null)
        {
            ctrPerguntas = FindObjectOfType<CtrPerguntas>();
        }
     
    }
    void Start()
    {
        
        player.GetComponent<DialogueSpeaker>().Conversar();

        dialogoUI = FindObjectOfType<DialogoUI>();
        ctrPerguntas = FindObjectOfType<CtrPerguntas>();
    }

    
    public void SetConversa(Conversa cvs, DialogueSpeaker speaker)
    {
        ///////////////
        if (speaker != null)
        {
            speakerAtual = speaker;
        }
        else
        {
            dialogoUI.conversa = cvs;
            dialogoUI.LocalIn = 0;
            dialogoUI.AtualizarTextos(0);
        }
        if(cvs.Finalizado && !cvs.ReUsar)
        {
            dialogoUI.conversa = cvs;
            dialogoUI.LocalIn = cvs.dialogo.Length;
            dialogoUI.AtualizarTextos(1);
        }
        else
        {
            
            dialogoUI.conversa = cvs;
            dialogoUI.LocalIn = speakerAtual.dialogoLocalIn;
            dialogoUI.AtualizarTextos(0);
        }
        ////////////////
    }

    /////////
    public void MudarEstadoReUsar(Conversa cvs, bool estadoDesejado)
    {
        cvs.ReUsar = estadoDesejado;
    }public void DesbloquearEBloquearConversa(Conversa cvs, bool desbloquear)
    {
        cvs.Desbloqueado = desbloquear;
    }
    ////////
}
