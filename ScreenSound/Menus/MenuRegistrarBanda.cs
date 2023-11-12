using OpenAI_API;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus
{
    internal class MenuRegistrarBanda : Menu
    {
        public override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            base.Executar(bandasRegistradas);
            ExibirTituloDaOpcao("Registro das bandas");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!;
            Banda banda = new Banda(nomeDaBanda);
            bandasRegistradas.Add(nomeDaBanda, banda);

            //var client = new OpenAIAPI("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");

            var client = new OpenAIAPI("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");
            
            var chat = client.Chat.CreateConversation();

            chat.AppendSystemMessage($"Fale me sobre a banda {nomeDaBanda} com no maximo em um paragrafo");
            try
            {
                string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
                banda.Resumo = resposta;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nNao foi possivel Armazenar o resumo da Banda\n");
                Console.WriteLine(e.Message);
            }


            Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
