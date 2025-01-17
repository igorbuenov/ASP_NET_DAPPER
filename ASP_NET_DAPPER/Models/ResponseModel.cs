using ASP_NET_DAPPER.Dto.Usuario;

namespace ASP_NET_DAPPER.Models
{
    public class ResponseModel<T>
    {

        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

        
    }
}
