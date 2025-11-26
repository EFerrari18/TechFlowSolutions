using Microsoft.AspNetCore.Mvc;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Controllers
{
    public class FaqController : Controller
    {
        // === Base interna de perguntas/respostas com categorias ===
        private static readonly List<FaqItem> DadosFaq = new List<FaqItem>
        {
            // 📌 Categoria: Chamados
            new FaqItem { Categoria="Chamados", Pergunta="Como abrir um chamado?", Resposta="Clique em 'Abrir Chamado', preencha o formulário e clique em Salvar." },
            new FaqItem { Categoria="Chamados", Pergunta="Posso editar um chamado?", Resposta="Sim. No menu Gerenciar Chamados, clique em Editar no item desejado." },
            new FaqItem { Categoria="Chamados", Pergunta="Como excluir um chamado?", Resposta="Em Gerenciar Chamados, clique em Excluir e confirme a ação." },
            new FaqItem { Categoria="Chamados", Pergunta="O que significa a prioridade do chamado?", Resposta="Define o nível de urgência: Baixa, Média ou Alta." },

            // 📌 Categoria: Conta / Acesso
            new FaqItem { Categoria="Acesso", Pergunta="Como redefinir minha senha?", Resposta="Entre em contato com o administrador para restauração da senha." },
            new FaqItem { Categoria="Acesso", Pergunta="Esqueci meu email de login", Resposta="Solicite ao suporte a verificação dos seus dados de acesso." },

            // 📌 Categoria: Sistema & Erros
            new FaqItem { Categoria="Sistema", Pergunta="O sistema não carrega", Resposta="Atualize a página ou tente novamente em instantes. Se persistir, contate o suporte." },
            new FaqItem { Categoria="Sistema", Pergunta="Erro ao salvar um chamado", Resposta="Revise os campos obrigatórios. Se continuar, comunique suporte com print do erro." },

            // 📌 Categoria: Status e acompanhamento
            new FaqItem { Categoria="Status", Pergunta="Como acompanhar o status do meu chamado?", Resposta="Acesse Gerenciar Chamados para ver o andamento." },
            new FaqItem { Categoria="Status", Pergunta="O que significa status Em Atendimento?", Resposta="O técnico recebeu sua solicitação e está trabalhando na solução." }
        };

        // VIEW PRINCIPAL + BUSCA
        public IActionResult Index(string q)
        {
            ViewBag.Search = q;

            var lista = DadosFaq;

            if (!string.IsNullOrEmpty(q))
            {
                q = q.ToLower();
                lista = lista
                    .Where(f =>
                        f.Pergunta.ToLower().Contains(q) ||
                        f.Resposta.ToLower().Contains(q))
                    .ToList();
            }

            return View(lista);
        }
    }
}
