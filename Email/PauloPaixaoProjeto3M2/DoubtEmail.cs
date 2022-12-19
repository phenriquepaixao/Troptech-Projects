namespace PauloPaixaoProjeto3M2
{
    public sealed class DoubtEmail : Email
    {
        public bool WasAnswered { get; set; }
        public DoubtEmail()
        {
            //this.Content = contentDoubt;
            this.WasAnswered = false;
        }

        public bool ValidateDoubt()
        {
            if (string.IsNullOrEmpty(this.Content))
                throw new EmailException("A descrição não pode estar em branco, pressione qualquer tecla para continuar.");
                
            return true;
        }

        public override string Display()
        {
            var _wasAnswered = (this.WasAnswered) ? "Sim" : "Não";
            return
                $"==================== Dúvida ====================\n" +
                $"[Número de identificação]: {this.IdNumber}\n" +
                $"[Pergunta]: {this.Content}\n" +
                $"[Respondido]: {_wasAnswered}";
        }
    }
};