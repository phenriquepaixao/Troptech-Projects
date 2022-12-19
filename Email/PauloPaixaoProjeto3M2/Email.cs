namespace PauloPaixaoProjeto3M2
{
    public abstract class Email : IDisplayableEmail
    {
        private static int _counter = 1;
        public int IdNumber { get; protected set; }
        public string Content { get; set; }

        public Email()
        {
            this.IdNumber = _counter++;
        }

        public virtual string Display()
        {
            return null;
        }
    }
}