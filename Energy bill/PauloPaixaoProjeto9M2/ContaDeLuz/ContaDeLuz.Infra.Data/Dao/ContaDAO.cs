using System;
using System.Data.SqlClient;
using System.Globalization;
using ContaDeLuz.Dominio;

namespace ContaDeLuz.Infra.Data.Dao
{
    public class ContaDAO
    {
        private string _connectionString = @"server=DESKTOP-7CB3TL2\SQLEXPRESS;database=DB_CONTADELUZ;user id=sa;password=Xw6q2@12345678";
        public void CadastraConta(Conta novaConta)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    comando.CommandText = @"INSERT INTO 
                                                CONTAS (NUMEROLEITURA, DATALEITURA, KW, VALORPAGAMENTO, DATAPAGAMENTO, MEDIACONSUMO)
                                                VALUES (@NUMEROLEITURA, @DATALEITURA, @KW, @VALORPAGAMENTO, @DATAPAGAMENTO, @MEDIACONSUMO)";

                    _convertObjToSql(novaConta, comando);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public Conta BuscarMesAnoConta(int mes, int ano)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    comando.CommandText = @"SELECT *
                                            FROM CONTAS
                                            WHERE
                                                MONTH(DATALEITURA) = @MESDATALEITURA AND
                                                YEAR(DATALEITURA) = @ANODATALEITURA";

                    comando.Parameters.AddWithValue("@MESDATALEITURA", mes);
                    comando.Parameters.AddWithValue("@ANODATALEITURA", ano);

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        return _convertSqlToObj(leitor);
                    }
                }
            }

            return null;
        }
        private void _convertObjToSql(Conta conta, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@NUMEROLEITURA", conta.NumeroLeitura);
            comando.Parameters.AddWithValue("@DATALEITURA", conta.DataLeitura);
            comando.Parameters.AddWithValue("@KW", conta.Kw);
            comando.Parameters.AddWithValue("@VALORPAGAMENTO", conta.ValorPagamento.ToString(CultureInfo.InvariantCulture));
            comando.Parameters.AddWithValue("@DATAPAGAMENTO", conta.DataPagamento);
            comando.Parameters.AddWithValue("@MEDIACONSUMO", conta.MediaConsumo.ToString(CultureInfo.InvariantCulture));
        }

        private Conta _convertSqlToObj(SqlDataReader leitor)
        {
            var numeroLeitura = int.Parse(leitor["NUMEROLEITURA"].ToString());
            var dataLeitura = DateTime.Parse(leitor["DATALEITURA"].ToString());
            var kw = int.Parse(leitor["KW"].ToString());
            var valorPagamento = Convert.ToDouble(leitor["VALORPAGAMENTO"]);
            var dataPagamento = DateTime.Parse(leitor["DATAPAGAMENTO"].ToString());
            var mediaConsumo = double.Parse(leitor["MEDIACONSUMO"].ToString());

            return new Conta(numeroLeitura, dataLeitura, kw, valorPagamento, dataPagamento, mediaConsumo);
        }
    }
}