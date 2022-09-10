using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Opcoes
{
    [TextArea(2, 4)]
    public string opcao;
    public Conversa conversaResultante;
}

[CreateAssetMenu(fileName = "Pergunta", menuName = "Sistema de dialogo/Nova Pergunta")]
public class Pergunta : ScriptableObject
{
    [TextArea(3, 5)]
    public string pergunta;
    public Opcoes[] opcoes;
}
