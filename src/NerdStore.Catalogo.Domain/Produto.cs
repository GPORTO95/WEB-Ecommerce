using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        /// <summary>
        /// Construtores
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="descricao"></param>
        /// <param name="ativo"></param>
        /// <param name="valor"></param>
        /// <param name="categoriaId"></param>
        /// <param name="dataCadastro"></param>
        /// <param name="imagem"></param>
        public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime dataCadastro, string imagem)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
        }
        /// <summary>
        /// Propriedades
        /// </summary>
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }

        public Guid CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }
        /// <summary>
        /// Add hook setters
        /// </summary>
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }
        public void AlterarDescricao(string descricao) => Descricao = descricao;
        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0)
                quantidade *= -1;

            QuantidadeEstoque -= quantidade;
        }
        public bool ReporEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }
        public void Validar()
        {

        }
    }

    public class Categoria : Entity
    {
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

    }
}
