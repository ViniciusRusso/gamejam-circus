using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATIVA A CONVERSA
public class DialogueSpeaker : MonoBehaviour
{
    //[ReorderableList]
    public List<Conversa> ConversasDisponiveis = new List<Conversa>();

    //[SerializeField]
    public int indexDeConversas = 0;
    public int dialogoLocalIn = 0;
    //public DialogoUI dialogoUI;
    
    public List<Conversa> ConversasFinalizadas;

    public bool conversou;

    public DialogoUI dialogoUI;

    void Start()
    {

        indexDeConversas = 0;
        dialogoLocalIn = 0;
        conversou = false;

    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(conversou == false)
        {            
            dialogoUI.abrir();
            conversou = true;
            Conversar();
            
        }
        

    }
    public void Conversar()
    {
        if (indexDeConversas <= ConversasDisponiveis.Count - 1)
        {
            if (ConversasDisponiveis[indexDeConversas].Desbloqueado)
            {
                if (ConversasDisponiveis[indexDeConversas].Finalizado)
                {
                    if (AtualizarConversa())
                    {
                        //DialogoManager.MostrarUI(true);
                        DialogoManager.instance.SetConversa(ConversasDisponiveis[indexDeConversas], this);

                    }
                    DialogoManager.instance.SetConversa(ConversasDisponiveis[indexDeConversas], this);
                    return;
                }
                //DialogoManager.MostrarUI(true);
                DialogoManager.instance.SetConversa(ConversasDisponiveis[indexDeConversas], this);
            }
            else
            {
                Debug.LogWarning("Conversa Bloqueada");
                //DialogoManager.MostrarUI(false);

            }
        }
        else
        {
            print("Conversa Encerrada");


            //DialogoManager.MostrarUI(false);
        }
    }

    bool AtualizarConversa()
    {
        if (!ConversasDisponiveis[indexDeConversas].ReUsar)
        {
            if (indexDeConversas < ConversasDisponiveis.Count - 1)
            {
                indexDeConversas++;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }




    public void MudarConversa(int cvs)
    {
        indexDeConversas = cvs;
        DialogoManager.instance.SetConversa(ConversasDisponiveis[cvs], this);
        if (ConversasDisponiveis[cvs].Finalizado)
        {
            var cvsP = cvs + 1;
            //indexDeConversas = cvsP;
            DialogoManager.instance.SetConversa(ConversasDisponiveis[cvsP], this);
        }

    }

    public void ConversaPadrao(int cvs)
    {
        indexDeConversas = cvs;
        DialogoManager.instance.SetConversa(ConversasDisponiveis[cvs], this);

    }


    

}

