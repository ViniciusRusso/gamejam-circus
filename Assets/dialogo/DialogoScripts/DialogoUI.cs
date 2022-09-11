using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//ATUALIZA OS TEXTOS, ATIVA AS PERGUNTAS

public class DialogoUI : MonoBehaviour
{
    public Conversa conversa;
    public Conversa conversaPadrao;
    [SerializeField]
    private float textSpeed;

    [SerializeField]
    private GameObject ConversaContainer;
    [SerializeField]
    private GameObject PerguntaContainer;

    [SerializeField]
    private Image SpeakerImg;
    [SerializeField]
    private TextMeshProUGUI nome;
    [SerializeField]
    private TextMeshProUGUI TextCvs;

    [SerializeField]
    private Button ProximoButton;
    [SerializeField]
    private Button AnteriorButton;

    [SerializeField]
    private AudioSource audioSource;

    public int LocalIn = 1;

    public Animator anim;
    //public IniciarConversa iniciarConversa;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ConversaContainer.SetActive(true);
        PerguntaContainer.SetActive(false);

        ProximoButton.gameObject.SetActive(true);
        AnteriorButton.gameObject.SetActive(false);

        anim = GetComponent<Animator>();
        


    }

    public void abrir()
    {
        
        anim.SetTrigger("open");
        AtualizarTextos(0);
        
    }
    


   
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AtualizarTextos(1);
        }
    }

    public void AtualizarTextos(int comportamento)
    {
        ConversaContainer.SetActive(true);
        PerguntaContainer.SetActive(false);

        switch (comportamento)
        {
            case -1:
                if (LocalIn > 0)
                {
                    print("Dialogo Anterior");
                    LocalIn--;

                    nome.text = conversa.dialogo[LocalIn].personagem.nome;
                    StopAllCoroutines();
                    StartCoroutine(EscreverTexto());
                    //TextCvs.text = conversa.dialogo[LocalIn].dialogo;
                    SpeakerImg.sprite = conversa.dialogo[LocalIn].personagem.imagem;

                    if (conversa.dialogo[LocalIn].som != null)
                    {
                        audioSource.Stop();
                        var audio = conversa.dialogo[LocalIn].som;
                        audioSource.PlayOneShot(audio);
                    }
                    AnteriorButton.gameObject.SetActive(LocalIn > 0);
                    ProximoButton.GetComponentInChildren<TextMeshProUGUI>().text = "Próximo";
                }
                DialogoManager.speakerAtual.dialogoLocalIn = LocalIn; 
                break;
        
            case 0:
                             
                print("Dialogo Atualizado");
                    

                nome.text = conversa.dialogo[LocalIn].personagem.nome;
                StopAllCoroutines();
                StartCoroutine(EscreverTexto());
                //TextCvs.text = conversa.dialogo[LocalIn].dialogo;
                SpeakerImg.sprite = conversa.dialogo[LocalIn].personagem.imagem;

                if (conversa.dialogo[LocalIn].som != null)
                 {
                   audioSource.Stop();
                   var audio = conversa.dialogo[LocalIn].som;
                   audioSource.PlayOneShot(audio);
                 }

                AnteriorButton.gameObject.SetActive(LocalIn > 0);

                if (LocalIn >= conversa.dialogo.Length - 1 && conversa.pergunta == null)
                {
                    ProximoButton.GetComponentInChildren<TextMeshProUGUI>().text= "Finalizar";
                }
                else
                {
                    ProximoButton.GetComponentInChildren<TextMeshProUGUI>().text = "Próximo";
                }
               
              break;

            case 1:
                if (LocalIn < conversa.dialogo.Length - 1)
                {
                    print("Dialogo Seguinte");
                    LocalIn++;

                    nome.text = conversa.dialogo[LocalIn].personagem.nome;
                    StopAllCoroutines();
                    StartCoroutine(EscreverTexto());
                    //TextCvs.text = conversa.dialogo[LocalIn].dialogo;
                    SpeakerImg.sprite = conversa.dialogo[LocalIn].personagem.imagem;

                    if (conversa.dialogo[LocalIn].som != null)
                    {
                        audioSource.Stop();
                        var audio = conversa.dialogo[LocalIn].som;
                        audioSource.PlayOneShot(audio);
                    }
                    AnteriorButton.gameObject.SetActive(LocalIn > 0);
                    if (LocalIn >= conversa.dialogo.Length - 1 && conversa.pergunta == null)
                    {
                        ProximoButton.GetComponentInChildren<TextMeshProUGUI>().text = "Finalizar";
                    }
                    else
                    {
                        ProximoButton.GetComponentInChildren<TextMeshProUGUI>().text = "Próximo";
                    }
                }
                else
                {
                    print("Dialogo encerrado");
                    LocalIn = 0;
                    DialogoManager.speakerAtual.dialogoLocalIn = 0;
                    conversa.Finalizado = true;
                    //////////
                    if(conversa.pergunta != null)
                    {
                        
                        Perguntar();
                        return;
                                            
                    }
                    else
                    {
                        //conversaPadrao.pergunta != null

                        
                        anim.SetTrigger("close");


                        //iniciarConversa.revelar();
                        
                      
                      print("fechou");
                        
                        

                        
                       
                    }
                    ///////// 
                    //DialogoManager.instance.MostrarUi(false);
                    return;
                }
                DialogoManager.speakerAtual.dialogoLocalIn = LocalIn;
                break;

            default:
                Debug.LogWarning("valor invalido");
                break;
        }

    }

    public void Perguntar()
    {
        ConversaContainer.SetActive(false);
        PerguntaContainer.SetActive(true);
        var pergunta = conversa.pergunta;
        DialogoManager.instance.ctrPerguntas.AtivarBotoes(pergunta.opcoes.Length, pergunta.pergunta, pergunta.opcoes);
    }

    IEnumerator EscreverTexto()
    {     
        TextCvs.maxVisibleCharacters = 0;
        TextCvs.text = conversa.dialogo[LocalIn].dialogo;
        TextCvs.richText = true;

        for (int i = 0; i < conversa.dialogo[LocalIn].dialogo.ToCharArray().Length; i++)
        {
            TextCvs.maxVisibleCharacters++;
            yield return new WaitForSeconds(1f / textSpeed) ;


        }
    }

    public void WaitAndGo()
    {

         int n = TextCvs.text.Length;
        
         if (TextCvs.maxVisibleCharacters < n)
         {
            TextCvs.maxVisibleCharacters = n;
         }
        else
        {
            AtualizarTextos(1);
        }
          
          //StartCoroutine(EsperaEAvança());
        
    }

    IEnumerator EsperaEAvança()
    {
        yield return new WaitForSeconds(1);
        //AtualizarTextos(1);
        
    }
}
