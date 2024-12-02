using AutoMapper;
using Fipecafi.Communication.Requests;
using Fipecafi.Communication.Responses;
using Fipecafi.Domain.Entities;
using Fipecafi.Domain.Repositories.Lead;
using Fipecafi.Exceptions.ExceptionsBase;
using Fipecafi.Domain.Repositories;

namespace Fipecafi.Application.Usecases.Leads.Register;

public class RegisterLeadUseCase : IRegisterLeadUseCase
{
    private readonly ILeadWriteOnlyRepository _writeOnlyRepository;
    private readonly ILeadReadOnlyRepository _readOnlyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitofWork _unitOfWork;
    
    public RegisterLeadUseCase(
        ILeadWriteOnlyRepository writeOnlyRepository, 
        ILeadReadOnlyRepository readOnlyRepository, 
        IMapper mapper,
        IUnitofWork unitOfWork)
    {
        _mapper = mapper;
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseRegisteredLeadsJson> Execute(RequestRegisterLeadsJson request)
    {
        // Validar a request
        Validate(request);
        var cursoExiste = await _readOnlyRepository.CursoExists(request.CursoId);
        if (!cursoExiste)
            throw new Exception($"O curso com o ID {request.CursoId} não existe.");

        
        // mapear a request em uma entidade

        var lead = _mapper.Map<Lead>(request);

        // Salvar no banco de dados
        await _writeOnlyRepository.Add(lead);
        await _unitOfWork.Commit();
        return new ResponseRegisteredLeadsJson
        {
            Nome = lead.Nome,
            Email = lead.Email,
            CursoId = lead.CursoId
        };
    }

    private void Validate(RequestRegisterLeadsJson request)
    {
        var validator = new RegisterLeadValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
