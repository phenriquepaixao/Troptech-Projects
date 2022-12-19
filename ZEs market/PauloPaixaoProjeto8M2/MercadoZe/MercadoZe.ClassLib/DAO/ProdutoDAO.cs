using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace MercadoZe.ClassLib.DAO
{
    public class ProdutoDAO
    {
        private string _connectionString = @"server=\SQLEXPRESS;database=DB_MERCADOZE;user id=sa;password=";

        public void CreateProduto(Produto novoProduto)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"INSERT INTO PRODUTOS VALUES (@NOME, @DESCRICAO, @DATAVENCIMENTO, @PRECOUN, @UNIDADE, @QUANTIDADE)";

                    _convertObjToSql(novoProduto, comando);

                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Produto> ReadTodosProdutos()
        {
            var listaProdutos = new List<Produto>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"SELECT * FROM PRODUTOS";

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Produto produtoBuscado = _convertSqlToObj(leitor);

                        listaProdutos.Add(produtoBuscado);
                    }
                }
            }

            return listaProdutos;
        }
        public void UpdateProduto(Produto produtoBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    _convertObjToSql(produtoBuscado, comando);

                    comando.CommandText = @"UPDATE PRODUTOS 
                                            SET NOME = @NOME,
                                                DESCRICAO = @DESCRICAO,
                                                DATAVENCIMENTO = @DATAVENCIMENTO,
                                                PRECOUN = @PRECOUN,
                                                UNIDADE = @UNIDADE,
                                                QUANTIDADE = @QUANTIDADE
                                            WHERE CODIGO = @CODIGO";

                    comando.Parameters.AddWithValue("@CODIGO", produtoBuscado.Codigo);

                    comando.ExecuteNonQuery();
                }
            }
        }
        public void DeleteProduto(Produto produtoBuscado)
        {

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    _convertObjToSql(produtoBuscado, comando);

                    comando.CommandText = @"DELETE FROM PRODUTOS WHERE CODIGO = @CODIGO";

                    comando.Parameters.AddWithValue("@CODIGO", produtoBuscado.Codigo);

                    comando.ExecuteNonQuery();
                }
            }
        }


        public Produto ReadCodigoProduto(int codigoProduto)
        {
            Produto produtoBuscado = new Produto();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @$"SELECT * FROM PRODUTOS WHERE CODIGO = @CODIGO_PRODUTO";
                    comando.Parameters.AddWithValue("@CODIGO_PRODUTO", codigoProduto);

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        produtoBuscado = _convertSqlToObj(leitor);
                    }
                }
            }

            return produtoBuscado;
        }
        public List<Produto> ReadDescricaoProduto(string descricaoProduto)
        {
            var listaProdutos = new List<Produto>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"SELECT * FROM PRODUTOS WHERE DESCRICAO LIKE '%' + @DESCRICAO_PRODUTO +'%'";
                    comando.Parameters.AddWithValue("@DESCRICAO_PRODUTO", descricaoProduto);

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Produto produtoBuscado = _convertSqlToObj(leitor);

                        listaProdutos.Add(produtoBuscado);
                    }
                }
            }

            return listaProdutos;
        }


        public void AddProdutoEstoque(Produto produtoBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    _convertObjToSql(produtoBuscado, comando);

                    comando.CommandText = @"INSERT INTO ESTOQUES VALUES (@CODIGO)";

                    comando.Parameters.AddWithValue("@CODIGO", produtoBuscado.Codigo);

                    comando.ExecuteNonQuery();
                }
            }
        }
        public void RemoveProdutoEstoque(Produto produtoBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    _convertObjToSql(produtoBuscado, comando);

                    comando.CommandText = @"DELETE FROM ESTOQUES WHERE CODIGO_PRODUTO = @CODIGO";

                    comando.Parameters.AddWithValue("@CODIGO", produtoBuscado.Codigo);

                    comando.ExecuteNonQuery();
                }
            }
        }
        public void UpdateQuantidade(Produto produtoBuscado, int quantidade)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    _convertObjToSql(produtoBuscado, comando);

                    comando.CommandText = @"UPDATE PRODUTOS 
                                            SET QUANTIDADE = @NOVA_QUANTIDADE
                                            WHERE CODIGO = @CODIGO_PRODUTO";

                    comando.Parameters.AddWithValue("@CODIGO_PRODUTO", produtoBuscado.Codigo);
                    comando.Parameters.AddWithValue("@NOVA_QUANTIDADE", quantidade);

                    comando.ExecuteNonQuery();
                }
            }
        }


        private void _convertObjToSql(Produto produto, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@NOME", produto.Nome);
            comando.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
            comando.Parameters.AddWithValue("@DATAVENCIMENTO", produto.DataVencimento);
            comando.Parameters.AddWithValue("@PRECOUN", produto.PrecoUn.ToString(CultureInfo.InvariantCulture));
            comando.Parameters.AddWithValue("@UNIDADE", produto.Unidade);
            comando.Parameters.AddWithValue("@QUANTIDADE", produto.Quantidade);
        }

        private Produto _convertSqlToObj(SqlDataReader leitor)
        {
            Produto produto = new Produto();

            produto.Codigo = int.Parse(leitor["CODIGO"].ToString());
            produto.Nome = leitor["NOME"].ToString();
            produto.Descricao = leitor["DESCRICAO"].ToString();
            produto.DataVencimento = DateTime.Parse(leitor["DATAVENCIMENTO"].ToString());
            produto.PrecoUn = double.Parse(leitor["PRECOUN"].ToString());
            produto.Unidade = leitor["UNIDADE"].ToString();
            produto.Quantidade = int.Parse(leitor["QUANTIDADE"].ToString());

            return produto;
        }



    }
}