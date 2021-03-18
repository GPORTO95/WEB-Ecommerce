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

            Validar();
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
        public void AlterarDescricao(string descricao)
        {
            Validacoes.ValidarSeVazio(descricao, "O campo Descricao não pode estar vazio");
            Descricao = descricao;
        }
        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0)
                quantidade *= -1;

            if (!PossuiEstoque(quantidade))
                throw new DomainException("Estoque insuficiente");

            QuantidadeEstoque -= quantidade;
        }
        public bool ReporEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }
        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }
        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto não pode estar vazio!");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do produto não pode estar vazio!");
            Validacoes.ValidarSeDiferente(CategoriaId, Guid.Empty, "O campo CategoriaId não pode estar vazio");
            Validacoes.ValidarSeMenorIgualMinimo(Valor, 0, "O campo Valor do produto não pode ser menor ou igual a zero");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode estar vazio!");
        }
    }
}
