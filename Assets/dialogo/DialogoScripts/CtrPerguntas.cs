using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CtrPerguntas : MonoBehaviour
{
    [SerializeField]
    public GameObject ButtonPrefab;
    [SerializeField]
    public TextMeshProUGUI PerguntaText;
    [SerializeField]
    public Transform OpcoesContainer;
    public List<Button> poolButtons = new List<Button>();

    
    void Start()
    {  

    }

    public void AtivarBotoes(int Quantidade, string Title, Opcoes[]opcoes)
    {
        PerguntaText.text = Title;
       

        if (poolButtons.Count >= Quantidade)
        {
            for (int i = 0; i < poolButtons.Count; i++)
            {
                if (i< Quantidade)
                {
                    poolButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = opcoes[i].opcao;
                    poolButtons[i].onClick.RemoveAllListeners();
                    Conversa co = opcoes[i].conversaResultante;
                    poolButtons[i].onClick.AddListener(() => DarFuncaoAosBotoes(co));
                    poolButtons[i].gameObject.SetActive(true);
                    
                }
                else
                {
                    poolButtons[i].gameObject.SetActive(false);
                 
                }
            }
        }
        else
        {
            int quantidadeRestante = (Quantidade - poolButtons.Count);
            for (int i = 0; i < quantidadeRestante; i++)
            {
                var newButton = Instantiate(ButtonPrefab, OpcoesContainer).GetComponent<Button>();
                newButton.gameObject.SetActive(true);
                poolButtons.Add(newButton);
            }
            AtivarBotoes(Quantidade, Title, opcoes);
        }
    }
    public void DarFuncaoAosBotoes(Conversa cvs)
    {
        DialogoManager.instance.SetConversa(cvs, null);
    }
}
