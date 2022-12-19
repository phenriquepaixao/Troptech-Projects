using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MercadoZe.ClassLib.DAO
{
    public class ClienteDAO
    {
        private string _connectionString = @"server=\SQLEXPRESS;database=DB_MERCADOZE;user id=sa;password=";

        public void CreateCliente(Cliente novoCliente)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"INSERT INTO CLIENTES 
                                            VALUES (@CPF, @NOME, @DATANASCIMENTO, @PONTOS, @RUA, @NUMERO, @BAIRRO, @CEP, @COMPLEMENTO)";

                    _convertObjToSql(novoCliente, comando);

                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Cliente> ReadTodosClientes()
        {
            var listaClientes = new List<Cliente>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"SELECT * FROM CLIENTES";

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Cliente clienteBuscado = _convertSqlToObj(leitor);

                        listaClientes.Add(clienteBuscado);
                    }
                }
            }

            return listaClientes;
        }
        public void UpdateCliente(Cliente clienteBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    _convertObjToSql(clienteBuscado, comando);

                    comando.CommandText = @"UPDATE CLIENTES 
                                            SET CPF = @CPF,
                                                NOME = @NOME,
                                                DATANASCIMENTO = @DATANASCIMENTO,
                                                PONTOS = @PONTOS,
                                                RUA = @RUA,
                                                NUMERO = @NUMERO,
                                                BAIRRO = @BAIRRO,
                                                CEP = @CEP,
                                                COMPLEMENTO = @COMPLEMENTO
                                            WHERE CPF = @CPF_CLIENTE";

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", clienteBuscado.Cpf);

                    comando.ExecuteNonQuery();
                }
            }
        }
        public void DeleteCliente(Cliente clienteBuscado)
        {

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    _convertObjToSql(clienteBuscado, comando);

                    comando.CommandText = @"DELETE FROM CLIENTES WHERE CPF = @CPF_CLIENTE";

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", clienteBuscado.Cpf);

                    comando.ExecuteNonQuery();
                }
            }
        }


        public Cliente ReadCpfCliente(string cpfCliente)
        {
            Cliente clienteBuscado = new Cliente();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @$"SELECT * FROM CLIENTES WHERE CPF = @CPF";
                    comando.Parameters.AddWithValue("@CPF", cpfCliente);

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        clienteBuscado = _convertSqlToObj(leitor);
                    }
                }
            }

            return clienteBuscado;
        }
        public List<Cliente> ReadNomeCliente(string nomeCliente)
        {
            var listaClientes = new List<Cliente>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"SELECT * FROM CLIENTES WHERE NOME LIKE '%' + @NOME +'%'";
                    comando.Parameters.AddWithValue("@NOME", nomeCliente);

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Cliente clienteBuscado = _convertSqlToObj(leitor);

                        listaClientes.Add(clienteBuscado);
                    }
                }
            }

            return listaClientes;
        }

        public void UpdatePontosFidelidadeCliente(Cliente clienteBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    _convertObjToSql(clienteBuscado, comando);

                    comando.CommandText = @"UPDATE CLIENTES 
                                            SET PONTOS = @PONTOS
                                            WHERE CPF = @CPF_CLIENTE";

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", clienteBuscado.Cpf);

                    comando.ExecuteNonQuery();
                }
            }
        }

        private void _convertObjToSql(Cliente cliente, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@DATANASCIMENTO", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@PONTOS", cliente.PontosFidelidade);
            comando.Parameters.AddWithValue("@RUA", cliente.Endereco.Rua);
            comando.Parameters.AddWithValue("@NUMERO", cliente.Endereco.Numero);
            comando.Parameters.AddWithValue("@BAIRRO", cliente.Endereco.Bairro);
            comando.Parameters.AddWithValue("@CEP", cliente.Endereco.Cep);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.Endereco.Complemento);
        }

        private Cliente _convertSqlToObj(SqlDataReader leitor)
        {
            Cliente cliente = new Cliente();

            cliente.Cpf = leitor["CPF"].ToString();
            cliente.Nome = leitor["NOME"].ToString();
            cliente.DataNascimento = DateTime.Parse(leitor["DATANASCIMENTO"].ToString());
            cliente.PontosFidelidade = int.Parse(leitor["PONTOS"].ToString());
            cliente.Endereco = new Endereco()
            {
                Rua = leitor["RUA"].ToString(),
                Numero = int.Parse(leitor["NUMERO"].ToString()),
                Bairro = leitor["BAIRRO"].ToString(),
                Cep = leitor["CEP"].ToString(),
                Complemento = leitor["COMPLEMENTO"].ToString(),
            };

            return cliente;
        }




    }
}