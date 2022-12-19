using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoZe.ClassLib.DAO
{
    public class PedidoDAO
    {
        private string _connectionString = @"server=\SQLEXPRESS;database=DB_MERCADOZE;user id=sa;password=";

        public void CreatePedido(Pedido novoPedido)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"INSERT INTO PEDIDOS (DATAPEDIDO, CODIGO_PRODUTO, QUANTIDADE, VALORTOTAL, CPF_CLIENTE)
                                            VALUES (@DATAPEDIDO, @CODIGO_PRODUTO, @QUANTIDADE, @VALORTOTAL, @CPF_CLIENTE)";

                    _convertObjToSql(novoPedido, comando);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Pedido> ReadTodosPedidos()
        {
            var listaPedidos = new List<Pedido>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"SELECT 
                                                PEDIDOS.CODIGO,
                                                PEDIDOS.CODIGO_PRODUTO,
                                                PRODUTOS.NOME AS NOME_PRODUTO,
                                                PEDIDOS.DATAPEDIDO,
                                                PEDIDOS.QUANTIDADE,
                                                PEDIDOS.VALORTOTAL,
                                                CLIENTES.CPF,
                                                CLIENTES.NOME AS NOME_CLIENTE
                                            FROM PEDIDOS 
                                            INNER JOIN 
                                                PRODUTOS ON PEDIDOS.CODIGO_PRODUTO = PRODUTOS.CODIGO
                                            LEFT JOIN 
                                                CLIENTES ON PEDIDOS.CPF_CLIENTE = CLIENTES.CPF";

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Pedido pedidoBuscado = _convertSqlToObj(leitor);

                        listaPedidos.Add(pedidoBuscado);
                    }
                }
            }

            return listaPedidos;
        }

        

        private void _convertObjToSql(Pedido pedido, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@DATAPEDIDO", DateTime.Now);
            comando.Parameters.AddWithValue("@CODIGO_PRODUTO", pedido.Produto.Codigo);
            comando.Parameters.AddWithValue("@QUANTIDADE", pedido.Quantidade);
            comando.Parameters.AddWithValue("@VALORTOTAL", pedido.ValorTotal.ToString(CultureInfo.InvariantCulture));
            comando.Parameters.AddWithValue("@CPF_CLIENTE", pedido.Cliente.Cpf);
        }

        private Pedido _convertSqlToObj(SqlDataReader leitor)
        {
            Pedido pedido = new Pedido();

            pedido.Codigo = Int32.Parse(leitor["CODIGO"].ToString());
            pedido.Produto = new Produto()
            {
                Codigo = Int32.Parse(leitor["CODIGO_PRODUTO"].ToString()),
                Nome = leitor["NOME_PRODUTO"].ToString()
            };
            pedido.DataPedido = DateTime.Parse(leitor["DATAPEDIDO"].ToString());
            pedido.Quantidade = int.Parse(leitor["QUANTIDADE"].ToString());
            pedido.ValorTotal = double.Parse(leitor["VALORTOTAL"].ToString());
            pedido.Cliente = new Cliente()
            {
                Cpf = leitor["CPF"].ToString(),
                Nome = leitor["NOME_CLIENTE"].ToString()
            };

            return pedido;
        }
    }
}