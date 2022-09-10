using UnityEngine;
using System;
//using UnityExtension;


[CreateAssetMenu(fileName = "Conversa", menuName = "Sistema de dialogo/Nova Conversa")]
public class Conversa : ScriptableObject
{
   [System.Serializable]
   public struct Linha
   {
        public Personagem personagem;
        public AudioClip som;

        [TextArea(3, 5)]
        public string dialogo;    

   }

    public bool Desbloqueado;
    public bool Finalizado;
    public bool ReUsar;
    //[ReorderableList]

    public Linha[] dialogo;

    //////////
    public Pergunta pergunta;
    /////////

}
