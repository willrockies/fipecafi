﻿namespace Fipecafi.Communication.Requests;

public class RequestRegisterLeadsJson
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int CursoId { get; set; }
   

}
