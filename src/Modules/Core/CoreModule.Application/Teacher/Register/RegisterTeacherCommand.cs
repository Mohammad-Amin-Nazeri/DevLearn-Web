using Common.Application;
using Common.Application.FileUtil.StorageInterfaces;
using CoreModule.Application._Utilities;
using CoreModule.Domain.Teacher.DomainServices;
using CoreModule.Domain.Teacher.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace CoreModule.Application.Teacher.Register;

public class RegisterTeacherCommand : IBaseCommand
{
    public IFormFile CvFile { get; set; }
    public string UserName { get; set; }
    public Guid UserId { get; set; }
}

public class RegisterTeacherCommandHandler : IBaseCommandHandler<RegisterTeacherCommand>
{
    private readonly ITeacherRepository _repository;
    private readonly ITeacherDomainService _domainService;
    private readonly IStorageService _storageService;
    public RegisterTeacherCommandHandler(ITeacherRepository repository, ITeacherDomainService domainService, IStorageService storageService)
    {
        _repository = repository;
        _domainService = domainService;
        _storageService = storageService;
    }

    public async Task<OperationResult> Handle(RegisterTeacherCommand request, CancellationToken cancellationToken)
    {
        var cvFileName = await _storageService.SaveFileAndGenerateName(request.CvFile, CoreModuleDirectories.CvFileNames);

        var teacher = new Domain.Teacher.Models.Teacher(cvFileName, request.UserName, request.UserId, _domainService);
        _repository.Add(teacher);
        await _repository.Save();
        return OperationResult.Success();
    }
}


public class RegisterTeacherCommandValidator : AbstractValidator<RegisterTeacherCommand>
{
    public RegisterTeacherCommandValidator()
    {
        RuleFor(r => r.CvFile)
            .NotEmpty()
            .NotNull();

        RuleFor(r => r.UserName)
            .NotEmpty()
            .NotNull();
    }
}
