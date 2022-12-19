namespace PauloPaixaoProjeto3M2
{
    public sealed class AnswerEmail : Email
    {
        private int _idDoubt { get; set; }
        private bool _wasAnswered { get; set; }
        private string _contentDoubt { get; set; }

        public AnswerEmail(string contentAnswer, int idDoubt, string contentDoubt)
        {
            this._wasAnswered = false;
            this.Content = contentAnswer;
            this._idDoubt = idDoubt;
            this._contentDoubt = contentDoubt;
        }

        public bool ValidateAnswer()
        {
            if (string.IsNullOrEmpty(this.Content))
                throw new EmailException("O campo Resposta é obrigatório.");
                
            return true;
        }

        public override string Display()
        {
            return
            $"==================== Resposta ====================\n" +
            $"[Número de identificação do email de dúvida]: {this._idDoubt}\n" +
            $"[Número de identificação]: {this.IdNumber}\n" +
            $"[Dúvida]: {this._contentDoubt}\n" +
            $"[Resposta]: {this.Content}";
        }


    }
}