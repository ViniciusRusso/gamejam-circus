using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IniciarConversa : MonoBehaviour
{

    public DialogoUI dialogoUI;
    public Conversa conversa;
    public Conversa conversaPadrão;
    public Conversa conversaAjuda;
    public GameObject Revelar;
    public GameObject esconder;
    public bool revelou;
    

    void Awake()
    {
        revelou = false;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (conversa.Finalizado)
            {
                if (revelou == false)
                {
                    revelar();
                    revelou = true;
                }

            }
        
        
       
    }



    public void revelar()
    {
        if(Revelar != null)
        {
            this.Revelar.SetActive(true);
        }
        
    }

    


    public void AbrirConversa()
    {
        revelou = false;


        if (!conversa.Finalizado)
        {
            dialogoUI.abrir();
            if (esconder != null)
            {
                this.esconder.SetActive(false);
            }


        }
        else
        {
            if (conversaPadrão.ReUsar)
            {
              dialogoUI.abrir();
                if (esconder != null)
                {
                    this.esconder.SetActive(false);
                }

            }


            
        }
    }
}
