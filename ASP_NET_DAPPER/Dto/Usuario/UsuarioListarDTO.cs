namespace ASP_NET_DAPPER.Dto.Usuario
{
    public class UsuarioListarDTO
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public bool Situacao { get; set; }

    }
}
