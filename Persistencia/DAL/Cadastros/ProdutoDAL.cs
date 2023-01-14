using Persistencia.Contexts;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Cadastros
{
    public class ProdutoDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Produto> ObterProdutosClassificadosPorNome()
        {
            return context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).
            OrderBy(n => n.Nome);
        }

        public List<Produto> ObterDestaques()
        {
            ProdutoDAL everything = new ProdutoDAL();
            List<Produto> to_send = new List<Produto>();
            foreach (Produto item in everything.ObterProdutosClassificadosPorNome()){
                if (item.Destaque == true)
                {
                    to_send.Add(item);
                }
            };
            return to_send;

        }

        public List<Produto> ObterTempo()
        {
            DateTime date1 = new DateTime(2022, 12, 9, 0, 0, 0);//antes ou igual
            DateTime date2 = new DateTime(2022, 11, 9, 0, 0, 0);//depois ou igual
            ProdutoDAL everything = new ProdutoDAL();
            List<Produto> to_send = new List<Produto>();
            foreach (Produto item in everything.ObterProdutosClassificadosPorNome())
            {
                int comparacao_limite = DateTime.Compare(item.DataCadastro.Value, date1);
                int comparacao_base = DateTime.Compare(item.DataCadastro.Value, date2);
                if (comparacao_limite==0 || comparacao_limite<0)
                {
                    if(comparacao_base==0 || comparacao_base > 0)
                    {
                        to_send.Add(item);
                    }
                }
            };
            return to_send;

        }
        public Produto ObterProdutoPorId(long id)
        {
            return context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categoria).
            Include(f => f.Fabricante).First();
        }
        public void GravarProduto(Produto produto)
        {
            if (produto.ProdutoId == null)
            {
                context.Produtos.Add(produto);
            }
            else
            {
                context.Entry(produto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Produto EliminarProdutoPorId(long id)
        {
            Produto produto = ObterProdutoPorId(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return produto;
        }

    }
}
