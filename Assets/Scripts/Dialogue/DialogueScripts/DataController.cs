using UnityEngine;

public class DataController : MonoBehaviour
{
    // Variavel do script para qual enviaremos a data atual selecionada
    public DialogueSystem dialogueSystem;

    // Na Unity iremos colocar os dialogos dentro dessas variaveis
    public DialogueData[] data;


    //Função que será ativada em outros scripts para trocar a Proxima Data de dialogo
    public void WhichData(int valor)
    {
        switch (valor)
        {
            case 1:
                dialogueSystem.Which(data[1]);
                dialogueSystem.Reiniciate();
                break;
            case 2:
                dialogueSystem.Which(data[2]);
                //dialogueSystem.Reiniciate();
                break;
                //case 3:
                //    dialogueSystem.Which(data3);
                //    //dialogueSystem.Reiniciate();
                //    break;
                //case 4:
                //    dialogueSystem.Which(data4);
                //    //dialogueSystem.Reiniciate();
                //    break;
                //case 5:
                //    dialogueSystem.Which(data5);
                //    break;
                //case 6:
                //    dialogueSystem.Which(data6);
                //    break;
        }
    }



}
