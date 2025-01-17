namespace ASP_NET_DAPPER.Dto.Usuario
{
    public class UsuarioCriarDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public string CPF { get; set; }
        public bool Situacao { get; set; }
        public string Senha { get; set; }
    }
}
